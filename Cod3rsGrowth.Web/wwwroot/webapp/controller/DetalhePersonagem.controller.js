sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/HttpService",
	"coders-growth/common/Constantes",
	"coders-growth/models/Formatador",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat"
], function (BaseController, HttpService, Constantes, Formatador, JSONModel) {
	"use strict";

	const TAMANHO_MIN_NOME = 3;
	const TAMANHO_MAX_NOME = 50;
	const TAMANHO_MIN_DESCRICAO = 0;
	const TAMANHO_MAX_DESCRICAO = 200;
	const STRING_VAZIA = "";
	const PROPRIEDADE_ID = "id";
	const TITULO_CADASTRO = "Cadastrar Habilidade";
	const ID_MODAL_HABILIDADE = "dialogoCadastroHabilidade";
	const CHECKBOX_VINCULAR = "checkboxVincularHabilidade";
	const INPUT_HABILIDADE_NOME = "inputNomeHabilidade";
	const INPUT_HABILIDADE_DESCRICAO = "inputDescricaoHabilidade";
	const FRAGMENTO_MODAL_HABILIDADE = "coders-growth.view.ModalFormularioHabilidade";	

	return BaseController.extend("coders-growth.controller.DetalhePersonagem", {
		formatter: Formatador,

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
					const personagem = await HttpService.get(Constantes.URL_PERSONAGEM, this.idPersonagem);
					this.__definirModelo(new JSONModel(personagem), Constantes.MODELO_PERSONAGEM);
					this.modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM);
	
					const habilidadesDoPersonagem = await this._carregarHabilidadesDoPersonagem(this.modeloPersonagem.getData().habilidades);
					this.__definirModelo(new JSONModel(habilidadesDoPersonagem), Constantes.MODELO_HABILIDADES);

					var txtEVilao = this.__obterElementoPorId(Constantes.ID_TEXT_PROPOSITO);
					this.modeloPersonagem.getProperty(Constantes.PROPRIEDADE_E_VILAO) ? 
						txtEVilao.addStyleClass(Constantes.CLASSE_VILAO).removeStyleClass(Constantes.CLASSE_HEROI) : 
						txtEVilao.addStyleClass(Constantes.CLASSE_HEROI).removeStyleClass(Constantes.CLASSE_VILAO);
				}
				catch {
					this.__navegarPara(Constantes.ROTA_NOT_FOUND);
				}
			});
		},

		_carregarHabilidadesDoPersonagem: async function (habilidadesIds) {
			const habilidadesDoPersonagem = habilidadesIds.map(id => HttpService.get(Constantes.URL_HABILIDADE, id));
			return await Promise.all(habilidadesDoPersonagem);
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

		_exibirModalHabilidade: async function (titulo, habilidade = { nome: STRING_VAZIA, descricao: STRING_VAZIA }, exibirCheckbox = true) {
			this.__exibirEspera(async () => {
				this.__definirModelo(new JSONModel(habilidade), Constantes.MODELO_HABILIDADE);
				this.modeloHabilidade = this.__obterModelo(Constantes.MODELO_HABILIDADE);
		
				this.modalFormularioPersonagem ??= await this.loadFragment({
					name: FRAGMENTO_MODAL_HABILIDADE,
					controller: this
				});
		
				this.modalFormularioPersonagem.open();
				this.__obterElementoPorId(ID_MODAL_HABILIDADE).setTitle(titulo);
				this.__obterElementoPorId(CHECKBOX_VINCULAR).setVisible(exibirCheckbox).setSelected(false);
			});
		},

		aoClicarEmEditarPersonagem: function() {
			this.__navegarPara(Constantes.ROTA_EDITAR_PERSONAGEM, { idPersonagem: this.idPersonagem });
		},

		aoClicarEmExcluirPersonagem: async function () {
			this.__exibirEspera(async () => {
				this.__exibirMensagemDeConfirmacao(async () => {
					await HttpService.delete(Constantes.URL_PERSONAGEM, this.idPersonagem);
					this.__exibirMessageToast(`Personagem ${this.idPersonagem} foi excluído!`);
					this.__navegarPara(Constantes.ROTA_PERSONAGENS);
				});
			});		
		},

		aoClicarEmNovaHabilidade: async function() {
			this._exibirModalHabilidade(TITULO_CADASTRO);
		},

		aoClicarEmEditarHabilidade: async function (evento) {
			const idHabilidadeSelecionada = evento.getSource().getBindingContext(Constantes.MODELO_HABILIDADES).getProperty(PROPRIEDADE_ID);
			const habilidadeSelecionada = evento.getSource().getBindingContext(Constantes.MODELO_HABILIDADES).getObject();
			this._exibirModalHabilidade(`Editar Habilidade (${idHabilidadeSelecionada})`, habilidadeSelecionada, false);
		},

		aoClicarEmSalvarNovaHabilidade: function() {
			this.__exibirEspera(async () => {
				if (!this._validarInputs()) {
					this.__exibirMessageBox(Constantes.MSG_AVISO_DE_VALIDACAO, "aviso");
					return;
				}

				const habilidade = this.modeloHabilidade.getData();
				const ehEdicao = Boolean(habilidade.id);
				const resultado = ehEdicao 
					? await HttpService.put(Constantes.URL_HABILIDADE, habilidade.id, habilidade)
					: await HttpService.post(Constantes.URL_HABILIDADE, habilidade);

				if (!ehEdicao && this.__obterElementoPorId(CHECKBOX_VINCULAR).getSelected()) {
					const personagemAtual = this.modeloPersonagem.getData();
					personagemAtual.habilidades.push(resultado.id || habilidade.id);
					await HttpService.put(Constantes.URL_PERSONAGEM, personagemAtual.id, personagemAtual);
				}

				this.modalFormularioPersonagem.close();
				this.__exibirMessageToast(`Habilidade ${resultado || habilidade.id} ${ehEdicao ? "editada" : "criada"} com êxito!`);
				this._carregarDetalhesDoPersonagem();
			});
		},

		aoFecharDialogoHabilidade: function() {
			this.modalFormularioPersonagem.close();
		},
	});
});