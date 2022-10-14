using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<MechanicMachine>();
    }

    public int MachineId { get; set; }
    public string MachineName { get; set; }
    public string AssetNumber { get; set; }
    public string LocationNumber { get; set; }
    public virtual ICollection<MechanicMachine> JoinEntities { get; }
  }
}