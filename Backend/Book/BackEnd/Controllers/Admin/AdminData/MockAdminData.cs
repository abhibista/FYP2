using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
using FYP.admindata;

namespace FYP.MockAdminData
{
    public class MockAdminData : IDoctorData
    {
        private List<Doctor> doctors = new List<Doctor>()
        {
           new Doctor()
           {
               Id = 1,
               DoctorName = "Doctor one"
           },
                  new Doctor()
           {
               Id = 2,
               DoctorName = "Doctor one"
           }
        };

        private readonly ArticleContext _context;
        public MockAdminData(ArticleContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDoctor(Doctor doctor)
        {
            if (doctor.Id == 0)
            {

                doctor.CreatedOn = DateTime.Now;
                doctor.Password = HasHeleper.CreateHash(doctor.Password);
                await _context.Doctors.AddAsync(doctor);
                await _context.SaveChangesAsync();
            }
            else
            {
                var doctors = _context.Doctors.Update(doctor);
            }
            return true;
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            var result = _context.Doctors.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.Doctors.Remove(result);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public Doctor GetDoctor(int id)
        {
            return _context.Doctors.SingleOrDefault(x => x.Id == id);
        }

        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }
    }
}
