using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.Models
{
  public class Mechanic
  {
    public Mechanic()
    {
      this.JoinEntities = new HashSet<MechanicMachine>();
    }

    public int MechanicId { get; set; }
    public string MechanicName { get; set; }
    public string MechanicTitle { get; set; }

    public virtual ICollection<MechanicMachine> JoinEntities { get; }
  }
}
