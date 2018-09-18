using System.ComponentModel.DataAnnotations;

namespace ClinicaVivaEstetica.WebApp.Models
{
    public class CreateCustomerRequest
    {
        [Required(ErrorMessage = "O Nome do cliente é obrigatório.")]
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "O Documento do cliente é obrigatório.")]
        public string Document { get; set; }
        [Required(ErrorMessage = "O Celular do cliente é obrigatório.")]
        public string Celphone { get; set; }
        public string Address { get; set; }
    }
}
