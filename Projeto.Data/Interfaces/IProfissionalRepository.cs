using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces

{
    public interface IProfissionalRepository
    {
        List<Dto.ProfissionalDto> Listar();

        Dto.ProfissionalDto Consultar(int id);

        int Cadastrar(Dto.ProfissionalDto cadastrarDto);

        int Atualizar(Dto.ProfissionalDto cadastrarDto);

        int Excluir(int Id);
    }
}
