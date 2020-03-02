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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return Created("http://localhost:5000/api/Estudios", novoEstudio);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if(estudioBuscado != null)
            {
                return Ok(estudioBuscado);
            }
            return NotFound("Nenhum estúdio encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                try
                {
                    _estudioRepository.Atualizar(id, estudioAtualizado);

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
                        mensagem = "Estúdio não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                _estudioRepository.Deletar(id);

                return Ok("Estudio deletado com sucesso!");
            }
            return NotFound("Estudio não encontrado");
        }
    }
}