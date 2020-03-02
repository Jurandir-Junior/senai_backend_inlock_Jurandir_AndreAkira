using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(int id);

        void Cadastrar(EstudioDomain novoEstudio);

        void Atualizar(int id, EstudioDomain estudioAtualizado);

        void Deletar(int id);
    }
}
