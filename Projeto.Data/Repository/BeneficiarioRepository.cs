using Projeto.Data.Context;
using Projeto.Data.Interfaces;
using Projeto.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Projeto.Data.Repository
{
    public class BeneficiarioRepository : IBeneficiarioRepository
    {
        private readonly Context.DataBaseContext _context;

        public BeneficiarioRepository(Context.DataBaseContext context)
        {
            _context = context;
        }

        public List<Dto.BeneficiarioDto>Listar()
        {
            return (from t in _context.Beneficiarios
                    select new Dto.BeneficiarioDto()
                    {
                        IdBeneficiario = t.IdBeneficiario,
                        Nome = t.Nome,
                        Cpf = t.Cpf,
                        Telefone = t.Telefone,
                        Endereco = t.Endereco,
                        NumeroCarteirinha = t.NumeroCarteirinha,
                        Ativo = t.Ativo,
                        Email = t.Email,
                        Senha = t.Senha

                    }).ToList();
        }

        public BeneficiarioDto Consultar(int id)
        {
            return (from t in _context.Beneficiarios
                    where t.IdBeneficiario == id
                    select new Dto.BeneficiarioDto()
                    {
                        IdBeneficiario = t.IdBeneficiario,
                        Nome = t.Nome,
                        Cpf = t.Cpf,
                        Telefone = t.Telefone,
                        Endereco = t.Endereco,
                        NumeroCarteirinha = t.NumeroCarteirinha,
                        Ativo = t.Ativo,
                        Email = t.Email,
                        Senha = t.Senha

                    })
                    ?.FirstOrDefault()
                    ?? new BeneficiarioDto();
        }

        public int Cadastrar(BeneficiarioDto cadastrarDto)
        {
            Modelos.Beneficiario beneficiarioModelos = new Modelos.Beneficiario()
            {
                Nome = cadastrarDto.Nome,
                Cpf = cadastrarDto.Cpf,
                Telefone = cadastrarDto.Telefone,
                Endereco = cadastrarDto.Endereco,
                NumeroCarteirinha = cadastrarDto.NumeroCarteirinha,
                Ativo = cadastrarDto.Ativo,
                Email = cadastrarDto.Email,
                Senha = cadastrarDto.Senha
            };

            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Add(beneficiarioModelos);
            return _context.SaveChanges();
        }  
        
        public int Atualizar(BeneficiarioDto cadastrarDto)
        {
            Modelos.Beneficiario benefiarioModeloBanco =
                (from c in _context.Beneficiarios
                 where c.IdBeneficiario == cadastrarDto.IdBeneficiario
                 select c)
                 ?.FirstOrDefault()
                 ?? new Modelos.Beneficiario();

            if (benefiarioModeloBanco == null || DBNull.Value.Equals(benefiarioModeloBanco.IdBeneficiario) || benefiarioModeloBanco.IdBeneficiario == 0)
            {
                return 0;
            }


            benefiarioModeloBanco.Nome = cadastrarDto.Nome;
            benefiarioModeloBanco.Cpf = cadastrarDto.Cpf;
            benefiarioModeloBanco.Telefone = cadastrarDto.Telefone;
            benefiarioModeloBanco.Endereco = cadastrarDto.Endereco;
            benefiarioModeloBanco.NumeroCarteirinha = cadastrarDto.NumeroCarteirinha;
            benefiarioModeloBanco.Ativo = cadastrarDto.Ativo;
            benefiarioModeloBanco.Email = cadastrarDto.Email;
            benefiarioModeloBanco.Senha = cadastrarDto.Senha;
           

            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Update(benefiarioModeloBanco);
            return _context.SaveChanges();
        }

        public int Excluir(int Id)
        {
            Modelos.Beneficiario beneficiarioModeloBanco =
                (from c in _context.Beneficiarios
                 where c.IdBeneficiario == Id
                 select c).FirstOrDefault();

            if (beneficiarioModeloBanco == null || DBNull.Value.Equals(beneficiarioModeloBanco.IdBeneficiario) || beneficiarioModeloBanco.IdBeneficiario == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Remove(beneficiarioModeloBanco);
            return _context.SaveChanges();
        }
    }
}
    

