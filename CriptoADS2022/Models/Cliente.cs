using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CriptoADS2022.Models
{
    public enum Estado {RS, SC, PR, SP, MG, GO, MS, MT}

    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage ="Campo nome é obrigatório")]
        [Display(Name ="Nome: ")]
        public string nome { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage ="Campo cidade é obrigatório")]
        [Display(Name ="Cidade: ")]
        public string cidade { get; set; }

        [Required(ErrorMessage ="Estado é obrigatório")]
        [Display(Name ="Estado: ")]
        public Estado estado { get; set; }

        [Display(Name ="Idade: ")]
        [Range(18, 100, ErrorMessage = "Idade entre 18...100")]
        public int idade { get; set; }
    }
}
