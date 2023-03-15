using CwkBooking.Api.Controllers.Services;
using System;

namespace CwkBooking.Api.Controllers
{
    public class TransientOperation : ITransientOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
