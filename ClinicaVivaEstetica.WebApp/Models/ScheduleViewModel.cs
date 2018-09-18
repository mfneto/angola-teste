using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClinicaVivaEstetica.WebApp.Models
{
    public class ScheduleViewModel
    {
        public Guid? ScheduleId { get; set; }

        [DisplayName("Dia")]
        [Required(ErrorMessage = "O Dia de agendamento do serviço é obrigatório.")]
        public DateTime? Day { get; set; }

        [DisplayName("Horário")]
        [Required(ErrorMessage = "O Horário de agendamento do serviço é obrigatório.")]
        public TimeSpan? Hour { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O Cliente do agendamento do serviço é obrigatório.")]
        public Guid? CustomerId { get; set; }

        [DisplayName("Serviço")]
        [Required(ErrorMessage = "O Serviço do agendamento é obrigatório.")]
        public Guid? ServiceId { get; set; }

        public CustomerResult Customer { get; set; }
        public ServiceResult Service { get; set; }

        public List<ServiceResult> Services { get; set; }

    }
}