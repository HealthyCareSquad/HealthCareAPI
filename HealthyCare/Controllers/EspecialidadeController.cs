﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Dto;


namespace HealthyCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly Projeto.Data.Interfaces.IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(
            Projeto.Data.Interfaces.IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }



        [HttpGet]
        [Route("api/Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Projeto.Data.Dto.EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar()
        {
            try
            {
                List<EspecialidadeDto> resultado = _especialidadeRepository.Listar();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projeto.Data.Dto.EspecialidadeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                EspecialidadeDto resultado = _especialidadeRepository.Consultar(id);

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
        public IActionResult Cadastrar(EspecialidadeDto cadastrarDto)
        {
            if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.Nome))
                return NoContent();

            _especialidadeRepository.Cadastrar(cadastrarDto);

            return BadRequest();
        }

        [HttpPatch]
        [Route("api/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(EspecialidadeDto cadastrarDto)
        {
            if (cadastrarDto == null || String.IsNullOrEmpty(cadastrarDto.Nome))
                return NoContent();

            _especialidadeRepository.Atualizar(cadastrarDto);

            return BadRequest();
        }

        [HttpDelete]
        [Route("api/Excluir")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            if (id < 1)
                return NoContent();

            _especialidadeRepository.Excluir(id);

            return BadRequest();
        }
    }
}
