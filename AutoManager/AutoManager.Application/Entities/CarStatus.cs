using System;
using System.Collections.Generic;
using System.Text;

namespace AutoManager2.Application.Entities
{
    public partial class CarStatus
    {
        public byte Id { get; set; }

        public string StatusName { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
