using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Book.Models;

namespace FYP.admindata
{
    public interface IDoctorData
    {
        List<Doctor> GetDoctors();
        Doctor GetDoctor(int id);
        Task<bool> AddDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(int id);
    }
}