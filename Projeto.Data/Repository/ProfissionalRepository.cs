using Projeto.Data.Context;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly Context.DataBaseContext _context;

        public ProfissionalRepository(Context.DataBaseContext context)
        {
            _context = context;
        }

        public List<Dto.ProfissionalDto> Listar()
        {
            return (from t in _context.Profissionals
                    select new Dto.ProfissionalDto()
                    {
                        IdProfissional = t.IdProfissional,
                        Nome = t.Nome,
                        Telefone = t.Telefone,
                        Endereco = t.Endereco,
                        Ativo = t.Ativo
                    }).ToList();
        }

        public ProfissionalDto Consultar(int id)
        {
            return (from t in _context.Profissionals
                    where t.IdProfissional == id
                    select new Dto.ProfissionalDto()
                    {
                        IdProfissional = t.IdProfissional,
                        Nome = t.Nome,
                        Telefone = t.Telefone,
                        Endereco = t.Endereco,
                        Ativo = t.Ativo
                    })
                    ?.FirstOrDefault()
                    ?? new ProfissionalDto();
        }

        public int Cadastrar(ProfissionalDto cadastrarDto)
        {
            Modelos.Profissional profissionalModelos = new Modelos.Profissional()
            {
                IdProfissional = cadastrarDto.IdProfissional,
                Nome = cadastrarDto.Nome,
                Endereco = cadastrarDto.Endereco,
                Telefone = cadastrarDto.Telefone,
                Ativo = cadastrarDto.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Profissionals.Add(profissionalModelos);
            return _context.SaveChanges();
        }

        public int Atualizar(ProfissionalDto cadastrarDto)
        {
            Modelos.Profissional professionalModeloBanco =
                (from c in _context.Profissionals
                 where c.IdProfissional == cadastrarDto.IdProfissional
                 select c)
                 ?.FirstOrDefault()
                 ?? new Modelos.Profissional();

            if (professionalModeloBanco == null || DBNull.Value.Equals(professionalModeloBanco.IdProfissional) || professionalModeloBanco.IdProfissional == 0)
            {
                return 0;
            }

            professionalModeloBanco.IdProfissional = cadastrarDto.IdProfissional;
            professionalModeloBanco.Nome = cadastrarDto.Nome;
            professionalModeloBanco.Endereco = cadastrarDto.Endereco;
            professionalModeloBanco.Telefone = cadastrarDto.Telefone;
            professionalModeloBanco.Ativo = cadastrarDto.Ativo;
            

            _context.ChangeTracker.Clear();
            _context.Profissionals.Update(professionalModeloBanco);
            return _context.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Modelos.Profissional professionalModeloBanco =
                (from c in _context.Profissionals
                 where c.IdProfissional == Id
                 select c).FirstOrDefault();

            if (professionalModeloBanco == null || DBNull.Value.Equals(professionalModeloBanco.IdProfissional) || professionalModeloBanco.IdProfissional == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Profissionals.Remove(professionalModeloBanco);
            return _context.SaveChanges();
        }
    }
}
