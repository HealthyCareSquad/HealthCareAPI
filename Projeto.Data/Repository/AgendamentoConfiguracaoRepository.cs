using Projeto.Data.Context;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class AgendamentoConfiguracaoRepository : IAgendamentoConfiguracaoRepository
    {
        private readonly Context.DataBaseContext _context;

        public AgendamentoConfiguracaoRepository(Context.DataBaseContext context)
        {
            _context = context;
        }

        public List<Dto.AgendamentoConfiguracaoDto> Listar()
        {
            return (from t in _context.AgendamentoConfiguracaos
                    select new Dto.AgendamentoConfiguracaoDto()
                    {
                        IdConfiguracao = t.IdConfiguracao,
                        IdHospital = t.IdHospital,
                        IdEspecialidade = t.IdEspecialidade,
                        IdProfissional = t.IdProfissional,
                        DataHoraInicioAtendimento = t.DataHoraInicioAtendimento,
                        DataHoraFinalAtendimento = t.DataHoraFinalAtendimento
                    }).ToList();
        }

        public AgendamentoConfiguracaoDto Consultar(int id)
        {
            return (from t in _context.AgendamentoConfiguracaos
                    where t.IdConfiguracao == id
                    select new Dto.AgendamentoConfiguracaoDto()
                    {
                        IdConfiguracao = t.IdConfiguracao,
                        IdHospital = t.IdHospital,
                        IdEspecialidade = t.IdEspecialidade,
                        IdProfissional = t.IdProfissional,
                        DataHoraInicioAtendimento = t.DataHoraInicioAtendimento,
                        DataHoraFinalAtendimento = t.DataHoraFinalAtendimento

                    })
                    ?.FirstOrDefault()
                    ?? new AgendamentoConfiguracaoDto();
        }

        public int Cadastrar(AgendamentoConfiguracaoDto cadastrarDto)
        {
            Modelos.AgendamentoConfiguracao agendamentoConfigModelos = new Modelos.AgendamentoConfiguracao()
            {
                IdConfiguracao = cadastrarDto.IdConfiguracao,
                IdHospital = cadastrarDto.IdHospital,
                IdEspecialidade = cadastrarDto.IdEspecialidade,
                IdProfissional = cadastrarDto.IdProfissional,
                DataHoraInicioAtendimento = cadastrarDto.DataHoraInicioAtendimento,
                DataHoraFinalAtendimento = cadastrarDto.DataHoraFinalAtendimento
             
            };

            _context.ChangeTracker.Clear();
            _context.AgendamentoConfiguracaos.Add(agendamentoConfigModelos);
            return _context.SaveChanges();
        }

        public int Atualizar(AgendamentoConfiguracaoDto cadastrarDto)
        {
            Modelos.AgendamentoConfiguracao agendamentoConfigModeloBanco =
                (from c in _context.AgendamentoConfiguracaos
                 where c.IdConfiguracao == cadastrarDto.IdConfiguracao
                 select c)
                 ?.FirstOrDefault()
                 ?? new Modelos.AgendamentoConfiguracao();

            if (agendamentoConfigModeloBanco == null || DBNull.Value.Equals(agendamentoConfigModeloBanco.IdConfiguracao) || agendamentoConfigModeloBanco.IdConfiguracao == 0)
            {
                return 0;
            }

            agendamentoConfigModeloBanco.IdConfiguracao = cadastrarDto.IdConfiguracao;
            agendamentoConfigModeloBanco.IdHospital = cadastrarDto.IdHospital;
            agendamentoConfigModeloBanco.IdEspecialidade = cadastrarDto.IdEspecialidade;
            agendamentoConfigModeloBanco.IdProfissional = cadastrarDto.IdProfissional;
            agendamentoConfigModeloBanco.DataHoraInicioAtendimento = cadastrarDto.DataHoraInicioAtendimento;
            agendamentoConfigModeloBanco.DataHoraFinalAtendimento = cadastrarDto.DataHoraFinalAtendimento;

            _context.ChangeTracker.Clear();
            _context.AgendamentoConfiguracaos.Update(agendamentoConfigModeloBanco);
            return _context.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Modelos.AgendamentoConfiguracao agendamentoConfigModeloBanco =
                (from c in _context.AgendamentoConfiguracaos
                 where c.IdConfiguracao == Id
                 select c).FirstOrDefault();

            if (agendamentoConfigModeloBanco == null || DBNull.Value.Equals(agendamentoConfigModeloBanco.IdConfiguracao) || agendamentoConfigModeloBanco.IdConfiguracao == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.AgendamentoConfiguracaos.Remove(agendamentoConfigModeloBanco);
            return _context.SaveChanges();
        }
    }
}
