namespace Cod3rsGrowth.Web
{
    public static class Constantes
    {
        public const string LOGGER_NOME = "ProblemDetailsExtensions";
        public const string CONTEXTO_TIPO_CONTEUDO = "ProblemDetailsExtensions";
        public const string URL_CONTROLLER = "api/[controller]";
        public const string URL_PARAMETRO_ID = "{id:int}";

        public const string VALIDACAO_TITULO = "Requisição inválida";
        public const string VALIDACAO_TIPO = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
        public const string VALIDACAO_EXTENCOES = "FluentValidation";
        public const string VALIDACAO_LOG = "Exceção de validação: {Message}. Detalhes: {ValidationErrors}";

        public const string SQL_TITULO = "Erro no banco de dados";
        public const string SQL_TIPO = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
        public const string SQL_EXTENCOES = "Erros SQL";
        public const string SQL_LOG = "Exceção SQL: {Message}. Número do Erro: {Number}. Procedimento: {Procedure}. Linha: {LineNumber}";

        public const string ERRO_INESPERADO_TITULO = "Erro inesperado";
        public const string ERRO_INESPERADO_EXTENCOES = "StackTrace";
        public const string ERRO_INESPERADO_LOG = "Exceção não tratada: {Message}. StackTrace: {StackTrace}";

        public const string MODELO_TITULO = "Um ou mais erros de validação ocorreram";
        public const string MODELO_DETALHE = "O corpo da requisição não está de acordo com o modelo esperado";
    }
}