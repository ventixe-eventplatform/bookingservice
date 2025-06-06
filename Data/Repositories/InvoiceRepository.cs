using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class InvoiceRepository(DataContext context) : BaseRepository<InvoiceEntity>(context), IInvoiceRepository
{
    public async Task<InvoiceEntity?> GetLastInvoiceNumberAsync()
    {
        var entity = await _context.Invoices.OrderByDescending(i => i.Id).FirstOrDefaultAsync();

        if (entity == null)
            return null!;

        return entity;
    }
}
