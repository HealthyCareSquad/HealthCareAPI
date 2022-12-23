using Projeto.Data.Context;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly Context.DataBaseContext _context;

        public EspecialidadeRepository(Context.DataBaseContext context)
        {
            _context = context;
        }

        public List<Dto.EspecialidadeDto> Listar()
        {
            return (from t in _context.Especialidades
                    select new Dto.EspecialidadeDto()
                    {
                        IdEspecialidade = t.IdEspecialidade,
                        Nome = t.Nome,
                        Descricao = t.Descricao,
                        Ativo = t.Ativo
                    }).ToList();
        }

        public EspecialidadeDto Consultar(int id)
        {
            return (from t in _context.Especialidades
                    where t.IdEspecialidade == id
                    select new Dto.EspecialidadeDto()
                    {
                        IdEspecialidade = t.IdEspecialidade,
                        Nome = t.Nome,
                        Descricao = t.Descricao,
                        Ativo = t.Ativo
                    })
                    ?.FirstOrDefault()
                    ?? new EspecialidadeDto();
        }

        public int Cadastrar(EspecialidadeDto cadastrarDto)
        {
            Modelos.Especialidade especialidadeModelos = new Modelos.Especialidade()
            {
                IdEspecialidade = cadastrarDto.IdEspecialidade,
                Nome = cadastrarDto.Nome,
                Descricao = cadastrarDto.Descricao,
                Ativo = cadastrarDto.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Especialidades.Add(especialidadeModelos);
            return _context.SaveChanges();
        }

        public int Atualizar(EspecialidadeDto cadastrarDto)
        {
            Modelos.Especialidade especialidadeModeloBanco =
                (from c in _context.Especialidades
                 where c.IdEspecialidade == cadastrarDto.IdEspecialidade
                 select c)
                 ?.FirstOrDefault()
                 ?? new Modelos.Especialidade();

            if (especialidadeModeloBanco == null || DBNull.Value.Equals(especialidadeModeloBanco.IdEspecialidade) || especialidadeModeloBanco.IdEspecialidade == 0)
            {
                return 0;
            }

            especialidadeModeloBanco.IdEspecialidade = cadastrarDto.IdEspecialidade;
            especialidadeModeloBanco.Nome = cadastrarDto.Nome;
            especialidadeModeloBanco.Descricao = cadastrarDto.Descricao;
            especialidadeModeloBanco.Ativo = cadastrarDto.Ativo;

            _context.ChangeTracker.Clear();
            _context.Especialidades.Update(especialidadeModeloBanco);
            return _context.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Modelos.Especialidade especialidadeModeloBanco =
                (from c in _context.Especialidades
                 where c.IdEspecialidade == Id
                 select c).FirstOrDefault();

            if (especialidadeModeloBanco == null || DBNull.Value.Equals(especialidadeModeloBanco.IdEspecialidade) || especialidadeModeloBanco.IdEspecialidade == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Especialidades.Remove(especialidadeModeloBanco);
            return _context.SaveChanges();
        }
    }
}
