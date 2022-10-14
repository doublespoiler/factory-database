using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.Models
{
    public class MechanicMachine
    {
      public int MechanicMachineId { get; set; }
      public int MechanicId { get; set; }
      public int MachineId { get; set; }
      public virtual Machine machine { get; set; }
      public virtual Mechanic mechanic { get; set; }
    }
}