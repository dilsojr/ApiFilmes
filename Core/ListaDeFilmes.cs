namespace ApiFilmes.Core
{
    public class ListaDeFilmes
    {
        public static List<string> Filmes = new List<string>();

        public static void ListarFilmes()
        {
            foreach (var line in File.ReadLines("arquivo-filmes.txt"))
            {
                var filme = line.TrimStart().TrimEnd();
                Filmes.Add(filme);
            }
        }
    }
}
