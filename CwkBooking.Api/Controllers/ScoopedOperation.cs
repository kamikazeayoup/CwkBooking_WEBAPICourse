using CwkBooking.Api.Controllers.Services;
using System;

namespace CwkBooking.Api.Controllers
{
    public class ScoopedOperation : IScoopedOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
