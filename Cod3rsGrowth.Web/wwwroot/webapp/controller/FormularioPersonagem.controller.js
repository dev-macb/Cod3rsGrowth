sap.ui.define([
    "coders-growth/common/BaseController",
    "coders-growth/common/HttpService",
    "coders-growth/common/Constantes",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/ValueState",
], (BaseController, HttpService, Constantes, JSONModel, ValueState) => {
    "use strict";

    const ID_LISTA_HABILIDADES_SELECIONADAS = "listaHabilidadeSelecionadas";
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_VIDA = "inputVida";
    const ID_INPUT_ENERGIA = "inputEnergia";
    const ID_INPUT_VELOCIDADE = "inputVelocidade";
    const ID_COMBO_FORCA = "comboForca";
    const ID_COMBO_INTELIGENCIA = "comboInteligencia";
    const BASE_10 = 10;
    const ID_TITULO_FORMULARIO_PERSONAGEM = "tituloFormularioPersonagem"
    const TITULO_CADASTRAR = "Cadastrar Personagem";
    const TITULO_EDITAR = "Editar Personagem";
    const SEGUNDO_PARAMETRO = 1;
    const ACAO_ADICIONAR = "adicionar";
    const CONTEXTO_HABILIDADES = "habilidades"
    const PROPRIEDADE_ID = "id"
    const NOME_TAMANHO_MIN = 3;
    const NOME_TAMANHO_MAX = 100;
    const VIDA_VALOR_MIN = 0;
    const VIDA_VALOR_MAX = 100;
    const ENERGIA_VALOR_MIN = 0;
    const ENERGIA_VALOR_MAX = 50;
    const VELOCIDADE_VALOR_MIN = 0;
    const VELOCIDADE_VALOR_MAX = 2;
    const PROPRIEDADE_HABILIDADES = "/habilidades";
    const DIVISOR_BARRA = "/";
    
    return BaseController.extend("coders-growth.controller.FormularioPersonagem", {
        onInit: function () {
            this.__vincularRota(Constantes.ROTA_ADICIONAR_PERSONAGEM, this._aoConcidirRotaAdicionar);
            this.__vincularRota(Constantes.ROTA_EDITAR_PERSONAGEM, this._aoConcidirRotaEditar);
        },

        _aoConcidirRotaAdicionar: function () {
            this._resetarEstadoInputs();
            this.__obterElementoPorId(ID_TITULO_FORMULARIO_PERSONAGEM).setText(TITULO_CADASTRAR);

            this.__definirModelo(new JSONModel(this._iniciarPersonagem()), Constantes.MODELO_PERSONAGEM);
            this.modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM);
        },

        _aoConcidirRotaEditar: async function () {
            this._resetarEstadoInputs();
            this.__obterElementoPorId(ID_TITULO_FORMULARIO_PERSONAGEM).setText(TITULO_EDITAR);

            this.__exibirEspera(async () => {
				const personagemExistente = await HttpService.get(Constantes.URL_PERSONAGEM, this._obterListaDeParametros()[SEGUNDO_PARAMETRO]);
                this.__definirModelo(new JSONModel(personagemExistente), Constantes.MODELO_PERSONAGEM);
                this.modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM);

                this._definirHabilidadesSelecionadas();
			});
        },  

        salvarPersonagem: async function() {
            this.__exibirEspera(async () => {
                if (!this._validarInputs()) {
                    this.__exibirMessageBox(Constantes.MSG_AVISO_DE_VALIDACAO, "aviso");
                    return;
                }

                const personagem = this.modeloPersonagem.getData();
                personagem.forca = parseInt(personagem.forca, BASE_10);
                personagem.inteligencia = parseInt(personagem.inteligencia, BASE_10);
                personagem.habilidades = this._obterHabilidadesSelecionadas();
            
				const parametros = this._obterListaDeParametros(); 
                const acao = parametros[parametros.length - 1];
                const idPersonagem = parametros[parametros.length - 2];

                if (acao === ACAO_ADICIONAR) {
                    const resultado = await HttpService.post(Constantes.URL_PERSONAGEM, personagem);
                    this.__exibirMessageToast(Constantes.MSG_PERSONAGEM_CRIADO);
                    return this.__navegarPara(Constantes.ROTA_PERSONAGEM, { idPersonagem: resultado });
                }

                await HttpService.put(Constantes.URL_PERSONAGEM, idPersonagem, personagem);
                this.__exibirMessageToast(Constantes.MSG_PERSONAGEM_EDITADO);
                this.__navegarPara(Constantes.ROTA_PERSONAGEM, { idPersonagem });
			});
        },

        aoDigitarNoInpunt: function(evento) {
            let campo = evento.getSource();
            campo.setValueState(ValueState.None);
        },

        _obterListaDeParametros: function () {
            return this.__obterRotiador().getHashChanger().getHash().split(DIVISOR_BARRA);
        },

        _iniciarPersonagem: function() {
            return {
                nome: "",
                vida: null,
                energia: null,
                velocidade: null,
                forca: null,
                inteligencia: null,
                eVilao: null,
                habilidades: []
            }
        },

        _obterHabilidadesSelecionadas: function(){
            const lista = this.__obterElementoPorId(ID_LISTA_HABILIDADES_SELECIONADAS);
            const itensSelecionados = lista.getSelectedItems();

            return itensSelecionados.map(item => item.getBindingContext(CONTEXTO_HABILIDADES).getProperty(PROPRIEDADE_ID));
        },

        _definirHabilidadesSelecionadas: function(){
            const lista = this.__obterElementoPorId(ID_LISTA_HABILIDADES_SELECIONADAS);
            const habilidadesSelecionadas = this.__obterModelo(Constantes.MODELO_PERSONAGEM).getProperty(PROPRIEDADE_HABILIDADES);

            lista.getItems().forEach(item => {
                const habilidadeId = item.getBindingContext(CONTEXTO_HABILIDADES).getProperty(PROPRIEDADE_ID);
                const estaSelecionada = habilidadesSelecionadas.includes(habilidadeId);
                lista.setSelectedItem(item, estaSelecionada);
            });
        },

        _resetarEstadoInputs: function() {
            const inputs = [ID_INPUT_NOME, ID_INPUT_VIDA, ID_INPUT_ENERGIA, ID_INPUT_VELOCIDADE, ID_COMBO_FORCA, ID_COMBO_INTELIGENCIA];
            inputs.forEach(inputId => {
                this.__obterElementoPorId(inputId).setValueState(ValueState.None);
            });
            this.__obterElementoPorId(ID_LISTA_HABILIDADES_SELECIONADAS).removeSelections();
        },

        _validarInputs: function() {
            let contemErro = false;
            const modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM).getData();

            if (!this._validarCampoTexto(ID_INPUT_NOME, this.__obterElementoPorId(ID_INPUT_NOME).getProperty("value"), NOME_TAMANHO_MIN, NOME_TAMANHO_MAX)) {
                contemErro = true;
            } 

            if (!this._validarCampoNumerico(ID_INPUT_VIDA, this.__obterElementoPorId(ID_INPUT_VIDA).getProperty("value"), VIDA_VALOR_MIN, VIDA_VALOR_MAX)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico(ID_INPUT_ENERGIA, this.__obterElementoPorId(ID_INPUT_ENERGIA).getProperty("value"), ENERGIA_VALOR_MIN, ENERGIA_VALOR_MAX)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico(ID_INPUT_VELOCIDADE, this.__obterElementoPorId(ID_INPUT_VELOCIDADE).getProperty("value"), VELOCIDADE_VALOR_MIN, VELOCIDADE_VALOR_MAX)) {
                contemErro = true;
            }

            if (!this._validarCampoSelecao(ID_COMBO_FORCA, modeloPersonagem.forca)) {
                contemErro = true;
            }

            if (!this._validarCampoSelecao(ID_COMBO_INTELIGENCIA, modeloPersonagem.inteligencia)) {
                contemErro = true;
            }

            return !contemErro;
        },

        _validarCampoTexto: function(id, valor, minLen, maxLen) {
            const campo = this.__obterElementoPorId(id);
            if (!valor || valor.length < minLen || valor.length > maxLen) {
                campo.setValueState(ValueState.Error);
                return false; 
            }
            campo.setValueState(ValueState.None);
            return true;
        },

        _validarCampoNumerico: function(id, valor = null, min, max) {
            const campo = this.__obterElementoPorId(id);
            const valorNumerico = parseFloat(valor, BASE_10);
            if (isNaN(valorNumerico) || valorNumerico < min || valorNumerico > max) {
                campo.setValueState(ValueState.Error);
                return false;
            }
            campo.setValueState(ValueState.None);
            return true;
        },

        _validarCampoSelecao: function(id, valor) {
            const campo = this.__obterElementoPorId(id);
            if (!valor) {
                campo.setValueState(ValueState.Error);
                return false;
            }
            campo.setValueState(ValueState.None);
            return true;
        }
    });
});
