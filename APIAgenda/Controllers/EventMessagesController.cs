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
    public class EventMessagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventMessagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /EventMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventMessageResponse>>> Get()
        {
            var eventMessages = await _unitOfWork.EventMessageRepository.GetEventMessagesAsync();

            if (!eventMessages.Any())
            {
                return NotFound("Mensagens não encontradas");
            }

            var eventMessageDtos = eventMessages.Select(em => em.ToEventMessageResponse()).ToList();
            return Ok(eventMessageDtos);
        }

        // GET: /EventMessages/{id}
        [HttpGet("{id}", Name = "ObterMensagem")]
        public async Task<ActionResult<EventMessageResponse>> Get(int id)
        {
            var eventMessage = await _unitOfWork.EventMessageRepository.GetEventMessageAsync(id);

            if (eventMessage == null)
            {
                return NotFound("Mensagem não encontrada");
            }

            var eventMessageDto = eventMessage.ToEventMessageResponse();
            return Ok(eventMessageDto);
        }

        // POST: /EventMessages
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PutEventMessageRequest eventMessageDto)
        {
            if (eventMessageDto == null)
            {
                return BadRequest("Dados inválidos");
            }

            var eventMessage = eventMessageDto.ToEntity();

            await _unitOfWork.EventMessageRepository.CreateAsync(eventMessage);
            await _unitOfWork.CommitAsync();

            var createdEventMessageDto = eventMessage.ToEventMessageResponse();

            return new CreatedAtRouteResult("ObterMensagem", new { id = eventMessage.Id }, createdEventMessageDto);
        }

        // PUT: /EventMessages/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EventMessageResponse>> Put(int id, [FromBody] PutEventMessageRequest eventMessageDto)
        {
            if (id != eventMessageDto.Id)
            {
                return BadRequest("ID da Mensagem não confere");
            }

            var existingEventMessage = await _unitOfWork.EventMessageRepository.GetEventMessageAsync(id);
            if (existingEventMessage == null)
            {
                return NotFound("Mensagem não encontrada");
            }

            existingEventMessage.MessageBody = eventMessageDto.MessageBody;
            existingEventMessage.MessageRecipient = eventMessageDto.MessageRecipient;
            existingEventMessage.MessageCreated = eventMessageDto.MessageCreated;
            existingEventMessage.EventActionId = eventMessageDto.EventActionId;

            await _unitOfWork.EventMessageRepository.UpdateAsync(existingEventMessage);
            await _unitOfWork.CommitAsync();

            var updatedEventMessageDto = existingEventMessage.ToEventMessageResponse();
            return Ok(updatedEventMessageDto);
        }

        // DELETE: /EventMessages/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventMessageResponse>> Delete(int id)
        {
            var eventMessage = await _unitOfWork.EventMessageRepository.GetEventMessageAsync(id);
            if (eventMessage == null)
            {
                return NotFound("Mensagem não encontrada");
            }

            await _unitOfWork.EventMessageRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            var deletedEventMessageDto = eventMessage.ToEventMessageResponse();
            return Ok(deletedEventMessageDto);
        }
    }
}
