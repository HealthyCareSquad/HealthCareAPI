using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces
{
    public interface IAgendamentoConfiguracaoRepository
    {
        List<Dto.AgendamentoConfiguracaoDto> Listar();

        Dto.AgendamentoConfiguracaoDto Consultar(int id);

        int Cadastrar(Dto.AgendamentoConfiguracaoDto cadastrarDto);

        int Atualizar(Dto.AgendamentoConfiguracaoDto cadastrarDto);

        int Excluir(int Id);
    }
}
