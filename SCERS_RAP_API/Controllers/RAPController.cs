using Microsoft.AspNetCore.Mvc;
using SCERS_RAP.Services;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCERS_RAP_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RAPController : ControllerBase
	{
		// POST api/<RAPController>
		[HttpPost("Run")]
		public string RPARun()
		{
			RAPService RAP = new RAPService();
			var test = RAP.Run();
			return test;
		}

		// GET: api/<RAPController>
		[HttpGet]
		public IEnumerable<string> Get()		
		{
			RAPService RAP = new RAPService();
			var test = RAP.Run();			
			return new string[] { test, "value2" };
		}	


		//// POST api/<RAPController>
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

		//// PUT api/<RAPController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<RAPController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
