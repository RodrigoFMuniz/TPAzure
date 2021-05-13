using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model.Models
{
    public class IdiomaEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Idioma deve ser preenchido")]
        [DisplayName("Idioma")]
        public string NomeIdioma { get; set; }
        [DisplayName("País")]
        public PaisEntity Pais { get; set; }
        public int PaisId { get; set; }
    }
}
