using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _customerService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public ActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
