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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            if (novoJogo.NomeJogo == null)
            {
                return BadRequest("O nome do jogo é obrigatório");
            }
            _jogoRepository.Cadastrar(novoJogo);

            return Created("http://localhost:5000/api/Jogo", novoJogo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                return Ok(jogoBuscado);
            }

            return NotFound("Nenhum funcionário encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, JogoDomain jogoAtualizado)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(id, jogoAtualizado);

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
                        mensagem = "Jogo não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                _jogoRepository.Deletar(id);

                return Ok("O jogo foi deletado com sucesso!");
            }

            return NotFound("Nenhum jogo encontrado");
        }
    }
}