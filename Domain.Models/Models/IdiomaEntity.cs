using System.ComponentModel;

namespace Domain.Model.Models
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
