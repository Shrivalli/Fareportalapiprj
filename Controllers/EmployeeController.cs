using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using firstapi.Models;
using Microsoft.EntityFrameworkCore;

namespace firstapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        [Route("AllEmps")]
        public  async Task<ActionResult<List<Employee>>> getAllEmployees()
        {
            using(var db=new FarePortalContext())  
            {
                    var emps=await db.Employees.ToListAsync();
                    return Ok(emps);
            }  
        }

        [HttpGet]
        [Route("EmpbyID/{id}")]
        public async Task<ActionResult<Employee>> getEmpById(int id)
        {
            using (var db=new FarePortalContext())
            {
                Employee obj=await db.Employees.FindAsync(id);
                return Ok(obj);
            }
        }

        [HttpPost]
        [Route("AddEmp")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee e)
        {
            using (var db=new FarePortalContext())
            {
                db.Employees.Add(e);
                await db.SaveChangesAsync();
                return Ok(e);
            }
        }

        [HttpPut]
        [Route("EditEmp")]
        public async Task<ActionResult<Employee>> ModifyEmployee(int id,Employee e)
        {
            using(var db=new FarePortalContext())
            {
                db.Employees.Update(e);
               await db.SaveChangesAsync();
               return Ok(e);
            }
        }

        [HttpDelete]
        [Route("DeleteEmp")]
        public async Task<ActionResult> RemoveEmp(int id)
        {
            using(var db=new FarePortalContext())
            {
                Employee e=db.Employees.Find(id);
                db.Employees.Remove(e);
                await db.SaveChangesAsync();
                return Ok();
            }
        }

    }
}