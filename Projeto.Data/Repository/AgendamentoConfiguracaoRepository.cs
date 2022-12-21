using Projeto.Data.Context;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class AgendamentoConfiguracaoRepository
    {
        private readonly DataBaseContext context;

        public AgendamentoConfiguracaoRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<AgendamentoConfiguracao> Listar()
        {

            return context.AgendamentoConfiguracaos.ToList();
        }

        public AgendamentoConfiguracao Consultar(int id)
        {
            return context.AgendamentoConfiguracaos.Find(id);
        }


        public void Inserir(AgendamentoConfiguracao agendamentoConfiguracao)
        {
            context.AgendamentoConfiguracaos.Add(agendamentoConfiguracao);
            context.SaveChanges();
        }

        public void Alterar(AgendamentoConfiguracao agendamentoConfiguracao)
        {
            context.AgendamentoConfiguracaos.Update(agendamentoConfiguracao);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var agendamentoConfiguracao = new AgendamentoConfiguracao()
            {
                IdConfiguracao = id
            };

            context.AgendamentoConfiguracaos.Remove(agendamentoConfiguracao);
            context.SaveChanges();
        }
    }
}
