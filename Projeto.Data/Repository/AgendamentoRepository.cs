using Projeto.Data.Context;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly Context.DataBaseContext _context;

        public AgendamentoRepository(Context.DataBaseContext context)
        {
            _context = context;
        }

        public List<Dto.AgendamentoDto> Listar()
        {
            return (from t in _context.Agendamentos
                    select new Dto.AgendamentoDto()
                    {
                        IdAgendamento = t.IdAgendamento,
                        IdHospital = t.IdHospital,
                        IdEspecialidade = t.IdEspecialidade,
                        IdProfissional = t.IdProfissional,
                        DataHoraAgendamento = t.DataHoraAgendamento,
                        IdBeneficiario = t.IdBeneficiario,
                        Ativo = t.Ativo

                    }).ToList();
        }

        public AgendamentoDto Consultar(int id)
        {
            return (from t in _context.Agendamentos
                    where t.IdAgendamento == id
                    select new Dto.AgendamentoDto()
                    {
                        IdAgendamento = t.IdAgendamento,
                        IdHospital = t.IdHospital,
                        IdEspecialidade = t.IdEspecialidade,
                        IdProfissional = t.IdProfissional,
                        DataHoraAgendamento = t.DataHoraAgendamento,
                        IdBeneficiario = t.IdBeneficiario,
                        Ativo = t.Ativo

                    })
                    ?.FirstOrDefault()
                    ?? new AgendamentoDto();
        }

        public int Cadastrar(AgendamentoDto cadastrarDto)
        {
            Modelos.Agendamento agendamentoModelos = new Modelos.Agendamento()
            {
                IdAgendamento = cadastrarDto.IdAgendamento,
                IdHospital = cadastrarDto.IdHospital,
                IdEspecialidade = cadastrarDto.IdEspecialidade,
                IdProfissional = cadastrarDto.IdProfissional,
                DataHoraAgendamento = cadastrarDto.DataHoraAgendamento,
                IdBeneficiario = cadastrarDto.IdBeneficiario,
                Ativo = cadastrarDto.Ativo
            };

            _context.ChangeTracker.Clear();
            _context.Agendamentos.Add(agendamentoModelos);
            return _context.SaveChanges();
        }

        public int Atualizar(AgendamentoDto cadastrarDto)
        {
            Modelos.Agendamento agendamentoModeloBanco =
                (from c in _context.Agendamentos
                 where c.IdAgendamento == cadastrarDto.IdAgendamento
                 select c)
                 ?.FirstOrDefault()
                 ?? new Modelos.Agendamento();

            if (agendamentoModeloBanco == null || DBNull.Value.Equals(agendamentoModeloBanco.IdAgendamento) || agendamentoModeloBanco.IdAgendamento == 0)
            {
                return 0;
            }


            agendamentoModeloBanco.IdAgendamento = cadastrarDto.IdAgendamento;
            agendamentoModeloBanco.IdHospital = cadastrarDto.IdHospital;
            agendamentoModeloBanco.IdEspecialidade = cadastrarDto.IdEspecialidade;
            agendamentoModeloBanco.IdProfissional = cadastrarDto.IdProfissional;
            agendamentoModeloBanco.DataHoraAgendamento = cadastrarDto.DataHoraAgendamento;
            agendamentoModeloBanco.IdBeneficiario = cadastrarDto.IdBeneficiario;
           

            _context.ChangeTracker.Clear();
            _context.Agendamentos.Update(agendamentoModeloBanco);
            return _context.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Modelos.Agendamento agendamentoModeloBanco =
                (from c in _context.Agendamentos
                 where c.IdAgendamento == Id
                 select c).FirstOrDefault();

            if (agendamentoModeloBanco == null || DBNull.Value.Equals(agendamentoModeloBanco.IdAgendamento) || agendamentoModeloBanco.IdAgendamento  == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Agendamentos.Remove(agendamentoModeloBanco);
            return _context.SaveChanges();
        }
    }
}
