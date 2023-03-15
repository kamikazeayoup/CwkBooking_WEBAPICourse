using CwkBooking.Api.Controllers.Services;
using System;

namespace CwkBooking.Api.Controllers
{
    public class SingletonOperation : ISingletonOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
