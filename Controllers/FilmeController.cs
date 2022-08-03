using ApiFilmes.Core;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilmes.Controllers
{
    [Route("api/filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly RepositorioMock _repositorioMock;

        public FilmeController(RepositorioMock repositorioMock)
        {
            _repositorioMock = repositorioMock;
        }

        [HttpGet("listar-filmes")]
        public async Task<ActionResult<List<string>>> ListarFilmes([FromQuery] Paginacao paginacao)
        {
            Paginacao.ValidarPaginacao(paginacao);

            var listaFilmes = _repositorioMock.ObterFilmesPaginado(paginacao);

            return Ok(listaFilmes);
        }

        [HttpGet("buscar-filmes")]
        public async Task<ActionResult<List<string>>> BuscarFilme([FromQuery] string letras)
        {
            if(letras.Length != 3)
            {
                return BadRequest("A busca deve conter 3 letras!");
            }

            var filmesBuscados = _repositorioMock.BuscarFilmesPelasTresPrimeirasLetras(letras);

            return Ok(filmesBuscados);
        }
    }
}
