sap.ui.define([], function() {
    'use strict';

    const constantes = {
        URL_PERSONAGEM: "https://localhost:5051/api/Personagem",
        URL_HABILIDADE: "https://localhost:5051/api/Habilidade",

        ROTA_HOME: "home",
        ROTA_PERSONAGENS: "personagens",
        ROTA_PERSONAGEM: "personagem",
        ROTA_HABILIDADES: "habilidades",
        ROTA_ADICIONAR_PERSONAGEM: "adicionarPersonagem",
        ROTA_EDITAR_PERSONAGEM: "editarPersonagem",
        ROTA_ADICIONAR_HABILIDADE: "adicionarHabilidade",
        ROTA_EDITAR_HABILIDADE: "editarHabilidade",
        ROTA_NOT_FOUND: "notFound",
        ROTA_HABILIDADE: "habilidade",

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

        MSG_AVISO_DE_VALIDACAO: "Por favor, corrija o(s) erro(s) no formulário antes de salvar.",
        MSG_AVISO_DE_EXCLUSAO: "Tem certeza que deseja excluir o registro?",
        MSG_AVISO_DE_DESASSOCIACAO: "Tem certeza que deseja remover essa habilidade do personagem?",


        MSG_PERSONAGEM_CRIADO: "Personagem criado com êxito!",
        MSG_PERSONAGEM_EDITADO: "Personagem editado com êxito!",
        MSG_PERSONAGEM_EXCLUIDO: "Personagem excluído com êxito!",
        MSG_HABILIDADE_CRIADA: "Habilidade criada com êxito!",
        MSG_HABILIDADE_EDITADA: "Habilidade editada com êxito!",
        MSG_HABILIDADE_EXCLUIDA: "Habilidade excluída com êxito!",


        IMG_LUVA_AZUL: "images/luva_azul.png",
	    IMG_LUVA_VERMELHA: "images/luva_vermelha.png",

        TEMPO_5_MILISEGUNDOS: 5000
    };

    return constantes;
});