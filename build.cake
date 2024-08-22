#addin nuget:?package=Cake.Docker


// Declaração de variáveis
var caminhoBin = "./bin";
var caminhoObj = "./obj";
var caminhoArtifacts = "./artifacts";
var caminhoPublish = "./artifacts/publish";
var nomeDaImagem = "cod3rsgrowth:latest";
var nomeDaSolucao = "./Cod3rsGrowth.sln";
var nomeDoProjetoWeb = "./Cod3rsGrowth.Web/Cod3rsGrowth.Web.csproj";
var nomeDoProjetoTest = "./Cod3rsGrowth.Tests/Cod3rsGrowth.Tests.csproj";


// Configuração e definições
var alvo = Argument("target", "Default");
var configuracao = Argument("configuration", "Release");

Setup(ctx => { 
    Information($"[*] Rodando o destino '{alvo}' na configuração '{configuracao}'.");
    Information("[*] Executando tarefas...");
});

Teardown(ctx => { 
    Information("[*] As tarefas foram executadas."); 
});


// Tarefas
Task("Limpeza").Does(() => {
    CleanDirectory(caminhoBin);
    CleanDirectory(caminhoObj);
    CleanDirectory(caminhoArtifacts);
    Information("[*] Artefatos de build anteriores foram removidos.");
});


Task("Restauração").IsDependentOn("Limpeza").Does(() => {
    DotNetRestore();
    Information("[*] Dependências do projeto foram restauradas.");
});


Task("Construção").IsDependentOn("Restauração").Does(() => {
    DotNetBuild(nomeDaSolucao, new DotNetBuildSettings { Configuration = "Release" });
    Information("[*] Código do projeto compilado com sucesso.");
});


Task("Empacotamento").IsDependentOn("Construção").Does(() => {
    try {
        DotNetPack(nomeDoProjetoWeb, new DotNetPackSettings { Configuration = "Release", OutputDirectory = caminhoArtifacts });
        Information("[*] Projeto empacotado com sucesso.");
    }
    catch (Exception erro) {
        Information($"[*] Falha ao empacotar projeto '{nomeDoProjetoWeb}'.");
        throw;
    }
});


Task("Publicação").IsDependentOn("Empacotamento").Does(() => {
    DotNetPublish(nomeDoProjetoWeb, new DotNetPublishSettings { Configuration = "Release", OutputDirectory = caminhoPublish });
    Information($"[*] Projeto '{nomeDoProjetoWeb}' foi publicado em '{caminhoPublish}'.");
});


Task("Testes").IsDependentOn("Publicação").Does(() => {
    try {
        DotNetTest("./Cod3rsGrowth.Tests/Cod3rsGrowth.Tests.csproj");
        Information("[*] Os testes foram executados com sucesso.");
    }
    catch (Exception erro) {
        Error("[*] Os testes falharam!");
        Error($"[*] Detalhes: {erro.Message}\n");
        //throw; Para o script caso teste falhar
    }
});


// Task("Docker").IsDependentOn("Testes").Does(() => {
//     try {
//         StartProcess("docker", $"build -t {nomeDaImagem} -f {caminhoArtifacts} .");
//         Information($"[*] Imagem Docker '{nomeDaImagem}' gerada com sucesso.");
//     }
//     catch (Exception erro) {
//         Information($"[*] Falha ao gerar imagem '{nomeDaImagem}' do projeto.");
//         Information($"[*] Detalhes:  '{erro}");
//         throw;
//     }
// });
// Task("DockerBuild").Does(() => {
//     var settings = new DockerImageBuildSettings { 
//         File = "./Dockerfile",  
//         Tag = "cod3rsgrowth:latest" 
//     };
    
//     DockerBuild(settings);
//     Information("[*] Imagem Docker construída com sucesso.");
// });
// Task("DockerRun").IsDependentOn("DockerBuild").Does(() => {
//     var settings = new DockerContainerRunSettings
//     {
//         Image = "cod3rsgrowth:latest",
//         Publish = "8080:80"
//     };
    
//     DockerRun(settings);
//     Information("[*] Contêiner Docker rodando na porta 8080.");
// });


Task("Docker Up").Does(() => {
    DockerComposeUp();
});


Task("Default").IsDependentOn("DockerBuild");


// Execução
RunTarget(alvo);