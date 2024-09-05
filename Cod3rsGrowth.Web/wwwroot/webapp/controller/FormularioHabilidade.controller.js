sap.ui.define([
    "coders-growth/common/BaseController",
    "coders-growth/common/HttpService",
    "coders-growth/common/Constantes",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/ValueState",
], (BaseController, HttpService, Constantes, JSONModel, ValueState) => {
    "use strict";

    const STRING_VAZIA = "";
    const TAMANHO_MIN_NOME = 3;
	const TAMANHO_MAX_NOME = 50;
	const TAMANHO_MIN_DESCRICAO = 0;
	const TAMANHO_MAX_DESCRICAO = 200;
	const INPUT_HABILIDADE_NOME = "inputNome";
	const INPUT_HABILIDADE_DESCRICAO = "inputDescricao";
    const ID_FORMULARIO_HABILIDADE = "tituloFormularioHabilidade";
    const TITULO_CADASTRAR = "Cadastrar Habilidade";

    return BaseController.extend("coders-growth.controller.FormularioHabilidade", {
        onInit: function () {
            this.__vincularRota(Constantes.ROTA_ADICIONAR_HABILIDADE, this._aoConcidirRotaAdicionar);
        },

        _aoConcidirRotaAdicionar: function () {
            this.__obterElementoPorId(ID_FORMULARIO_HABILIDADE).setText(TITULO_CADASTRAR);
            this.__obterElementoPorId(INPUT_HABILIDADE_NOME).setValueState(ValueState.None);
            this.__obterElementoPorId(INPUT_HABILIDADE_DESCRICAO).setValueState(ValueState.None);

            this.__definirModelo(new JSONModel(this._iniciarHabilidade()), Constantes.MODELO_HABILIDADE);
            this.modeloHabilidade = this.__obterModelo(Constantes.MODELO_HABILIDADE);
        },

        _iniciarHabilidade: function () {
            return { nome: STRING_VAZIA, descricao: STRING_VAZIA };
        },
        
        _validarInputs: function () {
            let contemErro = false;
            
            if (!this.__validarCampoTexto(INPUT_HABILIDADE_NOME, TAMANHO_MIN_NOME, TAMANHO_MAX_NOME)) {
                contemErro = true;
            }

            if (!this.__validarCampoTexto(INPUT_HABILIDADE_DESCRICAO, TAMANHO_MIN_DESCRICAO, TAMANHO_MAX_DESCRICAO)) {
                contemErro = true;
            }

            return !contemErro;
        },

        salvarHabilidade: async function () {
            if (!this._validarInputs()) {
                this.__exibirMessageBox(Constantes.I18N_AVISO_DE_VALIDACAO, "aviso");
                return;
            }

            const habilidade = this.modeloHabilidade.getData();

            this.__exibirEspera(async () => {
                const idHabilidade = await HttpService.post(Constantes.URL_HABILIDADE, habilidade);
                this.__exibirMessageToast(Constantes.I18N_HABILIDADE_CRIADA);
                return this.__navegarPara(Constantes.ROTA_HABILIDADE, { idHabilidade });
            }); 
        }
    });
});
