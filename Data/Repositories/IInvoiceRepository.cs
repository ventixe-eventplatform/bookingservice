using Data.Entities;

namespace Data.Repositories;

public interface IInvoiceRepository : IBaseRepository<InvoiceEntity>
{
    Task<InvoiceEntity?> GetLastInvoiceNumberAsync();
}
