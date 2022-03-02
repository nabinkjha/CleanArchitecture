using ECom.Application.Interfaces.Shared;
using System;

namespace ECom.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}