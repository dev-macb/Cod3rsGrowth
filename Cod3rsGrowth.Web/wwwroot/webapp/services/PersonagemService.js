sap.ui.define([], function() {
    "use strict";

    const URL_OBTER_TODOS_PERSONAGEM = "https://localhost:5051/api/Personagem";
    const PARAMETRO_DATABASE = "database";
    const PARAMETRO_DATATETO = "datateto";

    return {
        obterTodosPersonagens: async function(filtros) {
            const urlObterTodosPersongens = new URL(URL_OBTER_TODOS_PERSONAGEM);

            Object.keys(filtros).forEach(chave => {
                let valor = filtros[chave];

                if (chave === PARAMETRO_DATABASE || chave === PARAMETRO_DATATETO) {
                    const data = new Date(valor);
                    if (!isNaN(data)) valor = data.toISOString();
                }

                urlObterTodosPersongens.searchParams.append(chave, valor);
            });

            try {
                const resposta = await fetch(urlObterTodosPersongens.href, {
                    method: "GET",
                    headers: { "Content-Type": "application/json" }
                });

                if (!resposta.ok) throw new Error('Erro na resposta da API');

                return await resposta.json();
            } 
            catch (erro) {
                console.error(erro);
                throw erro;
            }
        }
    };
});