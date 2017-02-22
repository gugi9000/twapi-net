using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using twapi.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace twapi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        // GET: /<controller>/
        public IEnumerable<string> Get()
        {
            DataReader.GetEmployees();
                        
            return new string[] { "result[0,0]"};
        }
        // GET api/employees/<n>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return String.Format("You requested value of number {0}", id);
        }
    }
}
