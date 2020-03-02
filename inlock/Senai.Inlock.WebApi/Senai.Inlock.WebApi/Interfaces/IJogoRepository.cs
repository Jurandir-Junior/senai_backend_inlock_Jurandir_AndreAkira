using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar();

        JogoDomain BuscarPorId(int id);

        void Cadastrar(JogoDomain novoJogo);

        void Atualizar(int id, JogoDomain jogoAtualizado);

        void Deletar(int id);
    }
}
