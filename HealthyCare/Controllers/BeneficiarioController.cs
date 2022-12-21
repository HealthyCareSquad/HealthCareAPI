using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Modelos;
using Projeto.Data.Repository;

namespace HealthyCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiarioController : ControllerBase
    {
        private readonly Projeto.Data.Interfaces.IBeneficiarioRepository _beneficiarioRepository;

        public BeneficiarioController(
            Projeto.Data.Interfaces.IBeneficiarioRepository beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository;
        }


        [HttpGet]
        [Route("api/Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar()
        {
            try
            {
                List<BeneficiarioDto> resultado = _beneficiarioRepository.Listar();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.BeneficiarioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                BeneficiarioDto resultado = _beneficiarioRepository.Consultar(id);

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
        public IActionResult Cadastrar(BeneficiarioDto cadastrarDto)
        {
            try
            {
                if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.Nome))
                {
                    return NoContent();
                }


                int retornoCadastrar = _beneficiarioRepository.Cadastrar(cadastrarDto);
                return Ok(retornoCadastrar);
            }

            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

            _beneficiarioRepository.Cadastrar(cadastrarDto);

            return BadRequest();

        }

        [HttpPatch]
        [Route("api/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(BeneficiarioDto cadastrarDto)
        {

            try
            {
                return Ok(_beneficiarioRepository.Atualizar(cadastrarDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.Nome))
                return NoContent();

            _beneficiarioRepository.Atualizar(cadastrarDto);

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
                return Ok(_beneficiarioRepository.Excluir(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
