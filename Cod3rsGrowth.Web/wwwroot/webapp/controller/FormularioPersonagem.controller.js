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

    const ID_LISTA_HABILIDADES_SELECIONADAS = "listaHabilidadeSelecionadas";
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_VIDA = "inputVida";
    const ID_INPUT_ENERGIA = "inputEnergia";
    const ID_INPUT_VELOCIDAE = "inputVelocidade";
    const ID_COMBO_FORCA = "comboForca";
    const ID_COMBO_INTELIGENCIA = "comboInteligencia";
    const BASE_10 = 10;
    const TMP_5_MILISEGUNDOS = 5000;
    
    return BaseController.extend("coders-growth.controller.FormularioPersonagem", {
        onInit: function () {
            this.__vincularRota(Constantes.ROTA_FORMULARIO_PERSONAGEM, this._aoConcidirRotaAdicionar);
            this.__vincularRota(Constantes.ROTA_EDITAR_PERSONAGEM, this._aoConcidirRotaEditar);
        },

        _aoConcidirRotaAdicionar: function () {
            this._resetarEstadoInputs();
            this.__definirModelo(new JSONModel(this._iniciarPersonagem()), Constantes.MODELO_PERSONAGEM);
            this.modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM)
        },

        _aoConcidirRotaEditar: async function () {
            // TODO: MUDAR TITULO DA PAGINA
            try {
                const personagemExistente = await HttpService.get(Constantes.URL_PERSONAGEM, this._obterIdPeloParametro());
                this.__definirModelo(new JSONModel(personagemExistente), Constantes.MODELO_PERSONAGEM);
                this.modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM);
            } 
            catch (erro) {
                this.__exibirErroModal(erro);
            }
        },  

        _obterIdPeloParametro: function () {
            const indiceDoId = 1;
            return this.__obterRotiador().getHashChanger().getHash().split("/")[indiceDoId];
        },

        adicionarPersonagem: async function() {
            if (!this._validarInputs()) {
                MessageBox.warning(Constantes.MSG_AVISO_DE_VALIDACAO);
                return;
            }

            const personagem = this.modeloPersonagem.getData();
            personagem.forca = parseInt(personagem.forca, BASE_10)
            personagem.inteligencia = parseInt(personagem.inteligencia, BASE_10)
            personagem.habilidades = this._obterHabilidadesSelecionadas();
            
            try {
                const resultado = await HttpService.post(Constantes.URL_PERSONAGEM, personagem);
                MessageToast.show(`Personagem ${resultado} criado com êxito!`, { duration: TMP_5_MILISEGUNDOS, closeOnBrowserNavigation: false });
                this._resetarEstadoInputs();
                this.__navegarPara(Constantes.ROTA_PERSONAGEM, { idPersonagem: resultado });
                return resultado;
            } 
            catch (erro) {
                this.__exibirErroModal(erro);
            }
        },

        aoDigitarNoInpunt: function(evento) {
            let campo = evento.getSource();
            campo.setValueState(ValueState.None)
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

            return itensSelecionados.map(item => item.getBindingContext("habilidades").getProperty("id"));
        },

        _resetarEstadoInputs: function() {
            const inputs = [ID_INPUT_NOME, ID_INPUT_VIDA, ID_INPUT_ENERGIA, ID_INPUT_VELOCIDAE, ID_COMBO_FORCA, ID_COMBO_INTELIGENCIA];
            inputs.forEach(inputId => {
                this.__obterElementoPorId(inputId).setValueState(ValueState.None);
            });
            this.__obterElementoPorId(ID_LISTA_HABILIDADES_SELECIONADAS).removeSelections();
        },

        _validarInputs: function() {
            let contemErro = false;
            const modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM).getData();

            if (!this._validarCampoTexto(ID_INPUT_NOME, modeloPersonagem.nome, 3, 100)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico(ID_INPUT_VIDA, modeloPersonagem.vida, 0, 100)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico(ID_INPUT_ENERGIA, modeloPersonagem.energia, 0, 50)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico(ID_INPUT_VELOCIDAE, modeloPersonagem.velocidade, 0, 2)) {
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

        _validarCampoNumerico: function(id, valor, min, max) {
            const campo = this.__obterElementoPorId(id);
            if (!valor || isNaN(valor) || valor < min || valor > max) {
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
