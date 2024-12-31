using DenemeApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DenemeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c=new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeListGetById(int id)
        {
            using var c = new Context();
            var GetemployeeId = c.Employees.Find(id);
            if(GetemployeeId == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(GetemployeeId);
            }    
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeList(int id)
        {
            using var c = new Context();
            var delemployeeid = c.Employees.Find(id);
            if (delemployeeid == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(delemployeeid);
                c.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployeeList(Employee employee)
        {
            using var c = new Context();
            var Updateemployee = c.Find<Employee>(employee.Id);
            if(Updateemployee==null)
            {
                return NotFound();
            }
            else
            {
                Updateemployee.Name = employee.Name;
                c.Update(Updateemployee);
                c.SaveChanges();
                return Ok();
            }
        }

    }
}
