﻿using System;

namespace AllegroApi.Domain.AllegroOffer.Publication
{
    public class Publication
    {
        public object Duration { get; set; }
        public string Status { get; set; }
        public object StartingAt { get; set; }
        public object EndingAt { get; set; }
        public object EndedBy { get; set; }
        public bool Republish { get; set; }
        public string Action { get; set; }
        public DateTime ScheduledFor { get; set; }

    }
}