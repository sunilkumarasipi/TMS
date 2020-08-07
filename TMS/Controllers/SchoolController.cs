using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Contracts;
using TMS.Data.Models;

namespace TMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public SchoolController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/School
        [HttpGet]
        public IEnumerable<School> GetSchool()
        {
            return _uow.SchoolRepository.Get()
                .OrderByDescending(x => x.SchoolId)
                .Where(x => x.DelStatus == "N");
        }

        // GET: api/School/5
        [HttpGet("{id}")]
        public ActionResult<School> GetSchool(int id)
        {
            var school = _uow.SchoolRepository.GetById(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }

        // PUT: api/School/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutSchool(int id, School school)
        {
            if (id != school.SchoolId)
            {
                return BadRequest();
            }
            try
            {
                _uow.SchoolRepository.Update(school);
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated Sucessfully");
        }

        // POST: api/School
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<School> PostSchool(School school)
        {
            _uow.SchoolRepository.Add(school);
            _uow.Commit();
            return CreatedAtAction("GetSchool", new { id = school.SchoolId }, school);
        }

        // DELETE: api/School/5
        [HttpDelete("{id}")]
        public ActionResult<School> DeleteSchool(int id, School school)
        {

            if (id != school.SchoolId)
            {
                return BadRequest();
            }
            try
            {
                _uow.SchoolRepository.Update(school);
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Deleted Sucessfully");

            //var school = _uow.SchoolRepository.GetById(id);
            //if (school == null)
            //{
            //    return NotFound();
            //}

            //_uow.SchoolRepository.Delete(school);
            //_uow.Commit();
            //return school;
        }

        private bool SchoolExists(int id)
        {
            var school = _uow.SchoolRepository.GetById(id);
            if (school == null)
            {
                return false;
            }
            return true;
        }
    }
}
