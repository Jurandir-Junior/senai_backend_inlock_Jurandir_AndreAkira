using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> Listar();

        TipoUsuarioDomain BuscarPorId(int id);

        void Cadastrar(TipoUsuarioDomain novoTipoUsuario);

        void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado);

        void Deletar(int id);
    }
}
