using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces

{
    public interface IDadosBancarioRepository
    {
        List<Dto.DadosBancarioDto> Listar();

        Dto.DadosBancarioDto Consultar(int id);

        int Cadastrar(Dto.DadosBancarioDto cadastrarDto);

        int Atualizar(Dto.DadosBancarioDto cadastrarDto);

        int Excluir(int Id);
    }
}
