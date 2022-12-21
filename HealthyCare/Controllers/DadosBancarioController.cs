using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;


namespace HealthyCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosBancarioController : ControllerBase
    {
        private readonly Projeto.Data.Interfaces.IDadosBancarioRepository _dadosBancarioRepository;

        public DadosBancarioController(
            Projeto.Data.Interfaces.IDadosBancarioRepository dadosBancarioRepository)
        {
            _dadosBancarioRepository = dadosBancarioRepository;
        }



        [HttpGet]
        [Route("api/Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.DadosBancarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar()
        {
            try
            {
                List<DadosBancarioDto> resultado = _dadosBancarioRepository.Listar();

                if (resultado == null)
                {
                    return NoContent();
                }

                if (resultado.Count == 0)
                {
                    throw new Exception("Sem elementos");
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        [Route("api/Consultar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.DadosBancarioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                DadosBancarioDto resultado = _dadosBancarioRepository.Consultar(id);

                if (resultado == null)
                    return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(DadosBancarioDto cadastrarDto)
        {
            try
            {
                if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.NumeroBanco))
                {
                    return NoContent();

                }
                int retornoCadastrar = _dadosBancarioRepository.Cadastrar(cadastrarDto);
                return Ok(retornoCadastrar);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("api/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(DadosBancarioDto cadastrarDto)
        {
            try
            {
                return Ok(_dadosBancarioRepository.Atualizar(cadastrarDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("api/Excluir")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            try
            {
                return Ok(_dadosBancarioRepository.Excluir(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

