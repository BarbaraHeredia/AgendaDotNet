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
    public class EventRemindersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventRemindersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /EventReminders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventReminderResponse>>> Get()
        {
            var eventReminders = await _unitOfWork.EventReminderRepository.GetEventRemindersAsync();

            if (eventReminders == null || !eventReminders.Any())
            {
                return NotFound("Lembretes não encontrados");
            }

            var eventReminderDtos = eventReminders.Select(er => er.ToEventReminderResponse()).ToList();
            return Ok(eventReminderDtos);
        }

        // GET: /EventReminders/{id}
        [HttpGet("{id}", Name = "ObterLembrete")]
        public async Task<ActionResult<EventReminderResponse>> Get(int id)
        {
            var eventReminder = await _unitOfWork.EventReminderRepository.GetEventReminderAsync(id);
            if (eventReminder == null)
            {
                return NotFound("Lembrete não encontrado");
            }

            var eventReminderDto = eventReminder.ToEventReminderResponse();
            return Ok(eventReminderDto);
        }

        // POST: /EventReminders
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PutEventReminderRequest eventReminderDto)
        {
            if (eventReminderDto == null)
            {
                return BadRequest("Dados inválidos");
            }

            var eventReminder = eventReminderDto.ToEntity();

            await _unitOfWork.EventReminderRepository.CreateAsync(eventReminder);
            await _unitOfWork.CommitAsync();

            var createdEventReminderDto = eventReminder.ToEventReminderResponse();

            return new CreatedAtRouteResult("ObterLembrete", new { id = eventReminder.Id }, createdEventReminderDto);
        }

        // PUT: /EventReminders/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EventReminderResponse>> Put(int id, [FromBody] PutEventReminderRequest eventReminderDto)
        {
            if (id != eventReminderDto.Id)
            {
                return BadRequest("ID do Lembrete não confere");
            }

            var existingEventReminder = await _unitOfWork.EventReminderRepository.GetEventReminderAsync(id);
            if (existingEventReminder == null)
            {
                return NotFound("Lembrete não encontrado");
            }

            existingEventReminder.Name = eventReminderDto.Name;
            existingEventReminder.Title = eventReminderDto.Title;
            existingEventReminder.Content = eventReminderDto.Content;
            existingEventReminder.Created = eventReminderDto.Created;
            existingEventReminder.SentDate = eventReminderDto.SentDate;
            existingEventReminder.EventActionId = eventReminderDto.EventActionId;

            await _unitOfWork.EventReminderRepository.UpdateAsync(existingEventReminder);
            await _unitOfWork.CommitAsync();

            var updatedEventReminderDto = existingEventReminder.ToEventReminderResponse();
            return Ok(updatedEventReminderDto);
        }

        // DELETE: /EventReminders/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventReminderResponse>> Delete(int id)
        {
            var eventReminder = await _unitOfWork.EventReminderRepository.GetEventReminderAsync(id);
            if (eventReminder == null)
            {
                return NotFound("Lembrete não encontrado");
            }

            await _unitOfWork.EventReminderRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            var deletedEventReminderDto = eventReminder.ToEventReminderResponse();
            return Ok(deletedEventReminderDto);
        }
    }
}
