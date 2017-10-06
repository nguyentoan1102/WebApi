using System;

namespace PingYourPackage.Domain.Entities.Core
{
    public interface IEntity
    {
        Guid Key { get; set; }
    }
}