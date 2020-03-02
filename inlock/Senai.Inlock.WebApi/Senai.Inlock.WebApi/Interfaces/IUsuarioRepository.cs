using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> Listar();

        UsuarioDomain BuscarPorId(int id);

        void Cadastrar(UsuarioDomain novoUsuario);

        void Atualizar(int id, UsuarioDomain usuarioAtualizado);

        void Deletar(int id);
    }
}
