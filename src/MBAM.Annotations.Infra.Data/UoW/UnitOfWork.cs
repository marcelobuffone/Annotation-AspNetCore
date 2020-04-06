using MBAM.Annotations.Domain.Core.Commands;
using MBAM.Annotations.Domain.Interfaces;
using MBAM.Annotations.Infra.Data.Context;

namespace MBAM.Annotations.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnnotationsContext _context;

        public UnitOfWork(AnnotationsContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
