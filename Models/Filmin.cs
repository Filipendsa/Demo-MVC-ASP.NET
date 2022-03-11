using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMVC.Models
{
    public class Filmin
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Título é Obrigatório")]
        [StringLength(60, MinimumLength =3, ErrorMessage ="O Título Precisa Ter Entre 3 á 60 Caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Data é Obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage ="Data Inserida com Formato Incorreto")]
        [Display(Name ="Data de Lançamento")]
        public DateTime DateLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage ="Genero em Formato Inválido")]
        [StringLength(30, ErrorMessage = "Máximo de 30 Caracteres."), Required(ErrorMessage = "O campo Genero é Obrigatório")]
        public string Genero { get; set; }

        [Range(1,1000, ErrorMessage ="Valor de 1 a 1000")]
        [Required(ErrorMessage = "O campo Valor é Obrigatório")]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Valor { get; set; }

        [RegularExpression(@"^[0-5]*$", ErrorMessage ="Somente Números"), Required(ErrorMessage = "O campo Avaliação é Obrigatório")]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }

    }
}
