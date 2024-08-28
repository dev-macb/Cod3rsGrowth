sap.ui.define([
    "coders-growth/common/BaseController",
    "coders-growth/common/HttpService",
    "coders-growth/common/Constantes",
    "sap/m/MessageBox",
    "sap/m/MessageToast",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/ValueState",
], (BaseController, HttpService, Constantes, MessageBox, MessageToast, JSONModel, ValueState) => {
    "use strict";

    return BaseController.extend("coders-growth.controller.FormularioHabilidade", {
        onInit: function () {
            this.__vincularRota(Constantes.ROTA_ADICIONAR_HABILIDADE, this._aoConcidirRotaAdicionar);
        },

        _aoConcidirRotaAdicionar: function () {
            this.__obterElementoPorId("tituloFormularioHabilidade").setText("Cadastrar Habilidade");
            this.__obterElementoPorId("inputNome").setValueState(ValueState.None);
            this.__obterElementoPorId("inputDescricao").setValueState(ValueState.None);

            this.__definirModelo(new JSONModel(this._iniciarHabilidade()), Constantes.MODELO_HABILIDADE);
            this.modeloHabilidade = this.__obterModelo(Constantes.MODELO_HABILIDADE);
        },

        _iniciarHabilidade: function () {
            return { nome: "", descricao: "" }
        },

        _validarInputs: function () {
            let contemErro = false;
            
            if (!this.__validarCampoTexto("inputNome", 3, 50)) {
                contemErro = true;
            }

            if (!this.__validarCampoTexto("inputDescricao", 3, 50)) {
                contemErro = true;
            }

            return !contemErro;
        },

        salvarHabilidade: async function () {
            if (!this._validarInputs()) {
                MessageBox.warning(Constantes.MSG_AVISO_DE_VALIDACAO);
                return;
            }

            const habilidade = this.modeloHabilidade.getData();

            try {
                const resultado = await HttpService.post(Constantes.URL_HABILIDADE, habilidade);
                MessageToast.show(`Habilidade ${resultado} criada com êxito!`, { duration: TMP_5_MILISEGUNDOS, closeOnBrowserNavigation: false });    
                // return this.__navegarPara(Constantes.ROTA_HABILIDADE, { idHabilidade: resultado });
                console.log(resultado);
            } 
            catch (erro) {
                this.__exibirErroModal(erro);
            }   
        }
    });
});
