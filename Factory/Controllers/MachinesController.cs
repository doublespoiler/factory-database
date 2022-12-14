using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines.Include(machine => machine.JoinEntities).ThenInclude(join => join.Mechanic).FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, int MechanicId)
    {
      if(MechanicId != 0)
      {
        _db.MechanicMachine.Add(new MechanicMachine() { MechanicId = MechanicId, MachineId = machine.MachineId});
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId});
    }

    public ActionResult AddMechanic(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.MechanicId = new SelectList(_db.Mechanics, "MechanicId", "MechanicName");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddMechanic(Machine machine, int MechanicId)
    {
      if (MechanicId != 0)
      {
        _db.MechanicMachine.Add(new MechanicMachine() {MechanicId = MechanicId, MachineId = machine.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = machine.MachineId});
    }

    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      List<MechanicMachine> thisMachineJoins = _db.MechanicMachine.ToList();
      foreach(MechanicMachine mm in thisMachineJoins)
      {
        if(mm.MachineId == id)
        {
          _db.MechanicMachine.Remove(mm);
        }
      }
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Remove(int id)
    {
      var thisJoin = _db.MechanicMachine.FirstOrDefault(mechanicmachine => mechanicmachine.MechanicMachineId == id);
      return View(thisJoin);
    }

    [HttpPost, ActionName("Remove")]
    public ActionResult RemoveConfirmed(int id)
    {
      var thisJoin = _db.MechanicMachine.FirstOrDefault(mechanicmachine => mechanicmachine.MechanicMachineId == id);
      _db.MechanicMachine.Remove(thisJoin);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = thisJoin.MachineId});
    }
  }
}
