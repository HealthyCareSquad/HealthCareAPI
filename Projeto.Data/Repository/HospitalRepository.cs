using Projeto.Data.Context;
using Projeto.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repository
{
    public class HospitalRepository
    {
        private readonly DataBaseContext context;

        public HospitalRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<Hospital> Listar()
        {

            return context.Hospitals.ToList();
        }

        public Hospital Consultar(int id)
        {
            return context.Hospitals.Find(id);
        }


        public void Inserir(Hospital hospital)
        {
            context.Hospitals.Add(hospital);
            context.SaveChanges();
        }

        public void Alterar(Hospital hospital)
        {
            context.Hospitals.Update(hospital);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var hospital = new Hospital()
            {
                IdHospital = id
            };

            context.Hospitals.Remove(hospital);
            context.SaveChanges();
        }
    }
}
