using Projeto.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces

{
    public interface IBeneficiarioRepository
    {
        List<Dto.BeneficiarioDto> Listar();

        Dto.BeneficiarioDto Consultar(int id);

        int Cadastrar(Dto.BeneficiarioDto cadastrarDto);

        int Atualizar(Dto.BeneficiarioDto cadastrarDto);

        int Excluir(int Id);
    }
}

