using Projeto.Data.Context;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class DadosBancarioRepository : IDadosBancarioRepository
    {
        private readonly Context.DataBaseContext _context;

        public DadosBancarioRepository(Context.DataBaseContext context)
        {
            _context = context;
        }

        public List<Dto.DadosBancarioDto> Listar()
        {
            return (from t in _context.DadosBancarios
                    select new Dto.DadosBancarioDto()
                    {
                        IdDadosBancarios = t.IdDadosBancarios,
                        NumeroBanco = t.NumeroBanco,
                        CodigoPix = t.CodigoPix,
                        Agencia = t.Agencia,
                        NumeroConta = t.NumeroConta,
                        Poupanca = t.Poupanca,
                        IdProfissional = t.IdProfissional
                    }).ToList();
        }

        public DadosBancarioDto Consultar(int id)
        {
            return (from t in _context.DadosBancarios
                    where t.IdDadosBancarios == id
                    select new Dto.DadosBancarioDto()
                    {
                        IdDadosBancarios = t.IdDadosBancarios,
                        NumeroBanco = t.NumeroBanco,
                        CodigoPix = t.CodigoPix,
                        Agencia = t.Agencia,
                        NumeroConta = t.NumeroConta,
                        Poupanca = t.Poupanca,
                        IdProfissional = t.IdProfissional

                    })
                    ?.FirstOrDefault()
                    ?? new DadosBancarioDto();
        }

        public int Cadastrar(DadosBancarioDto cadastrarDto)
        {
            Modelos.DadosBancario dadosBancarioModelos = new Modelos.DadosBancario()
            {
                IdDadosBancarios = cadastrarDto.IdDadosBancarios,
                NumeroBanco = cadastrarDto.NumeroBanco,
                CodigoPix = cadastrarDto.CodigoPix,
                Agencia = cadastrarDto.Agencia,
                NumeroConta = cadastrarDto.NumeroConta,
                Poupanca = cadastrarDto.Poupanca,
                IdProfissional = cadastrarDto.IdProfissional,
            };

            _context.ChangeTracker.Clear();
            _context.DadosBancarios.Add(dadosBancarioModelos);
            return _context.SaveChanges();
        }

        public int Atualizar(DadosBancarioDto cadastrarDto)
        {
            Modelos.DadosBancario dadosBancarioModeloBanco =
                (from c in _context.DadosBancarios
                 where c.IdDadosBancarios == cadastrarDto.IdDadosBancarios
                 select c)
                 ?.FirstOrDefault()
                 ?? new Modelos.DadosBancario();

            if (dadosBancarioModeloBanco == null || DBNull.Value.Equals(dadosBancarioModeloBanco.IdDadosBancarios) || dadosBancarioModeloBanco.IdDadosBancarios == 0)
            {
                return 0;
            }

            dadosBancarioModeloBanco.IdDadosBancarios = cadastrarDto.IdDadosBancarios;
            dadosBancarioModeloBanco.NumeroBanco = cadastrarDto.NumeroBanco;
            dadosBancarioModeloBanco.CodigoPix = cadastrarDto.CodigoPix;
            dadosBancarioModeloBanco.Agencia = cadastrarDto.Agencia;
            dadosBancarioModeloBanco.NumeroConta = cadastrarDto.NumeroConta;
            dadosBancarioModeloBanco.Poupanca = cadastrarDto.Poupanca;
            dadosBancarioModeloBanco.IdProfissional = cadastrarDto.IdProfissional;

            _context.ChangeTracker.Clear();
            _context.DadosBancarios.Update(dadosBancarioModeloBanco);
            return _context.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Modelos.DadosBancario dadosBancarioModeloBanco =
                (from c in _context.DadosBancarios
                 where c.IdDadosBancarios == Id
                 select c).FirstOrDefault();

            if (dadosBancarioModeloBanco == null || DBNull.Value.Equals(dadosBancarioModeloBanco.IdDadosBancarios) || dadosBancarioModeloBanco.IdDadosBancarios == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.DadosBancarios.Remove(dadosBancarioModeloBanco);
            return _context.SaveChanges();
        }
    }
}
    

