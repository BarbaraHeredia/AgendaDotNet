using APIAgenda.Mappings;
using APIAgenda.Models;
using APIAgenda.Repositories;
using APIAgenda.Request;
using APIAgenda.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgenda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventEmailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventEmailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /EventEmails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventEmailResponse>>> Get()
        {
            var eventEmails = await _unitOfWork.EventEmailRepository.GetEventEmailsAsync();

            if (!eventEmails.Any())
            {
                return NotFound("Emails não encontrados");
            }

            var eventEmailDtos = eventEmails.Select(ee => ee.ToEventEmailResponse()).ToList();
            return Ok(eventEmailDtos);
        }

        // GET: /EventEmails/{id}
        [HttpGet("{id}", Name = "ObterEmail")]
        public async Task<ActionResult<EventEmailResponse>> Get(int id)
        {
            var eventEmail = await _unitOfWork.EventEmailRepository.GetEventEmailAsync(id);

            if (eventEmail == null)
            {
                return NotFound("Email não encontrado");
            }

            var eventEmailDto = eventEmail.ToEventEmailResponse();
            return Ok(eventEmailDto);
        }

        // POST: /EventEmails
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PutEventEmailRequest eventEmailDto)
        {
            if (eventEmailDto == null)
            {
                return BadRequest("Dados inválidos");
            }

            var eventEmail = eventEmailDto.ToEntity();

            await _unitOfWork.EventEmailRepository.CreateAsync(eventEmail);
            await _unitOfWork.CommitAsync();

            var createdEventEmailDto = eventEmail.ToEventEmailResponse();

            return new CreatedAtRouteResult("ObterEmail", new { id = eventEmail.Id }, createdEventEmailDto);
        }

        // PUT: /EventEmails/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EventEmailResponse>> Put(int id, [FromBody] PutEventEmailRequest eventEmailDto)
        {
            if (id != eventEmailDto.Id)
            {
                return BadRequest("ID do Email não confere");
            }

            var existingEventEmail = await _unitOfWork.EventEmailRepository.GetEventEmailAsync(id);
            if (existingEventEmail == null)
            {
                return NotFound("Email não encontrado");
            }

            existingEventEmail.Email = eventEmailDto.Email;
            existingEventEmail.EmailMessage = eventEmailDto.EmailMessage;
            existingEventEmail.EmailSubject = eventEmailDto.EmailSubject;
            existingEventEmail.EmailBody = eventEmailDto.EmailBody;
            existingEventEmail.EmailRecipient = eventEmailDto.EmailRecipient;
            existingEventEmail.EmailAttachments = eventEmailDto.EmailAttachments;
            existingEventEmail.DateTime = eventEmailDto.DateTime;
            existingEventEmail.EventActionId = eventEmailDto.EventActionId;

            await _unitOfWork.EventEmailRepository.UpdateAsync(existingEventEmail);
            await _unitOfWork.CommitAsync();

            var updatedEventEmailDto = existingEventEmail.ToEventEmailResponse();
            return Ok(updatedEventEmailDto);
        }

        // DELETE: /EventEmails/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventEmailResponse>> Delete(int id)
        {
            var eventEmail = await _unitOfWork.EventEmailRepository.GetEventEmailAsync(id);
            if (eventEmail == null)
            {
                return NotFound("Email não encontrado");
            }

            await _unitOfWork.EventEmailRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            var deletedEventEmailDto = eventEmail.ToEventEmailResponse();
            return Ok(deletedEventEmailDto);
        }
    }
}
