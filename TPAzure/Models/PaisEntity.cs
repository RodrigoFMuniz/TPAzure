using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TPAzure.Models
{
    public class PaisEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Data de independência")]
        public DateTime DataIndependencia { get; set; }
        [DisplayName("Quantidade de Habitantes")]
        public int QtdHabitantes { get; set; }

        [DisplayName("Bandeira")]
        public string ImageUri { get; set; }

        public List<IdiomaEntity> Idiomas { get; set; }
    }
}
