using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe um e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe uma senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
