sap.ui.define([], function() {
    "use strict";

    async function requisicaoHttp(method, urlBase, argumentos = null, query = {}, corpo = null) {
        if (argumentos) urlBase = urlBase + "/" + argumentos;

        const url = new URL(urlBase);

        Object.keys(query).forEach(chave => {
            let valor = query[chave];
            if (chave === "dataBase" || chave === "dataTeto") {
                const data = new Date(valor);
                if (!isNaN(data)) valor = data.toISOString();
            }
            url.searchParams.append(chave, valor);
        });

        const cabecalhos = {
            method: method,
            headers: { "Content-Type": "application/json" },
            body: corpo ? JSON.stringify(corpo) : null
        };
        
        try {
            const resposta = await fetch(url.href, cabecalhos);

            if (!resposta.ok) {
                throw erro;
            }

            if (resposta.status == 204) {
                return;
            }
            
            return await resposta.json();
        } 
        catch (erro) {
            console.log(erro)
            throw erro;
        }
    }

    return {
        get: function(url, argumentos, query) {
            return requisicaoHttp("GET", url, argumentos, query, null);
        },
        post: function(url, corpo) {
            return requisicaoHttp("POST", url, null, {}, corpo);
        },
        put: function(url, argumentos, corpo) {
            return requisicaoHttp("PUT", url, argumentos, {}, corpo);
        },
        delete: function(url) {
            return requisicaoHttp("DELETE", url);
        }
    };
});
