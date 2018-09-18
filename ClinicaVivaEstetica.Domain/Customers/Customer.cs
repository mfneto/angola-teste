using System.Collections;
using System.Collections.Generic;

namespace ClinicaVivaEstetica.Domain.Customers
{
    using System;
    using ClinicaVivaEstetica.Domain.ValueObjects;

    public class Customer : Entity, IAggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual String LastName { get; protected set; }
        public virtual Document Document { get; protected set; }
        public virtual Celphone Celphone { get; protected set; }
        public virtual String Address { get; protected set; }
        
        public Customer(Name name, String lastName, Document document, Celphone celphone, String address)
            : this()
        {
            Name = name;
            LastName = lastName;
            Document = document;
            Celphone = celphone;
            Address = address;
        }

        public Customer(Guid customerId, Name name, String lastName, Document document, Celphone celphone, String address)
            : this()
        {
            Id = customerId;
            Name = name;
            LastName = lastName;
            Document = document;
            Celphone = celphone;
            Address = address;
        }

        public Customer()
        {
        }

        public virtual int Version { get; protected set; }

        public virtual ICollection<Schedule.Schedule> Schedules { get; set; }
    }
}
