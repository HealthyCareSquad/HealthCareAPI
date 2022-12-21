using Projeto.Data.Context;
using Projeto.Data.Modelos;

namespace Projeto.Data.Repository
{
    public class BeneficiarioRepository
    {
        private readonly DataBaseContext context;

        public BeneficiarioRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<Beneficiario> Listar()
        {

            return context.Beneficiarios.ToList();
        }

        public Beneficiario Consultar(int id)
        {
            return context.Beneficiarios.Find(id);
        }


        public void Inserir(Beneficiario beneficiario)
        {
            context.Beneficiarios.Add(beneficiario);
            context.SaveChanges();
        }

        public void Alterar(Beneficiario beneficiario)
        {
            context.Beneficiarios.Update(beneficiario);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var beneficiario = new Beneficiario()
            {
                IdBeneficiario = id
            };

            context.Beneficiarios.Remove(beneficiario);
            context.SaveChanges();
        }
    }
}
    

