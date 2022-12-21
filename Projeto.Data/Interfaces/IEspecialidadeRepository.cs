using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces

{
    public interface IEspecialidadeRepository
    {
        List<Dto.EspecialidadeDto> Listar();

        Dto.EspecialidadeDto Consultar(int id);

        int Cadastrar(Dto.EspecialidadeDto cadastrarDto);

        int Atualizar(Dto.EspecialidadeDto cadastrarDto);

        int Excluir(int Id);
    }
}
