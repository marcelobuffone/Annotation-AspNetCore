using MBAM.Annotations.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBAM.Annotations.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
