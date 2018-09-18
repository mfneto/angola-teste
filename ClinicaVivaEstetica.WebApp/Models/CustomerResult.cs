using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVivaEstetica.WebApp.Models
{
    public class CustomerResult
    {
        public Guid? CustomerId { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome do cliente é obrigatório.")]
        public string Name { get; set; }

        [DisplayName("Sobrenome")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "O Documento do cliente é obrigatório.")]

        [DisplayName("Documento")]
        public string Document { get; set; }

        [DisplayName("Celular")]
        [Required(ErrorMessage = "O Celular do cliente é obrigatório.")]
        public string Celphone { get; set; }

        [DisplayName("Endereço")]
        public string Address { get; set; }
    }
}