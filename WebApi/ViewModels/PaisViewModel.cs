
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class PaisViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome deve ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de independência deve ser preenchido")]
        [DataType(DataType.Date)]
        [DisplayName("Data de independência")]
        public DateTime DataIndependencia { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de Habitantes deve ser preenchido")]
        [DisplayName("Quantidade de Habitantes")]
        public int QtdHabitantes { get; set; }

        [DisplayName("Bandeira")]
        public string ImageUri { get; set; }

        public List<IdiomaViewModel> Idiomas { get; set; }
    }
}
