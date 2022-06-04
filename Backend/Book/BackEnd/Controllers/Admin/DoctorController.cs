using System;
using System.Threading.Tasks;
using Book.Models;
using FYP.admindata;
using Microsoft.AspNetCore.Mvc;

[ApiController]

public class DoctorController : ControllerBase
{
    private  readonly IDoctorData _doctor;
    public DoctorController(IDoctorData doctor)
    {
        _doctor = doctor;
    }
    [HttpGet("api/GetDoctors")]
    public IActionResult GetDoctors()
    {
        return Ok(_doctor.GetDoctors());
    }

    [Route("api/GetDoctor")]
    [HttpGet("{id}")]
    public IActionResult GetDoctor([FromQuery] int id)
    {
        var doctor = _doctor.GetDoctor(id);
        if (doctor != null)
        {
            return Ok(doctor);
        }
        return NotFound($"Doctor with Id: {id} was not found");
    }

    [Route("api/PostDoctor")]
    [HttpPost("doctor")]
    public async Task<ActionResult<bool>> PostDoctor(Doctor doctor)
    {
       
        var data = await _doctor.AddDoctor(doctor);   
        return Ok(true);
    }

    [HttpDelete("api/DeleteDoctor/{id}")]
    public IActionResult DeleteDoctor(int id)
    {
        var data = _doctor.DeleteDoctor(id);
       return Ok(true);

    }    
}



//     [HttpPatch("{id}")]
//     public IActionResult EditDoctor(int id, Doctor doctor)
//     {
//         var existingDoctor = _doctorData.GetDoctor(id);
//         if (existingDoctor != null)
//         {
//             doctor.Id = existingDoctor.Id;
//             _doctorData.EditDoctor(doctor);
//         }
//         return Ok(doctor);
//     }
// }