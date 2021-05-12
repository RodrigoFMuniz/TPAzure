using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.ViewModels
{
    public class IdiomaViewModel
    {
        public int Id { get; set; }
        [DisplayName("Idioma")]
        public string NomeIdioma { get; set; }
        public PaisViewModel Pais { get; set; }
        public int PaisId { get; set; }
    }
}
