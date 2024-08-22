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

        MSG_AVISO_DE_VALIDACAO: "Por favor, corrija o(s) erro(s) no formulário antes de salvar."
    };

    return constantes;
});