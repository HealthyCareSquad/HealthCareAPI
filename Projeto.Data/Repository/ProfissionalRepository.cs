using Projeto.Data.Context;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class ProfissionalRepository
    {
        private readonly DataBaseContext context;

        public ProfissionalRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<Profissional> Listar()
        {

            return context.Profissionals.ToList();
        }

        public Profissional Consultar(int id)
        {
            return context.Profissionals.Find(id);
        }


        public void Inserir(Profissional profissional)
        {
            context.Profissionals.Add(profissional);
            context.SaveChanges();
        }

        public void Alterar(Profissional profissional)
        {
            context.Profissionals.Update(profissional);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var profissional = new Profissional()
            {
                IdProfissional = id
            };

            context.Profissionals.Remove(profissional);
            context.SaveChanges();
        }
    }
}
