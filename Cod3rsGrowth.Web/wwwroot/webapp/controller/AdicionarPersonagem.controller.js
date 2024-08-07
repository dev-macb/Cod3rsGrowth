sap.ui.define([
    "coders-growth/controller/BaseController",
    "../services/PersonagemService",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/ValueState"
], (BaseController, PersonagemService, MessageBox, JSONModel, ValueState) => {
    "use strict";

    return BaseController.extend("coders-growth.controller.AdicionarPersonagem", {
        onInit: function () {
            this.__definirModelo(new JSONModel(this._inicializarModeloPersonagem(), "personagem"));
            this._resetarEstadoInputs();
        },

        adicionarPersonagem: async function() {
            this._resetarEstadoInputs();

            // if (!this._validarInputs()) {
            //     MessageBox.error("Por favor, corrija os erros antes de salvar.");
            //     return;
            // }

            const modeloPersonagem = this.__obterModelo("personagem");
            const novoPersonagem = this._inicializarModeloPersonagem(modeloPersonagem);

            try {
                await PersonagemService.adicionar(novoPersonagem);
                sap.m.MessageToast.show("Personagem adicionado com sucesso!");
                this._limparFormulario();
            } 
            catch (erro) {
                this._exibirErroModal(erro);
            }
        },

        _inicializarModeloPersonagem: function(modeloPersonagem) {
            if (!modeloPersonagem) {
                modeloPersonagem = { personagem: {
                    nome: "",
                    vida: null,
                    energia: null,
                    velocidade: null,
                    forca: "",
                    inteligencia: "",
                    eVilao: null
                }};
            } else {
                modeloPersonagem = { personagem: {
                    nome: modeloPersonagem.nome,
                    vida: parseInt(modeloPersonagem.vida, 10),
                    energia: parseInt(modeloPersonagem.energia, 10),
                    velocidade: parseFloat(modeloPersonagem.velocidade),
                    forca: modeloPersonagem.forca,
                    inteligencia: modeloPersonagem.inteligencia,
                    eVilao: modeloPersonagem.eVilao === 1
                }};
            }

            return new JSONModel(modeloPersonagem);
        },

        _resetarEstadoInputs: function() {
            const inputs = ["inputNome", "inputVida", "inputEnergia", "inputVelocidade", "comboForca", "comboInteligencia"];
            inputs.forEach(inputId => {
                this.__obterElementoPorId(inputId).setValueState(ValueState.None);
            });
        },

        _validarInputs: function() {
            let contemErro = false;
            const modeloPersonagem = this.__obterModelo("personagem").getData();

            if (!this._validarCampoTexto("inputNome", modeloPersonagem.nome, 3, 100)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico("inputVida", modeloPersonagem.vida, 0, 100)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico("inputEnergia", modeloPersonagem.energia, 0, 50)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico("inputVelocidade", modeloPersonagem.velocidade, 0, 2)) {
                contemErro = true;
            }

            if (!this._validarCampoSelecao("comboForca", modeloPersonagem.forca)) {
                contemErro = true;
            }

            if (!this._validarCampoSelecao("comboInteligencia", modeloPersonagem.inteligencia)) {
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
        },

        _exibirErroModal: function(erro) {
            console.log("_exibirErroModal")
            console.log(erro)

            MessageBox.error(
                erro.detail,
                {
                    title: erro.title,
                    details: `Status: ${erro.status} - ${erro.errors.personagem} ${$.id}`,
                    contentWidth: "500px"
                }
            );
        },

        _limparFormulario: function() {
            this.__definirModelo(this._inicializarModeloPersonagem(), "personagem");
            this._resetarEstadoInputs();
        }
    });
});
