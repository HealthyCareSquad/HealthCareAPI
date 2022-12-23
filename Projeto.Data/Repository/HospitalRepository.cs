using Projeto.Data.Context;
using Projeto.Data.Dto;
using Projeto.Data.Interfaces;
using Projeto.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly Context.DataBaseContext _context;

        public HospitalRepository(Context.DataBaseContext context)
        {
            _context = context;
        }

        public List<Dto.HospitalDto> Listar()
        {
            return (from t in _context.Hospitals
                    select new Dto.HospitalDto()
                    {
                        IdHospital = t.IdHospital,
                        Nome = t.Nome,
                        Cnpj = t.Cnpj,
                        Endereco = t.Endereco,
                        Telefone = t.Telefone,
                        Cnes = t.Cnes,
                        Ativo = t.Ativo


                    }).ToList();
        }

        public HospitalDto Consultar(int id)
        {
            return (from t in _context.Hospitals
                    where t.IdHospital == id
                    select new Dto.HospitalDto()
                    {
                        IdHospital = t.IdHospital,
                        Nome = t.Nome,
                        Cnpj = t.Cnpj,
                        Endereco = t.Endereco,
                        Telefone = t.Telefone,
                        Cnes = t.Cnes,
                        Ativo = t.Ativo
                    })
                    ?.FirstOrDefault()
                    ?? new HospitalDto();
        }

        public int Cadastrar(HospitalDto cadastrarDto)
        {
            Modelos.Hospital hospitalModelos = new Modelos.Hospital()
            {
                IdHospital = cadastrarDto.IdHospital,
                Nome = cadastrarDto.Nome,
                Cnpj = cadastrarDto.Cnpj,
                Endereco = cadastrarDto.Endereco,
                Telefone = cadastrarDto.Telefone,
                Cnes = cadastrarDto.Cnes,
                Ativo = cadastrarDto.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Hospitals.Add(hospitalModelos);
            return _context.SaveChanges();
        }

        public int Atualizar(HospitalDto cadastrarDto)
        {
            Modelos.Hospital hospitalModeloBanco =
                (from c in _context.Hospitals
                 where c.IdHospital == cadastrarDto.IdHospital
                 select c)
                 ?.FirstOrDefault()
                 ?? new Modelos.Hospital();

            if (hospitalModeloBanco == null || DBNull.Value.Equals(hospitalModeloBanco.IdHospital) || hospitalModeloBanco.IdHospital == 0)
            {
                return 0;
            }


            hospitalModeloBanco.IdHospital = cadastrarDto.IdHospital;
            hospitalModeloBanco.Nome = cadastrarDto.Nome;
            hospitalModeloBanco.Cnpj = cadastrarDto.Cnpj;
            hospitalModeloBanco.Endereco = cadastrarDto.Endereco;
            hospitalModeloBanco.Telefone = cadastrarDto.Telefone;
            hospitalModeloBanco.Cnes = cadastrarDto.Cnes;
            hospitalModeloBanco.Ativo = cadastrarDto.Ativo;
            

            _context.ChangeTracker.Clear();
            _context.Hospitals.Update(hospitalModeloBanco);
            return _context.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Modelos.Hospital hospitalModeloBanco =
                (from c in _context.Hospitals
                 where c.IdHospital == Id
                 select c).FirstOrDefault();

            if (hospitalModeloBanco == null || DBNull.Value.Equals(hospitalModeloBanco.IdHospital) || hospitalModeloBanco.IdHospital == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Hospitals.Remove(hospitalModeloBanco);
            return _context.SaveChanges();
        }
    }
}
