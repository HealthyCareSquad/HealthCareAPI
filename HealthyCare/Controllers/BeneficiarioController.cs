using HealthyCare.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HealthyCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiarioController : Controller
    {
        private readonly BeneficiarioRepository beneficiarioRepository;
        public BeneficiarioController()
        {
            beneficiarioRepository = new BeneficiarioRepository();
        }

        [HttpGet]
        [Route("/Consultar")]
        public IActionResult Consultar()
        {
            try
            {
                var listaBeneficiario = beneficiarioRepository.Listar();
                return Ok(listaBeneficiario);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/Consultar/{id}")]
        public ActionResult Consultar(int id)
        {
            try
            {
                var beneficiario = beneficiarioRepository.Consultar(id);
                if (beneficiario.IdBeneficiario != 0)
                {
                    return Ok(beneficiario);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        [Route("/Cadastrar")]
        public ActionResult Cadastrar(Modelos.Beneficiario beneficiario)
        {
            try
            {
                beneficiarioRepository.Inserir(beneficiario);
                return Ok(beneficiario);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("/Editar")]
        public ActionResult Editar(Modelos.Beneficiario beneficiario)
        {
            try
            {
                beneficiarioRepository.Alterar(beneficiario);
                return Ok(beneficiario);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/Excluir/{id}")]
        public ActionResult Excluir(int id)
        {

            try
            {
                beneficiarioRepository.Excluir(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
