using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AzureAppDbHosting.Models;
using AzureAppDbHosting.Services;

namespace AzureAppDbHosting.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PatientsController : Controller
    {
        private readonly MySqlDatabaseContext _context;
		private readonly SmsService _smsService;

		public PatientsController(MySqlDatabaseContext context, SmsService smsService)
        {
            _context = context;
            _smsService = smsService;
		}

        //// GET: api/Patients
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        //{
        //  if (_context.Patients == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Patients.ToListAsync();
        //}

        [HttpGet]
        public IActionResult Index()
        {
            var patients = _context.Patients.ToList();
			List<PatientViewModel> patientList = new List<PatientViewModel>();
			if (patients != null)
            {
                foreach (var patient in patients)
                {
                    var patientViewModel = new PatientViewModel()
                    {
                        Id = patient.Id,
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
						Gender = patient.Gender,
                        Phone = patient.Phone
                    };
                    patientList.Add(patientViewModel);
                }
            }
            return View(patientList);
        }

        public IActionResult SendSms(string phone)
        {
            try
            {
                _smsService.SendSms(phone);
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
			}
            return Ok();
        }

        //// GET: api/Patients/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Patient>> GetPatient(int id)
        //{
        //  if (_context.Patients == null)
        //  {
        //      return NotFound();
        //  }
        //    var patient = await _context.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return patient;
        //}

        //// PUT: api/Patients/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPatient(int id, Patient patient)
        //{
        //    if (id != patient.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(patient).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PatientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Patients
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        //{
        //  if (_context.Patients == null)
        //  {
        //      return Problem("Entity set 'MySqlDatabaseContext.Patients'  is null.");
        //  }
        //    _context.Patients.Add(patient);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        //}

        //// DELETE: api/Patients/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePatient(int id)
        //{
        //    if (_context.Patients == null)
        //    {
        //        return NotFound();
        //    }
        //    var patient = await _context.Patients.FindAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Patients.Remove(patient);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PatientExists(int id)
        //{
        //    return (_context.Patients?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
