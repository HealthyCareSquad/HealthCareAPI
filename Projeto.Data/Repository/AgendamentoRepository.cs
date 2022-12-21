using Projeto.Data.Context;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class AgendamentoRepository
    {
        private readonly DataBaseContext context;

        public AgendamentoRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<Agendamento> Listar()
        {

            return context.Agendamentos.ToList();
        }

        public Agendamento Consultar(int id)
        {
            return context.Agendamentos.Find(id);
        }


        public void Inserir(Agendamento agendamento)
        {
            context.Agendamentos.Add(agendamento);
            context.SaveChanges();
        }

        public void Alterar(Agendamento agendamento)
        {
            context.Agendamentos.Update(agendamento);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var agendamento = new Agendamento()
            {
                IdAgendamento = id
            };

            context.Agendamentos.Remove(agendamento);
            context.SaveChanges();
        }
    }
}
