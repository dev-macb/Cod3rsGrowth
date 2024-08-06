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
            const personagemModelo = new JSONModel({
                nome: null,
                vida: null,
                energia: null,
                velocidade: null,
                forca: null,
                inteligencia: null,
                eVilao: null
            });
            this.definirModelo(personagemModelo, "personagem");
            this._resetarEstadoInputs();
        },

        adicionarPersonagem: async function() {
            this._resetarEstadoInputs();

            if (this._validarInputs()) {
                MessageBox.error("Por favor, corrija os erros antes de salvar.");
                return;
            }

            const modeloPersonagem = this.obterModelo("personagem").getData();

            const novoPersonagem = {
                nome: modeloPersonagem.nome,
                vida: parseInt(modeloPersonagem.vida, 10),
                energia: parseInt(modeloPersonagem.energia, 10),
                velocidade: parseFloat(modeloPersonagem.velocidade),
                forca: modeloPersonagem.forca,
                inteligencia: modeloPersonagem.inteligencia,
                eVilao: modeloPersonagem.eVilao === 1
            };

            try {
                await PersonagemService.adicionar(novoPersonagem);
                sap.m.MessageToast.show("Personagem adicionado com sucesso!");
            } 
            catch (erro) {
                sap.m.MessageToast.show("Erro ao adicionar personagem.");
            }
        },

        _resetarEstadoInputs: function() {
            const visualizacao = this.obterVisualizacao();
            const inputs = ["inputNome", "inputVida", "inputEnergia", "inputVelocidade", "comboForca", "comboInteligencia"];

            inputs.forEach(function(inputId) {
                visualizacao.byId(inputId).setValueState(ValueState.None);
            });
        },

        _validarInputs: function() {
            let contemErro = false;
            const visualizacao = this.obterVisualizacao();
            const modeloPersonagem = this.obterModelo("personagem").getData();

            if (!modeloPersonagem.nome || isNaN(modeloPersonagem.vida) || modeloPersonagem.vida.length < 3 || modeloPersonagem.vida.length > 100) {
                visualizacao.byId("inputNome").setValueState(ValueState.Error);
                contemErro = true;
            }

            if (!modeloPersonagem.vida || isNaN(modeloPersonagem.vida) || modeloPersonagem.vida < 0 || modeloPersonagem.vida > 100) {
                visualizacao.byId("inputVida").setValueState(ValueState.Error);
                contemErro = true;
            }

            if (!modeloPersonagem.energia || isNaN(modeloPersonagem.energia) || modeloPersonagem.energia < 0 || modeloPersonagem.energia > 50) {
                visualizacao.byId("inputEnergia").setValueState(ValueState.Error);
                contemErro = true;
            }

            if (!modeloPersonagem.velocidade || isNaN(modeloPersonagem.velocidade) || modeloPersonagem.velocidade < 0 || modeloPersonagem.velocidade > 2) {
                visualizacao.byId("inputVelocidade").setValueState(ValueState.Error);
                contemErro = true;
            }

            if (!modeloPersonagem.forca) {
                visualizacao.byId("comboForca").setValueState(ValueState.Error);
                contemErro = true;
            }

            if (!modeloPersonagem.inteligencia) {
                visualizacao.byId("comboInteligencia").setValueState(ValueState.Error);
                contemErro = true;
            }

            return !contemErro;
        }
    });
});