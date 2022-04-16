using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaTempoSimples.Model
{
    public class Cidade
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Cidade é um campo obrigatório")]
        [StringLength(200, ErrorMessage = "O campo cidade deve ter no máximo 200 caracteres")]
        public string Nome { get; set;}

        [ForeignKey("Estado")]
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<PrevisaoClima> Previsoes { get; set; }
    }
}