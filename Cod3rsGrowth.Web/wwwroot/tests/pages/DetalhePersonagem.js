sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Ancestor",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationContainsPropertyEqual"
], function (Opa5, Press, Ancestor, Properties, PropertyStrictEquals, AggregationContainsPropertyEqual) {
    "use strict";

    const nomeDaView = "DetalhePersonagem";

    Opa5.createPageObjects({
        naPaginaDetalhePersonagem: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        id: "botaoVoltar",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar."
                    });
                },
                aoClicarNoBotaoExcluirPersonagem: function() {
                    return this.waitFor({
                        id: "botaoExcluirPersonagem",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão Excluir."
                    });
                },
                aoClicarNoBotaoDoMessageBox: function (textoButao) {
                    return this.waitFor({
						controlType: "sap.m.Button",
						matchers: [
							new Properties({ text: textoButao }),
							new Ancestor(Opa5.getContext().dialog, false) 
						],
						actions: new Press(),
						success: function () {
							Opa5.assert.ok(true, `Sucesso ao fechar MessageBox ao clicar no botao '${textoButao}'.`);
						},
						errorMessage: "Falha ao fechar MessageBox ao clicar no botao Ok."
                    });
                },
                aoClicarEmNovaHabilidade: function() {
                    return this.waitFor({
                        id: "butaoNovaHabilidade",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão Novo."
                    });
                },
                aoClicarEmEditarHabilidade: function (indiceLista = 0) {
                    return this.waitFor({
                        id: "listaHabilidade",
                        viewName: nomeDaView,
                        success: function (lista) {
                            const item = lista.getItems()[indiceLista];
                            this.waitFor({
                                controlType: "sap.m.StandardListItem",
                                matchers: new Properties({ title: item.getTitle() }),
                                actions: new Press({ idSuffix: "imgDet" }),
                                success: function () {
                                    Opa5.assert.ok(true, "Habilidade editada com sucesso.");
                                },
                                errorMessage: "Não foi possível clicar para editar a habilidade."
                            });
                        },
                        errorMessage: "Lista de habilidades não encontrada."
                    });
                },
                aoClicarEmSalvarHabilidade: function() {
                    return this.waitFor({
                        id: "butaoSalvarHabilidade",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão Novo."
                    });
                },
                aoFecharMessageBox: function (textoButao) {
                    return this.waitFor({
						controlType: "sap.m.Button",
						matchers: [
							new Properties({ text: textoButao }),
							new Ancestor(Opa5.getContext().dialog, false) 
						],
						actions: new Press(),
						success: function () {
							Opa5.assert.ok(true, "Sucesso ao fechar MessageBox ao clicar no botao Ok.");
						},
						errorMessage: "Falha ao fechar MessageBox ao clicar no botao Ok."
                    });
                },
                aoInserirNomeHabilidade: function(nome) {
                    return this.waitFor({
                        controlType: "sap.m.Input",
                        actions: new sap.ui.test.actions.EnterText({
                            text: nome
                        }),
                        success: function() {
                            Opa5.assert.ok(true, `Nome da habilidade '${nome}' foi inserido com sucesso.`);
                        },
                        errorMessage: "Não foi possível inserir o nome da habilidade."
                    });
                },
                aoInserirDescricaoHabilidade: function(descricao) {
                    return this.waitFor({
                        controlType: "sap.m.TextArea",
                        actions: new sap.ui.test.actions.EnterText({
                            text: descricao
                        }),
                        success: function() {
                            Opa5.assert.ok(true, `Descrição da habilidade '${descricao}' foi inserida com sucesso.`);
                        },
                        errorMessage: "Não foi possível inserir a descrição da habilidade."
                    });
                },
                aoClicarEmVincularAoPersonagem: function() {
                    return this.waitFor({
                        controlType: "sap.m.CheckBox",
                        actions: new Press(),
                        success: function() {
                            Opa5.assert.ok(true, "Checkbox 'Vincular ao personagem atual' foi marcado com sucesso.");
                        },
                        errorMessage: "Não foi possível marcar o checkbox 'Vincular ao personagem atual'."
                    });
                }
                
            },
            assertions: {
                verificaUrl: function (idEsperado) {
                    return this.waitFor({
                        success: function () {
                            var hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, `personagens/${idEsperado}`, `O hash da URL DetalhesPersonagem é 'personagens/${idEsperado}'`);
                        },
                        errorMessage: "A URL de detalhes do personagem está incorreta."
                    });
                },
                verificaDetalhesDoPersonagem: function () {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        check: function (textos) {
                            var idsRequeridos = ["txtVida", "txtEnergia", "txtVelocidade", "txtForca", "txtInteligencia", "txtEVilao"];
                            var todosCamposEncontrados = idsRequeridos.every(function (id) {
                                var texto = textos.find(function (texto) {
                                    return texto.getId().indexOf(id) !== -1;
                                });
                                return texto && texto.getText() !== "";
                            });
                            return todosCamposEncontrados;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "Todos os campos do formulário do personagem possuem dados");
                        },
                        errorMessage: "Alguns campos do formulário do personagem não foram encontrados ou estão vazios"
                    });
                },
                verificaTituloDaPagina: function (texto) {
                    return this.waitFor({
                        controlType: "sap.m.Title",
                        matchers: new PropertyStrictEquals({ name: "text", value: texto }),
                        success: function (titulo) {
                            Opa5.assert.ok(titulo, `A página possui titulo '${texto}'`);
                        },
                        errorMessage: `A página possui titulo '${texto}'`
                    });
                },
                verificaQuatidadeDaListaDeHabilidades: function (quantidadeEsperada) {
                    return this.waitFor({
                        id: "listaHabilidade",
                        viewName: nomeDaView,
                        success: function (lista) {
                            var quantidadeDeItens = lista.getItems().length;
                            Opa5.assert.strictEqual(quantidadeDeItens, quantidadeEsperada, `A lista de habilidades possui '${quantidadeEsperada}' itens`);
                        },
                        errorMessage: "A lista de habilidades não possui a quantidade esperada de itens."
                    });
                },
                verificaClasseTextoEVilao: function (classeEsperada) {
                    return this.waitFor({
                        id: "txtEVilao",
                        viewName: "DetalhePersonagem",
                        success: function (texto) {
                            var classeCSS = texto.aCustomStyleClasses[0];
                            var possuiClasseCSS = classeCSS.includes(classeEsperada);
                            Opa5.assert.ok(possuiClasseCSS, `O texto do Propósito do personagem possui a classe '${classeEsperada}'`);
                        },
                        errorMessage: "O texto de propósito não tem a classe esperada."
                    });
                },
                verificaMensagemDeConfirmacao: function (titulo, mensagem) {
                    return this.waitFor({
                        controlType: "sap.m.Dialog",
                        matchers: new Properties({ title: titulo }),
                        success: function (listaDeDialogos) {
                            var dialogo = listaDeDialogos[0];
                            this.waitFor({
                                controlType: "sap.m.Text",
                                matchers: new Ancestor(dialogo, false),
                                success: function (listaDeTextos) {
                                    const texto = listaDeTextos[0].getText();
                                    Opa5.assert.strictEqual(texto, mensagem, `O MessageBox apareceu com a mensagem '${mensagem}'`);
                                },
                                errorMessage: `O MessageBox apareceu com o título '${titulo}', mas a mensagem não correspondeu a: "${mensagem}".`
                            });
                        },
                        errorMessage: `O MessageBox não apareceu com o título '${titulo}'.`
                    });
                },
                deveHaverUmDialogoAberto: function(textoTitulo) {
                    return this.waitFor({
                        controlType: "sap.m.Dialog",
                        matchers: new Properties({ title: textoTitulo }),
                        success: function (dialogos) {
                            Opa5.assert.strictEqual(dialogos.length, 1, "Um diálogo está aberto com o título correto.");
                        },
                        errorMessage: `O diálogo esperado com o título '${textoTitulo}' não está aberto.`
                    });
                },
                deveMostrarMessageBox: function (titulo, mensagem) {
					return this.waitFor({
						controlType: "sap.m.Dialog",
						matchers: new Properties({ title: titulo }),
						success: function (dialogo) {
							this.waitFor({
                                controlType: "sap.m.Text",
                                matchers: new Ancestor(dialogo[0], false),
                                success: function(texto) {
                                    const txt = texto[0].getText();
                                    Opa5.assert.strictEqual(txt, mensagem, `O MessageBox apareceu com a mensagem '${mensagem}'`);
                                },
                                errorMessage: `O MessageBox apareceu, mas a mensagem não correspondeu a: "${mensagem}".`
                            });
						},
						errorMessage: `O MessageBox não apareceu com título '${titulo}' com mensagem '${mensagem}'.`
					});
				},
                deveExibirMessageToast: function (mensagem) {
                    return this.waitFor({
                        pollingInterval: 200,
                        check: function () {
                            var elementosMessageToast = sap.ui.test.Opa5.getJQuery()(".sapMMessageToast");
                            var elementosEsperados = elementosMessageToast.filter(function (i, elemento) {
                                return elemento && elemento.textContent.trim() === mensagem;
                            });
                
                            return elementosEsperados.length > 0;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "MessageToast foi exibido com o texto: " + mensagem);
                        },
                        errorMessage: "MessageToast com o texto '" + mensagem + "' não foi encontrado."
                    });
                },                       
            }
        }
    });
});