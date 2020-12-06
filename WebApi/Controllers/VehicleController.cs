using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicle
        [HttpGet]
        public IEnumerable<VehicleQueryModel> GetVehicles([FromQuery] PaginationModel paginationmodel, [FromQuery] VehicleFilterModel vehicleFilterModel)
        {
            return _vehicleService.GetAllVehicles(paginationmodel, vehicleFilterModel);
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public ActionResult<VehicleQueryModel> GetVehicle(int id)
        {
            var vehicle = _vehicleService.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, VehicleCommandModel vehicle)
        {
            await _vehicleService.UpdateVehicle(vehicle, id);

            return NoContent();
        }

        // POST: api/Vehicle
        [HttpPost]
        public async Task<ActionResult<int>> PostVehicle(VehicleCommandModel model)
        {
            var id = await _vehicleService.AddVehicle(model);

            return Ok(id);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var isDeleted = await _vehicleService.DeleteVehicle(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
