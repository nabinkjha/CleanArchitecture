﻿using System;

namespace ECom.Application.DTOs
{
    public class AuditLogResponse
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
        public string AffectedColumns { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
