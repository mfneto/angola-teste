using System.Collections.Generic;

namespace ClinicaVivaEstetica.Domain
{
    using System;

    public class ClinicaVivaEsteticaException : Exception
    {
        public List<String> Messages { get; set; }

        public String Orign { get; set; }

        public Boolean IsError { get; set; }

        public ClinicaVivaEsteticaException()
        { }

        public ClinicaVivaEsteticaException(String message, String orign = null, Boolean isError = true)
            : base(message)
        {
            IsError = isError;
            Orign = orign;
        }

        public ClinicaVivaEsteticaException(String message, Exception innerException, String orign)
            : base(message, innerException)
        {
            Orign = orign;
            Messages = Messages ?? new List<string>();

            Messages.Add(message);
            Messages.Add(innerException?.Message ?? "");
        }

        public ClinicaVivaEsteticaException(String message, List<String> detailsFromMessage, String orign = null) : base(message)
        {
            this.Messages = detailsFromMessage;
            this.Orign = orign;
        }
    }
}