using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Contracts;
using TMS.Data;
using TMS.Data.Models;

namespace TMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public StudentController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Student
        [HttpGet]
        public  IEnumerable<Student> GetStudent()
        {
            return _uow.StudentRepository.Get()
                .OrderByDescending(x => x.StudentId)
                .Where(x => x.DelStatus == "N");
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
           

            var student = _uow.StudentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }
            try
            {
                _uow.StudentRepository.Update(student);
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Student
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Student> PostStudent(Student student)
        {
            _uow.StudentRepository.Add(student);
            _uow.Commit();
            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public  ActionResult<Student> DeleteStudent(int id, Student student)
        {

            if (id != student.StudentId)
            {
                return BadRequest();
            }
            try
            {
                _uow.StudentRepository.Update(student);
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Deleted Sucessfully");
            //var student =  _uow.StudentRepository.GetById(id);
            //if (student == null)
            //{
            //    return NotFound();
            //}

            //_uow.StudentRepository.Delete(student);
            //_uow.Commit();
            //return student;
        }

        private bool StudentExists(int id)
        {
            var student= _uow.StudentRepository.GetById(id);
            if (student == null)
            {
                return false;
            }
            return true;
        }
    }
}
