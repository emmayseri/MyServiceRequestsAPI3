using Microsoft.AspNetCore.Mvc;
using MyServiceRequestsAPI3.Models;
using MyServiceRequestsAPI3.Services;

namespace ServiceRequestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestsService _service;
        public ServiceRequestController(IServiceRequestsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServiceRequest>> GetAll()
        {
            var list = _service.GetAll();
            if (!list.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceRequest> GetById(Guid id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpPost]
        public ActionResult<ServiceRequest> Create(ServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Add(request);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ServiceRequest updated)
        {
            var existing = _service.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            updated.Id = id;
            _service.Update(updated);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existing = _service.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}