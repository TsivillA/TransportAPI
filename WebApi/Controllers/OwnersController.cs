using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owners
        [HttpGet]
        public IEnumerable<OwnerQueryModel> GetOwners()
        {
            return _ownerService.GetAllOwners();
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public ActionResult<OwnerQueryModel> GetOwner(int id)
        {
            var owner = _ownerService.GetOwner(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, OwnerCommandModel owner)
        {
            await _ownerService.UpdateOwner(owner, id);

            return NoContent();
        }

        // POST: api/Owners
        [HttpPost]
        public async Task<ActionResult> PostOwner(OwnerCommandModel model)
        {
            var id = await _ownerService.AddOwner(model);
            if (id == -1)
            {
                ModelState.AddModelError(nameof(OwnerCommandModel.PersonalId), "The person with this Id is already registered");
                return BadRequest(ModelState.Where(ms => ms.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage).ToArray()));
            }
            return Ok(id);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOwner(int id)
        {
            var isDeleted = await _ownerService.DeleteOwner(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
