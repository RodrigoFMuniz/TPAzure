using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TPAzure.Models
{
    public class IdiomaEntity
    {
        public int Id { get; set; }
        [DisplayName("Idioma")]
        public string NomeIdioma { get; set; }
        public PaisEntity Pais { get; set; }
        public int PaisId { get; set; }
    }
}
