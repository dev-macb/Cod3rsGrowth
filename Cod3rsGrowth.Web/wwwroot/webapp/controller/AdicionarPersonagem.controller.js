sap.ui.define([
    "coders-growth/controller/BaseController",
    "../services/PersonagemService",
    "sap/m/MessageBox",
    "sap/m/MessageToast",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/ValueState"
], (BaseController, PersonagemService, MessageBox, MessageToast, JSONModel, ValueState) => {
    "use strict";

    return BaseController.extend("coders-growth.controller.AdicionarPersonagem", {
        onInit: function () {
            this.__vincularRota("adicionarPersonagem", this._aoConcidirRota)
        },

        _aoConcidirRota: function () {
            this._resetarEstadoInputs();
            this.__definirModelo(new JSONModel(this._iniciarPersonagem()), "personagem");
            this.modeloPersonagem = this.__obterModelo("personagem")
        },

        adicionarPersonagem: async function() {
            if (!this._validarInputs()) {
                MessageBox.warning("Por favor, corrija o(s) erro(s) no formulário antes de salvar.");
                return;
            }

            const personagem = this.modeloPersonagem.getData();
            personagem.forca = parseInt(personagem.forca, 10)
            personagem.inteligencia = parseInt(personagem.inteligencia, 10)
            personagem.habilidades = this._obterHabilidadesSelecionadas();
            
            try {
                const resultado = await PersonagemService.adicionar(personagem);
                MessageToast.show(`Personagem ${resultado} criado com êxito!`, { duration: 5000, closeOnBrowserNavigation: false });
                this._resetarEstadoInputs();
                this.__navegarPara("personagem", { idPersonagem: resultado });
            } 
            catch (erro) {
                this._exibirErroModal(erro);
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
            const lista = this.__obterElementoPorId("listaHabilidadeSelecionadas");
            const itensSelecionados = lista.getSelectedItems();

            return itensSelecionados.map(item => item.getBindingContext("habilidades").getProperty("id"));
        },

        _resetarEstadoInputs: function() {
            const inputs = ["inputNome", "inputVida", "inputEnergia", "inputVelocidade", "comboForca", "comboInteligencia"];
            inputs.forEach(inputId => {
                this.__obterElementoPorId(inputId).setValueState(ValueState.None);
            });
            this.__obterElementoPorId("listaHabilidadeSelecionadas").removeSelections();
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
            console.log(erro)

            let mensagemErro = "Ocorreu um erro desconhecido";
            let detalhesErro = "Sem stacktrace disponível";
        
            if (erro.Extensions && erro.Extensions.FluentValidation) {
                mensagemErro = Object.values(erro.Extensions.FluentValidation).join(" ");
            } 
            else if (erro.detail) {
                mensagemErro = erro.detail;
            }
        
            if (erro.Title || erro.title) {
                detalhesErro = `Status: ${erro.Status || erro.status} - ${erro.Detail || erro.errors?.$ || "Sem detalhes adicionais"}`;
            }
        
            MessageBox.error(
                mensagemErro,
                {
                    title: erro.Title || erro.title || "Erro ao adicionar personagem",
                    details: detalhesErro,
                    contentWidth: "500px"
                }
            );
        }
    });
});
