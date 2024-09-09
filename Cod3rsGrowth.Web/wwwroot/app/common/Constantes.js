sap.ui.define([], function() {
    'use strict';

    const constantes = {
        URL_PERSONAGEM: "https://localhost:5051/api/Personagem",
        URL_HABILIDADE: "https://localhost:5051/api/Habilidade",

        ROTA_HOME: "home",
        ROTA_NOT_FOUND: "notFound",
        ROTA_PERSONAGENS: "personagens",
        ROTA_HABILIDADES: "habilidades",
        ROTA_PERSONAGEM: "personagem",
        ROTA_HABILIDADE: "habilidade",
        ROTA_ADICIONAR_PERSONAGEM: "adicionarPersonagem",
        ROTA_ADICIONAR_HABILIDADE: "adicionarHabilidade",
        ROTA_EDITAR_PERSONAGEM: "editarPersonagem",
        ROTA_EDITAR_HABILIDADE: "editarHabilidade",

        MODELO_PERSONAGEM: "personagem",
        MODELO_LISTA_PERSONAGENS: "personagens",
        MODELO_HABILIDADE: "habilidade",
        MODELO_HABILIDADES: "habilidades",

        STATUS_FRACO: "Fraco",
        STATUS_MEDIO: "Médio",
        STATUS_BOM: "Bom",
        STATUS_EXCEPCIONAL: "Excepcional",
        STATUS_EXTRAORDINARIO: "Extraordinário",
        STATUS_DESCONHECIDO: "Desconhecido",

        ACAO_OK: "OK",
        ACAO_CANCELAR: "Cancelar",

        PROPOSITO_HEROI: "Herói",
        PROPOSITO_VILAO: "Vilão",

        CLASSE_VILAO: "txtVilao",
	    CLASSE_HEROI: "txtHeroi",

        PROPRIEDADE_E_VILAO: "/eVilao",

        ID_CALENDARIO: "calendario",
        ID_TEXT_PROPOSITO: "txtEVilao",

        I18N_AVISO_DE_VALIDACAO: "geral.msg.avisoValidacao",
        I18N_AVISO_DE_EXCLUSAO: "geral.msg.avisoExclusao",
        I18N_AVISO_DE_DESASSOCIACAO: "geral.msg.avisoDesassociacao",
        I18N_PERSONAGEM_CRIADO: "geral.msg.personagemCriado",
        I18N_PERSONAGEM_EDITADO: "geral.msg.personagemEditado",
        I18N_PERSONAGEM_EXCLUIDO: "geral.msg.personagemExcluido",
        I18N_HABILIDADE_CRIADA: "geral.msg.habilidadeCriada",
        I18N_HABILIDADE_EDITADA: "geral.msg.habilidadeEditada",
        I18N_HABILIDADE_EXCLUIDA: "geral.msg.habilidadeExcluida",

        IMG_LUVA_AZUL: "images/luva_azul.png",
	    IMG_LUVA_VERMELHA: "images/luva_vermelha.png",

        BASE_10: 10,
        TEMPO_5_MILISEGUNDOS: 5000
    };

    return constantes;
});