using BasicAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasicAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return _employeeService.GetEmployees();
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            this._employeeService.AddEmployee(employee);

          //  var response = httpre     //Request.CreateResponse(HttpStatusCode.Created);

            return new HttpResponseMessage(HttpStatusCode.Created);
            
        }
    }
}
