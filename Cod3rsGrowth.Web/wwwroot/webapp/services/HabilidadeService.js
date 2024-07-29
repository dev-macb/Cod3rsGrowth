sap.ui.define([], function() {
    "use strict";

    const URL_OBTER_TODOS_HABILIDADES = "https://localhost:5051/api/Habilidade";
    const PARAMETRO_DATABASE = "database";
    const PARAMETRO_DATATETO = "datateto";

    return {
        obterTodasHabilidades: async function(filtros) {
            const urlObterTodasHabilidades = new URL(URL_OBTER_TODOS_HABILIDADES);

            Object.keys(filtros).forEach(chave => {
                let valor = filtros[chave];

                if (chave === PARAMETRO_DATABASE || chave === PARAMETRO_DATATETO) {
                    const data = new Date(valor);
                    if (!isNaN(data)) valor = data.toISOString();
                }

                urlObterTodasHabilidades.searchParams.append(chave, valor);
            });

            try {
                const resposta = await fetch(urlObterTodasHabilidades.href, {
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