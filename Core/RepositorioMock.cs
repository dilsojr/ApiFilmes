namespace ApiFilmes.Core
{
    public class RepositorioMock
    {
        //Classe apenas para simular um repositório

        public List<string> ObterFilmesPaginado(Paginacao paginacao)
        {
            return ListaDeFilmes.Filmes.Skip(paginacao.Pagina).Take(paginacao.Tamanho).ToList();
        }

        public List<string>BuscarFilmesPelasTresPrimeirasLetras(string letras)
        {
            var filmesBuscados = ListaDeFilmes.Filmes
                .Where(x => x.Replace(" ", "").ToLower().StartsWith(letras.ToLower()))
                .Select(x => x);

            return filmesBuscados.ToList();
        }
    }
}
