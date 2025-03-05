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
    [Route("api/v1/[controller]")]
    public class EventActionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventActionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /EventActions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventActionResponse>>> Get()
        {
            var eventActions = await _unitOfWork.EventActionRepository.GetEventActionsAsync();

            if (eventActions == null || !eventActions.Any())
            {
                return NotFound("Eventos não encontrados");
            }

            var eventActionDtos = eventActions.Select(ea => ea.ToEventActionResponse()).ToList();

            return Ok(eventActionDtos);
        }

        // GET: /EventActions/{id}
        [HttpGet("{id}", Name = "AcaoEvento")]
        public async Task<ActionResult<EventActionResponse>> Get(int id)
        {
            var eventAction = await _unitOfWork.EventActionRepository.GetEventActionAsync(id);
            if (eventAction == null)
            {
                return NotFound("Ação de evento não encontrada");
            }

            var eventActionDto = eventAction.ToEventActionResponse();
            return Ok(eventActionDto);
        }

        // POST: /EventActions
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PutEventActionRequest eventActionDto)
        {
            if (eventActionDto == null)
            {
                return BadRequest("Dados inválidos");
            }

            // O ID do evento deve ser fornecido na ação do evento
            if (eventActionDto.EventId <= 0)
            {
                return BadRequest("ID do evento é obrigatório");
            }

            var eventAction = eventActionDto.ToEntity();

            await _unitOfWork.EventActionRepository.CreateAsync(eventAction);
            await _unitOfWork.CommitAsync();

            var createdEventActionDto = eventAction.ToEventActionResponse();

            return new CreatedAtRouteResult("AcaoEvento", new { id = eventAction.EventActionId }, createdEventActionDto);
        }

        // PUT: /EventActions/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EventActionResponse>> Put(int id, [FromBody] PutEventActionRequest eventActionDto)
        {
            if (id != eventActionDto.EventActionId)
            {
                return BadRequest("Ação de Evento não encontrada");
            }

            var existingEventAction = await _unitOfWork.EventActionRepository.GetEventActionAsync(id);
            if (existingEventAction == null)
            {
                return NotFound("Ação de Evento não encontrada");
            }

            existingEventAction.EventActionName = eventActionDto.EventActionName;
            existingEventAction.EventctionDescription = eventActionDto.EventctionDescription;
            existingEventAction.ActionType = eventActionDto.ActionType;
            existingEventAction.EventId = eventActionDto.EventId;

            await _unitOfWork.EventActionRepository.UpdateAsync(existingEventAction);
            await _unitOfWork.CommitAsync();

            var updatedEventActionDto = existingEventAction.ToEventActionResponse();
            return Ok(updatedEventActionDto);
        }

        // DELETE: /EventActions/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventActionResponse>> Delete(int id)
        {
            var eventAction = await _unitOfWork.EventActionRepository.GetEventActionAsync(id);
            if (eventAction == null)
            {
                return NotFound("Ação de Evento não encontrada");
            }

            await _unitOfWork.EventActionRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            var deletedEventActionDto = eventAction.ToEventActionResponse();
            return Ok(deletedEventActionDto);
        }
    }
}
