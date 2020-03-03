using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        public int IdTipoUsuario { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
