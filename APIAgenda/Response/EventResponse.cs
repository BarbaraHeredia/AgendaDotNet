﻿namespace APIAgenda.Response
{
    public class EventResponse
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDateStart { get; set; }
        public DateTime? EventDateEnd { get; set; }
        public string UserId { get; set; }
    }
}
