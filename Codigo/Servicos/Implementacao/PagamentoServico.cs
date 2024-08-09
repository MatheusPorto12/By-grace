using ByGrace.IRepositorio;
using Newtonsoft.Json.Linq;

namespace ByGrace.Servicos.Implementacao
{
    public class PagamentoServico : ServicoBase
    {
        public PagamentoServico(IRepositorioTrabalho contexto) : base(contexto)
        {
        }

        public async Task<String> GerarBrCode(double valor) {

            // URL da API que você quer acessar
            string url = "https://gerarqrcodepix.com.br/api/v1?nome=Matheus Vinicius&cidade=Belo Horizonte&chave=10811317641&valor="+valor+"&saida=br";

            // Criando uma instância de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fazendo a requisição GET
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Verificando se a resposta foi bem-sucedida
                    response.EnsureSuccessStatusCode();

                    // Lendo o conteúdo da resposta como uma string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Exibindo o conteúdo da resposta
                    JObject json = JObject.Parse(responseBody);

                    string brcode = json["brcode"].ToString();

                    return brcode;
                }
                catch (HttpRequestException e)
                {
                    
                }
            }

            return null;

        } 

    }
}
