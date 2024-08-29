sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/HttpService",
	"coders-growth/common/Constantes",
    "sap/m/MessageBox",
    "sap/m/MessageToast",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat"
], function (BaseController, HttpService, Constantes, MessageBox, MessageToast, JSONModel, DateFormat) {
	"use strict";

	const ACAO_OK = "OK";
	const FRAGMENTO_ADICIONAR_HABILIDADE = "coders-growth.view.ModalFormularioHabilidade";

	return BaseController.extend("coders-growth.controller.DetalhePersonagem", {
		onInit: function () {
            this.__vincularRota(Constantes.ROTA_PERSONAGEM, this._aoCoincidirRota);
		},

		_aoCoincidirRota: function (evento) {
			this.idPersonagem = evento.getParameter("arguments").idPersonagem;
			this._carregarDetalhesDoPersonagem();
		},

        _carregarDetalhesDoPersonagem: async function () {
			this.__exibirEspera(async () => {
				try {
					const personagem = await this._carregarPersonagem(this.idPersonagem);
					this.__definirModelo(new JSONModel(personagem), Constantes.MODELO_PERSONAGEM);
					this.modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM);
	
					const habilidadesDoPersonagem = await this._carregarHabilidadesDoPersonagem(this.modeloPersonagem.getData().habilidades);
					this.__definirModelo(new JSONModel(habilidadesDoPersonagem), Constantes.MODELO_HABILIDADES);

					var txtEVilao = this.__obterElementoPorId(Constantes.ID_TEXT_PROPOSITO);
					this.modeloPersonagem.getProperty(Constantes.PROPRIEDADE_E_VILAO) ? 
						txtEVilao.addStyleClass(Constantes.CLASSE_VILAO).removeStyleClass(Constantes.CLASSE_HEROI) : 
						txtEVilao.addStyleClass(Constantes.CLASSE_HEROI).removeStyleClass(Constantes.CLASSE_VILAO);
				}
				catch (erro) {
					this.__navegarPara(Constantes.ROTA_NOT_FOUND);
				}
			});
		},

		_carregarPersonagem: async function (id) {
			return await HttpService.get(Constantes.URL_PERSONAGEM, id);
		},

		_carregarHabilidadesDoPersonagem: async function (habilidades) {
			return await Promise.all(habilidades.map(async (id) => {
				return await HttpService.get(Constantes.URL_HABILIDADE, id);
			}));
		},

		_validarInputs: function () {
            let contemErro = false;
            
            if (!this.__validarCampoTexto("inputNomeHabilidade", 3, 50)) {
                contemErro = true;
            }

            if (!this.__validarCampoTexto("inputDescricaoHabilidade", 3, 50)) {
                contemErro = true;
            }

            return !contemErro;
        },

		_iniciarHabilidade: function () {
            return { nome: "", descricao: "" }
        },

		aoClicarEmEditarPersonagem: function() {
			this.__navegarPara(Constantes.ROTA_EDITAR_PERSONAGEM, { idPersonagem: this.__obterModelo(Constantes.MODELO_PERSONAGEM).getData().id });
		},

		aoClicarEmRemoverPersonagem: async function () {
			MessageBox.warning(Constantes.MSG_AVISO_DE_EXCLUSAO, { 
				actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL], 
				emphasizedAction: MessageBox.Action.OK,
				onClose: async (acao) => {
					this.__exibirEspera(async () => {
						if (acao === ACAO_OK) {	
							await HttpService.delete(Constantes.URL_PERSONAGEM, this.__obterModelo(Constantes.MODELO_PERSONAGEM).getData().id);
							this.__navegarPara(Constantes.ROTA_PERSONAGENS);
						}
					});
				}
			});			
		},

		aoClicarEmNovaHabilidade: async function() {
			this.__obterElementoPorId()
			this.__definirModelo(new JSONModel(this._iniciarHabilidade()), Constantes.MODELO_HABILIDADE);
            this.modeloHabilidade = this.__obterModelo(Constantes.MODELO_HABILIDADE);

			this.__exibirEspera(async () => {
				this.modalFormularioPersonagem ??= await this.loadFragment({ 
					name: FRAGMENTO_ADICIONAR_HABILIDADE, 
					controller: this
				});
				this.modalFormularioPersonagem.open();
			});
		},

		aoSalvarNovaHabilidade: function() {
			this.__exibirEspera(async () => {
				if (!this._validarInputs()) {
					MessageBox.warning(Constantes.MSG_AVISO_DE_VALIDACAO);
					return;
				}

				const habilidade = this.modeloHabilidade.getData();
				const idNovaHabilidade = await HttpService.post(Constantes.URL_HABILIDADE, habilidade);
                MessageToast.show(`Habilidade ${idNovaHabilidade} criada com êxito!`, { duration: Constantes.TEMPO_5_MILISEGUNDOS, closeOnBrowserNavigation: false });

				if (this.__obterElementoPorId("checkboxVincularHabilidade").getSelected()) {
					const personagemAtual = this.modeloPersonagem.getData();
					personagemAtual.habilidades.push(idNovaHabilidade);
					await HttpService.put(Constantes.URL_PERSONAGEM, personagemAtual.id, personagemAtual);
				}

				this.modalFormularioPersonagem.close();
				this._carregarDetalhesDoPersonagem();
			});
		},

		aoFecharDialogoHabilidade: function() {
			this.modalFormularioPersonagem.close();
		},

		formatter: {	
            formatarNivel: function(valor) {
                switch (valor) {
					case 0: return Constantes.STATUS_FRACO;
					case 1: return Constantes.STATUS_MEDIO;
					case 2: return Constantes.STATUS_BOM;
					case 3: return Constantes.STATUS_EXCEPCIONAL;
					case 4: return Constantes.STATUS_EXTRAORDINARIO;
					default: return Constantes.STATUS_DESCONHECIDO;
				}
            },
			formatarProposito: function(proposito) {
                return proposito ? Constantes.PROPOSITO_VILAO : Constantes.PROPOSITO_HEROI;
            },
			formatarData: function(data) {
				if (!data) return "---";

				const formatadorDeData = DateFormat.getDateTimeInstance({ pattern: "dd/MM/yyyy" });
            	return formatadorDeData.format(new Date(data));
			}
        }
	});
});