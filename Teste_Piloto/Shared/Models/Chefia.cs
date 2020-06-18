using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faculdade_FUP_Project.Server.Models
{
    public class Chefia
    {
        public int ChefiaId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeChefia { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone deve ser informado.!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Forneça o número do telefone no formato (000) 000-0000")]
        [DisplayName("Número do Telefone")]
        public string Telefone { get; set; }

        [InverseProperty("Chefia")]
        //public int FuncionarioId { get; set; }
        [ForeignKey("Funcionario")]
        public virtual List<Funcionario> Funcionarios { get; set; }

     
    }
}
