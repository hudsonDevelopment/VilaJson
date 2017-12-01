using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VilaAnimalJson.Models
{
    public class Usuario
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        //[StringLength(100, ErrorMessage = "ONomedeveterentre1e100caracteres")]
        public string Nome{get;set;}

        [Required(ErrorMessage = "Digite o email")]
        public float Pontuação{get;set;}

        [Required(ErrorMessage = "Digite o endereço")]
        public string Tempo{get;set;}
    }
}