using Projeto.Data.Context;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class DadosBancarioRepository
    {
        private readonly DataBaseContext context;

        public DadosBancarioRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<DadosBancario> Listar()
        {

            return context.DadosBancarios.ToList();
        }

        public DadosBancario Consultar(int id)
        {
            return context.DadosBancarios.Find(id);
        }


        public void Inserir(DadosBancario dadosBancario)
        {
            context.DadosBancarios.Add(dadosBancario);
            context.SaveChanges();
        }

        public void Alterar(DadosBancario dadosBancarios)
        {
            context.DadosBancarios.Update(dadosBancarios);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var dadosBancario = new DadosBancario()
            {
                IdDadosBancarios = id
            };

            context.DadosBancarios.Remove(dadosBancario);
            context.SaveChanges();
        }
    }
}
