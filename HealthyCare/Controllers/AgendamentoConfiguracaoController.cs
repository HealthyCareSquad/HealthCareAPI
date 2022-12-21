using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HealthyCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoConfiguracaoController : ControllerBase
    {

        private readonly Projeto.Data.Interfaces.IAgendamentoConfiguracaoRepository _agendamentoConfiguracaoRepository;

        public AgendamentoConfiguracaoController(
            Projeto.Data.Interfaces.IAgendamentoConfiguracaoRepository agendamentoConfiguracaoRepository)
        {
            _agendamentoConfiguracaoRepository = agendamentoConfiguracaoRepository;
        }



        [HttpGet]
        [Route("api/Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.AgendamentoConfiguracaoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar()
        {
            try
            {
                List<AgendamentoConfiguracaoDto> resultado = _agendamentoConfiguracaoRepository.Listar();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.AgendamentoConfiguracaoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                AgendamentoConfiguracaoDto resultado = _agendamentoConfiguracaoRepository.Consultar(id);

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
        public IActionResult Cadastrar(AgendamentoConfiguracaoDto cadastrarDto)
        {
            try
            {
                if (cadastrarDto == null || cadastrarDto.IdHospital < 1)
                {
                    return NoContent();
                }


                int retornoCadastrar = _agendamentoConfiguracaoRepository.Cadastrar(cadastrarDto);
                return Ok(retornoCadastrar);


            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

            _agendamentoConfiguracaoRepository.Cadastrar(cadastrarDto);

            return BadRequest();

        }

        [HttpPatch]
        [Route("api/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(AgendamentoConfiguracaoDto cadastrarDto)
        {

            try
            {
                return Ok(_agendamentoConfiguracaoRepository.Atualizar(cadastrarDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (cadastrarDto == null || cadastrarDto.IdConfiguracao < 1)
                return NoContent();

            _agendamentoConfiguracaoRepository.Atualizar(cadastrarDto);

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
                return Ok(_agendamentoConfiguracaoRepository.Excluir(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (id < 1)
                return NoContent();
            _agendamentoConfiguracaoRepository.Excluir(id);

            return BadRequest();

        }
    }
}
