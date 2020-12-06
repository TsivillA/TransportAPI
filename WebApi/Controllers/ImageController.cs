using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApi.Services.Interfaces;

namespace ImageUploadDemo.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IVehicleService _vehicleService;

        public ImageController(IWebHostEnvironment environment, IVehicleService vehicleService)
        {
            _environment = environment;
            _vehicleService = vehicleService;
        }

        public class FIleUploadAPI
        {
            public IFormFile files { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult> Post(FIleUploadAPI file, int vehicleId)
        {
            if (file.files.Length > 0)
            {
                try
                {
                    var vehicle = _vehicleService.GetVehicle(vehicleId);
                    if (vehicle == null)
                    {
                        return NotFound();
                    }

                    if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + file.files.FileName))
                    {
                        file.files.CopyTo(filestream);
                        filestream.Flush();
                        await _vehicleService.ConfigureImage(file.files.FileName, vehicleId);
                        return Ok("\\uploads\\" + file.files.FileName);
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(FIleUploadAPI file, int vehicleId)
        {
            if (file.files.Length > 0)
            {
                try
                {
                    var vehicle = _vehicleService.GetVehicle(vehicleId);
                    if (vehicle == null)
                    {
                        return NotFound();
                    }

                    var previousFilePath = _environment.WebRootPath + "\\uploads\\" + vehicle.Image;
                    if (System.IO.File.Exists(previousFilePath))
                    {
                        System.IO.File.Delete(previousFilePath);
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + file.files.FileName))
                    {
                        file.files.CopyTo(filestream);
                        filestream.Flush();
                        await _vehicleService.ConfigureImage(file.files.FileName, vehicleId);
                        return Ok("\\uploads\\" + file.files.FileName);
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int vehicleId)
        {
            try
            {
                var vehicle = _vehicleService.GetVehicle(vehicleId);
                if (vehicle == null)
                {
                    return NotFound();
                }

                var filePath = _environment.WebRootPath + "\\uploads\\" + vehicle.Image;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                await _vehicleService.ConfigureImage(null, vehicleId);
                return Ok(filePath);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
