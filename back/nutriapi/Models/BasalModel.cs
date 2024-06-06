using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nutriapi.Models
{
    public class BasalModel
    {
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; } // em kg
        public double Altura { get; set; } // em cm
        public string? Sexo { get; set; } // em cm

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int Basal { get; set; }
        [JsonIgnore]
        public DateTime? Date { get; set;}
    }
}
