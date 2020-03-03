using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositories;

namespace Senai.Inlock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            // Verifica se algum funcionário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Caso seja, retorna os dados buscados e um status code 200 - Ok
                return Ok(tipoUsuarioBuscado);
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum tipo de usuário encontrado para o identificador informado");
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoTipoUsuario)
        {
            if (novoTipoUsuario.Titulo == null)
            {
                return BadRequest("O nome para o tipo é obrigatório");
            }
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return Created("http://localhost:5000/api/TipoUsuario", novoTipoUsuario);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                    return NoContent();
                }
                catch(Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
                (
                    new
                    {
                        mensagem = "Tipo Usuario não encontrado",
                        erro = true
                    }
                );
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                _tipoUsuarioRepository.Deletar(id);

                return Ok($"O tipo de usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum tipo de usuario encontrado");

        }
    }
}