using Microsoft.AspNetCore.Mvc;

namespace ApiFilmes.Core
{
    public class Paginacao
    {
        private static int TamanhoMaximo = 50;

        [BindProperty(Name = "pagina", SupportsGet = true)]
        public int Pagina { get; set; } = 0;
        
        [BindProperty(Name = "pagina-tamanho", SupportsGet = true)]
        public int Tamanho { get; set; } = 20;

        public static void ValidarPaginacao(Paginacao paginacao)
        {
            if(paginacao is null)
            {
                paginacao = new Paginacao();
            }

            if(paginacao.Tamanho > TamanhoMaximo)
            {
                paginacao.Tamanho = TamanhoMaximo;
            }

        }
    }
}
