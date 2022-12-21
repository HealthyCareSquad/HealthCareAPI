using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Repository;

namespace HealthyCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly Projeto.Data.Interfaces.IProfissionalRepository _profissionalRepository;

        public ProfissionalController(
            Projeto.Data.Interfaces.IProfissionalRepository profissionalRepository)
        {
            _profissionalRepository = profissionalRepository;
        }



        [HttpGet]
        [Route("api/Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar()
        {
            try
            {
                List<ProfissionalDto> resultado = _profissionalRepository.Listar();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.ProfissionalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                ProfissionalDto resultado = _profissionalRepository.Consultar(id);

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
        public IActionResult Cadastrar(ProfissionalDto cadastrarDto)
        {
            try
            {
                if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.Nome))
                    return NoContent();

                int retornoCadastrar = _profissionalRepository.Cadastrar(cadastrarDto);
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
        public IActionResult Atualizar(ProfissionalDto cadastrarDto)
        {
            try
            {
                return Ok(_profissionalRepository.Atualizar(cadastrarDto));
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
                return Ok(_profissionalRepository.Excluir(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
