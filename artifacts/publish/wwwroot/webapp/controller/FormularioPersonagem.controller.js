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
    const ID_INPUT_VELOCIDADE = "inputVelocidade";
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
            this.__obterElementoPorId("tituloFormularioPersonagem").setText("Cadastrar Personagem");

            this.__definirModelo(new JSONModel(this._iniciarPersonagem()), Constantes.MODELO_PERSONAGEM);
            this.modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM);
        },

        _aoConcidirRotaEditar: async function () {
            this._resetarEstadoInputs();
            this.__obterElementoPorId("tituloFormularioPersonagem").setText("Editar Personagem");

            try {
                const personagemExistente = await HttpService.get(Constantes.URL_PERSONAGEM, this._obterListaDeParametros()[1]);
                this.__definirModelo(new JSONModel(personagemExistente), Constantes.MODELO_PERSONAGEM);
                this.modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM);

                this._definirHabilidadesSelecionadas();
            } 
            catch (erro) {
                this.__exibirErroModal(erro);
            }
        },  

        salvarPersonagem: async function() {
            if (!this._validarInputs()) {
                MessageBox.warning(Constantes.MSG_AVISO_DE_VALIDACAO);
                return;
            }

            const personagem = this.modeloPersonagem.getData();
            personagem.forca = parseInt(personagem.forca, BASE_10);
            personagem.inteligencia = parseInt(personagem.inteligencia, BASE_10);
            personagem.habilidades = this._obterHabilidadesSelecionadas();
            
            try {
                const parametros = this._obterListaDeParametros(); 
                const acao = parametros[parametros.length - 1];
                const idPersonagem = parametros[parametros.length - 2];

                if (acao === "adicionar") {
                    const resultado = await HttpService.post(Constantes.URL_PERSONAGEM, personagem);
                    MessageToast.show(`Personagem ${resultado} criado com êxito!`, { duration: TMP_5_MILISEGUNDOS, closeOnBrowserNavigation: false });    
                    this.__navegarPara(Constantes.ROTA_PERSONAGEM, { idPersonagem: resultado });
                }
                else if (acao === "editar") {
                    await HttpService.put(Constantes.URL_PERSONAGEM, idPersonagem, personagem);
                    MessageToast.show(`Personagem ${idPersonagem} atualizado com êxito!`, { duration: TMP_5_MILISEGUNDOS, closeOnBrowserNavigation: false });
                    this.__navegarPara(Constantes.ROTA_PERSONAGEM, { idPersonagem: idPersonagem });
                }
            } 
            catch (erro) {
                this.__exibirErroModal(erro);
            }
        },

        aoDigitarNoInpunt: function(evento) {
            let campo = evento.getSource();
            campo.setValueState(ValueState.None);
        },

        _obterListaDeParametros: function () {
            return this.__obterRotiador().getHashChanger().getHash().split("/");
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

        _definirHabilidadesSelecionadas: function(){
            const lista = this.__obterElementoPorId(ID_LISTA_HABILIDADES_SELECIONADAS);
            const habilidadesSelecionadas = this.__obterModelo(Constantes.MODELO_PERSONAGEM).getProperty("/habilidades");

            lista.getItems().forEach(item => {
                const contextoHabilidade = item.getBindingContext("habilidades");
                const habilidadeId = contextoHabilidade.getProperty("id");
        
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

            if (!this._validarCampoTexto(ID_INPUT_NOME, this.__obterElementoPorId(ID_INPUT_NOME), 3, 100)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico(ID_INPUT_VIDA, this.__obterElementoPorId(ID_INPUT_VIDA).getProperty("value"), 0, 100)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico(ID_INPUT_ENERGIA, this.__obterElementoPorId(ID_INPUT_ENERGIA).getProperty("value"), 0, 50)) {
                contemErro = true;
            }

            if (!this._validarCampoNumerico(ID_INPUT_VELOCIDADE, this.__obterElementoPorId(ID_INPUT_VELOCIDADE).getProperty("value"), 0, 2)) {
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
            const valorNumerico = parseInt(valor, BASE_10);
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
