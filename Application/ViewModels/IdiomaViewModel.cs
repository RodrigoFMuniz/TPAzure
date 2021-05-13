using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class IdiomaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Idioma deve ser preenchido")]
        [DisplayName("Idioma")]
        public string NomeIdioma { get; set; }
        [DisplayName("País")]
        public PaisViewModel Pais { get; set; }
        public int PaisId { get; set; }
    }
}
