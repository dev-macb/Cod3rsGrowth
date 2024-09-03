sap.ui.define([
	"coders-growth/common/Constantes",
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/UIComponent",
	"sap/m/MessageBox",
    "sap/m/MessageToast",
    "sap/ui/core/BusyIndicator",
    "sap/ui/core/ValueState",
], function(Constantes, Controller, UIComponent, MessageBox, MessageToast, BusyIndicator, ValueState) {
	"use strict";

	return Controller.extend("coders-growth.controller.BaseController", {
		__obterRotiador : function () {
			return UIComponent.getRouterFor(this);
		},

		__navegarPara: function (rotaDestino, parametros = {}) {
			if (rotaDestino) this.__obterRotiador().navTo(rotaDestino, parametros);
			else this.__obterRotiador().navTo(Constantes.ROTA_HOME);
		},

		__vincularRota: function(rota, metodo) {
            this.__obterRotiador().getRoute(rota).attachMatched(metodo, this);
        },

		__definirModelo: function(modelo, nome) {
            this.getView().setModel(modelo, nome);
        },

        __obterModelo: function(nome) {
            return this.getView().getModel(nome);
        },

        __obterVisualizacao: function() {
            return this.getView();
        },

        __obterElementoPorId: function(id) {
            return this.byId(id);
        },

        __exibirEspera: async function (funcao, idElemento) {
            if (idElemento) this.__obterElementoPorId(idElemento).setBusy(true); 
            else BusyIndicator.show(0); 

            return Promise.resolve(funcao())
                .catch((erro) => {
                    this.__exibirErroModal(erro)
                })
                .finally(() => {
                    if (idElemento) this.__obterElementoPorId(idElemento).setBusy(false);
                    else BusyIndicator.hide();
                });
        },

		__exibirErroModal: function (erro) {
			let mensagemErro = erro.message || "Ocorreu um erro desconhecido.";
            let detalhesErro = erro.stack || "Sem stacktrace disponível.";
        
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
                    title: erro.Title || erro.title,
                    details: detalhesErro,
                    contentWidth: "500px"
                }
            );
		},

        __exibirMensagemDeConfirmacao: async function (acao, mensagem = Constantes.MSG_AVISO_DE_EXCLUSAO) {
            MessageBox.warning(mensagem, { 
				actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL], 
				emphasizedAction: MessageBox.Action.OK,
				onClose: async (evento) => {
                    if (evento === Constantes.ACAO_OK) {
                        await acao();
                    }
                }
			});	
        },


        __exibirMessageBox: function (mensagem, tipo) {
            switch (tipo) {
                case "info":
                    MessageBox.information(mensagem);
                    break;
                case "aviso":
                    MessageBox.warning(mensagem);
                    break;
                case "sucesso":
                    MessageBox.success(mensagem);
                    break;
                case "erro":
                    MessageBox.error(mensagem);
                    break;
                default:
                    MessageBox.show(mensagem, {
                        icon: MessageBox.Icon.NONE,
                        title: "Mensagem",
                        actions: [MessageBox.Action.OK]
                    });
                    break;
            }
        },        

        __exibirMessageToast: function (mensagem) {
            MessageToast.show(mensagem, { 
                duration: Constantes.TEMPO_5_MILISEGUNDOS, 
                closeOnBrowserNavigation: false 
            });
        },

        __validarCampoTexto: function(id, tamanhoMin, tamanhoMax) {
            const campo = this.__obterElementoPorId(id);
            const valor = campo.getValue();

            if (!valor || valor.length < tamanhoMin || valor.length > tamanhoMax) {
                campo.setValueState(ValueState.Error);
                return false; 
            }

            campo.setValueState(ValueState.None);
            return true;
        },
	});
});