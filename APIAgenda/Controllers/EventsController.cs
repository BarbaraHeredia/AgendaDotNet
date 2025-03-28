﻿using APIAgenda.Extensions;
using APIAgenda.Mappings;
using APIAgenda.Models;
using APIAgenda.Pagination;
using APIAgenda.Repositories;
using APIAgenda.Request;
using APIAgenda.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgenda.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public EventsController(IUnitOfWork unitOfWork, ILogger<EventsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<EventResponse>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var paginationParameters = new PaginationParameters { PageNumber = page, PageSize = pageSize };
            var events = await _unitOfWork.EventRepository.GetEventsAsync(paginationParameters);
            
            if (!events.Any())
            {
                return NotFound("Eventos não encontrados");
            }

            var response = new
            {
                Events = events.Select(e => e.ToEventResponse()).ToList(),
                MetaData = new
                {
                    events.TotalCount,
                    events.PageSize,
                    events.CurrentPage,
                    events.TotalPages,
                    events.HasNext,
                    events.HasPrevious
                }
            };
            return Ok(response);
        }

        [HttpGet("{id}", Name = "ObterEvent")]
        public async Task<ActionResult<EventResponse>> Get(int id)
        {
            var myEvent = await _unitOfWork.EventRepository.GetEventAsync(id);

            if (myEvent == null)
            {
                return NotFound("Evento não encontrado");
            }

            var eventDto = myEvent.ToEventResponse();
            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<ActionResult<EventResponse>> Post(PutEventRequest eventDto)
        {
            if (eventDto == null)
            {
                return BadRequest();
            }

            var myEvent = eventDto.ToEntity();
            await _unitOfWork.EventRepository.CreateAsync(myEvent);
            await _unitOfWork.CommitAsync();

            var createdEventDto = myEvent.ToEventResponse();

            return new CreatedAtRouteResult("ObterEvent", new { id = myEvent.Id }, createdEventDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EventResponse>> Put(int id, PutEventRequest eventDto)
        {
            if (eventDto == null)
            {
                return BadRequest();
            }

            var existingEvent = await _unitOfWork.EventRepository.GetEventAsync(id);
            if (existingEvent == null)
            {
                return NotFound("Evento não encontrado");
            }

            existingEvent.EventName = eventDto.EventName;
            existingEvent.EventDescription = eventDto.EventDescription;
            existingEvent.EventDateStart = eventDto.EventDateStart;
            existingEvent.EventDateEnd = eventDto.EventDateEnd;

            await _unitOfWork.EventRepository.UpdateAsync(existingEvent);
            await _unitOfWork.CommitAsync();

            var updatedEventDto = existingEvent.ToEventResponse();
            return Ok(updatedEventDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EventResponse>> Delete(int id)
        {
            var myEvent = await _unitOfWork.EventRepository.GetEventAsync(id);
            if (myEvent == null)
            {
                return NotFound("Evento não encontrado");
            }

            await _unitOfWork.EventRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            var deletedEventDto = myEvent.ToEventResponse();
            return Ok(deletedEventDto);
        }
    }
}
