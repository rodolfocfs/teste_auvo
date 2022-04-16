using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaTempoSimples.Model
{
    public class Estado
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Cidade é um campo obrigatório")]
        [StringLength(200, ErrorMessage = "O campo cidade deve ter no máximo 200 caracteres")]

        public string Nome { get; set;}
        [DisplayName("UF")]
        [Required(ErrorMessage = "UF é um campo obrigatório")]
        [StringLength(2, MinimumLength = 2 ,ErrorMessage = "O campo UF deve ter 2 caracteres")]
        [Index(IsUnique = true)]
        public string UF { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}