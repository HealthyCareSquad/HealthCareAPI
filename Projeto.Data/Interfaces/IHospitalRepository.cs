using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Interfaces

{
    public interface IHospitalRepository
    {
        List<Dto.HospitalDto> Listar();

        Dto.HospitalDto Consultar(int id);

        int Cadastrar(Dto.HospitalDto cadastrarDto);

        int Atualizar(Dto.HospitalDto cadastrarDto);

        int Excluir(int Id);
    }
}
