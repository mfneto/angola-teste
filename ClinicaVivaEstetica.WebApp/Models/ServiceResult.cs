using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVivaEstetica.WebApp.Models
{
    public class ServiceResult
    {
        public Guid? ServiceId { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome do serviço é obrigatório.")]
        public string Name { get; set; }

        [DisplayName("Permiir agendamento na metade do tempo?")]
        public bool AllowHalfTime { get; set; }
        
    }
}