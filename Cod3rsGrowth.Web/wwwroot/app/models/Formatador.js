sap.ui.define([
    "coders-growth/app/common/Constantes",
    "sap/ui/core/format/DateFormat"
], (Constantes, DateFormat) => {
    "use strict";

    return {
        formatarData: function (data) {
            if (!data) return "---";

            const formatadorDeData = DateFormat.getDateTimeInstance({ pattern: "dd/MM/yyyy" });
            return formatadorDeData.format(new Date(data));
        },

        formatarNivel: function (valor) {
            switch (valor) {
                case 0: return Constantes.STATUS_FRACO;
                case 1: return Constantes.STATUS_MEDIO;
                case 2: return Constantes.STATUS_BOM;
                case 3: return Constantes.STATUS_EXCEPCIONAL;
                case 4: return Constantes.STATUS_EXTRAORDINARIO;
                default: return Constantes.STATUS_DESCONHECIDO;
            }
        },
        
        formatarProposito: function (proposito) {
            return proposito ? Constantes.PROPOSITO_VILAO : Constantes.PROPOSITO_HEROI;
        },

        iconePersonagem: function(eVilao) {
            return eVilao ? Constantes.IMG_LUVA_VERMELHA : Constantes.IMG_LUVA_AZUL;
        }
    };
});