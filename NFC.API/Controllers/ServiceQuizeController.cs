using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NFC.API.Data;
using NFC.API.Models;

namespace NFC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceQuizeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceQuizeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("~/api/ServiceQuize/DoneQuize")]
        [HttpPost]
        public async Task<IActionResult> DoneQuize(ServiceQuizeResultDTO quizeResult)
        {
            try
            {
                var questions = new List<ServiceQuizeQuestion>();
                var result = new ServiceQuizeResult()
                {
                    StationId = quizeResult.StationId,
                    Answers = new List<ServiceQuizeAnswer>()
                };

                foreach (var item in quizeResult.Answers)
                {
                    var question = await _context.ServiceQuizeQuestion.FindAsync(item.QuestionID);
                    result.Answers.Add(
                        new ServiceQuizeAnswer()
                        {
                            Question = question,
                            Answer = item.Answer
                        }
                        );
                }

                _context.ServiceQuizeResult.Add(result);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("~/api/ServiceQuize/AllServiceQuizeResults")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceQuizeResult>>> AllServiceQuizeResults()
        {
            try
            {
                return await _context.ServiceQuizeResult.Include(x=>x.Answers).ThenInclude(a => a.Question).ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/ServiceQuize
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceQuizeQuestion>>> GetServiceQuizeQuestion()
        {
            return await _context.ServiceQuizeQuestion.ToListAsync();
        }

        // GET: api/ServiceQuize/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceQuizeQuestion>> GetServiceQuizeQuestion(int id)
        {
            var serviceQuizeQuestion = await _context.ServiceQuizeQuestion.FindAsync(id);

            if (serviceQuizeQuestion == null)
            {
                return NotFound();
            }

            return serviceQuizeQuestion;
        }

        // PUT: api/ServiceQuize/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceQuizeQuestion(int id, ServiceQuizeQuestion serviceQuizeQuestion)
        {
            if (id != serviceQuizeQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceQuizeQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceQuizeQuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ServiceQuize
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ServiceQuizeQuestion>> PostServiceQuizeQuestion(ServiceQuizeQuestion serviceQuizeQuestion)
        {
            _context.ServiceQuizeQuestion.Add(serviceQuizeQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceQuizeQuestion", new { id = serviceQuizeQuestion.Id }, serviceQuizeQuestion);
        }

        // DELETE: api/ServiceQuize/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceQuizeQuestion>> DeleteServiceQuizeQuestion(int id)
        {
            var serviceQuizeQuestion = await _context.ServiceQuizeQuestion.FindAsync(id);
            if (serviceQuizeQuestion == null)
            {
                return NotFound();
            }

            _context.ServiceQuizeQuestion.Remove(serviceQuizeQuestion);
            await _context.SaveChangesAsync();

            return serviceQuizeQuestion;
        }

        private bool ServiceQuizeQuestionExists(int id)
        {
            return _context.ServiceQuizeQuestion.Any(e => e.Id == id);
        }
    }
}
