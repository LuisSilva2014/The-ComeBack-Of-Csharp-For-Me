using System;
using System.Collections.Generic;
using System.Text;

namespace AutoManager.Application.Entities
{
    public partial class Car
    {
        public Guid Id { get; set; }

        public string Manufacturer { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public byte StatusId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual CarStatus Status { get; set; }
    }
}
