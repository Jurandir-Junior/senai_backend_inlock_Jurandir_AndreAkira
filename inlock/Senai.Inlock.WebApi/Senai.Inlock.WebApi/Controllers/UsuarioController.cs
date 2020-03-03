using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            if (novoUsuario.Email == null)
            {
                return BadRequest("O email é obrigatório!");
            }
            _usuarioRepository.Cadastrar(novoUsuario);
            
            return Created("http://localhost:5000/api/Usuario", novoUsuario);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            
            if (usuarioBuscado != null)
            {
                return Ok(usuarioBuscado);
            }
            
            return NotFound("Nenhum usuário encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuarioDomain usuarioAtualizado)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            
            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);
                    
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }
            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionário não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UsuarioDomain funcionarioBuscado = _usuarioRepository.BuscarPorId(id);
            
            if (funcionarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);
                
                return Ok($"O usuário {id} foi deletado com sucesso!");
            }
            
            return NotFound("Nenhum usuário encontrado");
        }
    }
}