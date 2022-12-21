using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;

namespace HealthyCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly Projeto.Data.Interfaces.IAgendamentoRepository _agendamentoRepository;

        public AgendamentoController(
            Projeto.Data.Interfaces.IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        [HttpGet]
        [Route("api/Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.AgendamentoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar()
        {
            try
            {
                List<AgendamentoDto> resultado = _agendamentoRepository.Listar();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.AgendamentoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                AgendamentoDto resultado = _agendamentoRepository.Consultar(id);

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
        public IActionResult Cadastrar(AgendamentoDto cadastrarDto)
        {
            try
            {
                if (cadastrarDto == null || cadastrarDto.IdHospital < 1)
                {
                    return NoContent();
                }
                    
                int retornoCadastrar = _agendamentoRepository.Cadastrar(cadastrarDto);
                return Ok(retornoCadastrar);


            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

            _agendamentoRepository.Cadastrar(cadastrarDto);

            return BadRequest();

        }

        [HttpPatch]
        [Route("api/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(AgendamentoDto cadastrarDto)
        {

            try
            {
                return Ok(_agendamentoRepository.Atualizar(cadastrarDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (cadastrarDto == null || cadastrarDto.IdAgendamento < 1)
                return NoContent();

            _agendamentoRepository.Atualizar(cadastrarDto);

            return BadRequest();

        }

        [HttpDelete]
        [Route("api/Excluir")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {

            try
            {
                return Ok(_agendamentoRepository.Excluir(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
