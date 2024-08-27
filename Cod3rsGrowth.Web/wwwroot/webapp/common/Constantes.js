sap.ui.define([], function() {
    'use strict';

    const constantes = {
        URL_PERSONAGEM: "https://localhost:5051/api/Personagem",
        URL_HABILIDADE: "https://localhost:5051/api/Habilidade",

        ROTA_HOME: "home",
        ROTA_PERSONAGENS: "personagens",
        ROTA_PERSONAGEM: "personagem",
        ROTA_HABILIDADES: "habilidades",
        ROTA_FORMULARIO_PERSONAGEM: "formularioPersonagem",
        ROTA_EDITAR_PERSONAGEM: "editarPersonagem",
        ROTA_NOT_FOUND: "notFound",

        MODELO_PERSONAGEM: "personagem",
        MODELO_HABILIDADES: "habilidades",

        STATUS_FRACO: "Fraco",
        STATUS_MEDIO: "Médio",
        STATUS_BOM: "Bom",
        STATUS_EXCEPCIONAL: "Excepcional",
        STATUS_EXTRAORDINARIO: "Extraordinário",
        STATUS_DESCONHECIDO: "Desconhecido",

        PROPOSITO_HEROI: "Herói",
        PROPOSITO_VILAO: "Vilão",

        CLASSE_VILAO: "txtVilao",
	    CLASSE_HEROI: "txtHeroi",

        PROPRIEDADE_E_VILAO: "/eVilao",

        ID_CALENDARIO: "calendario",
        ID_TEXT_PROPOSITO: "txtEVilao",

        MSG_AVISO_DE_VALIDACAO: "Por favor, corrija o(s) erro(s) no formulário antes de salvar.",
        MSG_AVISO_DE_EXCLUSAO: "Tem certeza que deseja excluir o registro?",

        IMG_LUVA_AZUL: "images/luva_azul.png",
	    IMG_LUVA_VERMELHA: "images/luva_vermelha.png",
    };

    return constantes;
});