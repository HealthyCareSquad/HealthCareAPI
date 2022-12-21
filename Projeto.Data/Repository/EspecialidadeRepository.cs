using Projeto.Data.Context;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class EspecialidadeRepository
    {
        private readonly DataBaseContext context;

        public EspecialidadeRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<Especialidade> Listar()
        {

            return context.Especialidades.ToList();
        }

        public Especialidade Consultar(int id)
        {
            return context.Especialidades.Find(id);
        }


        public void Inserir(Especialidade especialidade)
        {
            context.Especialidades.Add(especialidade);
            context.SaveChanges();
        }

        public void Alterar(Especialidade especialidade)
        {
            context.Especialidades.Update(especialidade);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var especialidade = new Especialidade()
            {
                IdEspecialidade = id
            };

            context.Especialidades.Remove(especialidade);
            context.SaveChanges();
        }
    }
}
