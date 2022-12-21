using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces
{
    public interface IAgendamentoRepository
    {
        List<Dto.AgendamentoDto> Listar();

        Dto.AgendamentoDto Consultar(int id);

        int Cadastrar(Dto.AgendamentoDto cadastrarDto);

        int Atualizar(Dto.AgendamentoDto cadastrarDto);

        int Excluir(int Id);
    }
}
