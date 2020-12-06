using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleOwnerController : ControllerBase
    {
        private readonly IVehicleOwnerService _vehicleOwnerService;

        public VehicleOwnerController(IVehicleOwnerService vehicleOwnerService)
        {
            _vehicleOwnerService = vehicleOwnerService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(VehicleOwnerCommandModel model)
        {
            var result = await _vehicleOwnerService.AddVehicleOwner(model);

            if (result.Item2 != null)
            {
                return NotFound(result.Item2);
            }
            return Ok(result.Item1);
        }
    }
}
