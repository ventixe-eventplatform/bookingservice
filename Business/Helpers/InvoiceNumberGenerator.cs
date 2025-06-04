using Data.Repositories;

namespace Business.Helpers;

public class InvoiceNumberGenerator(IInvoiceRepository invoiceRepository)
{
    private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;

    public async Task<string> GenerateInvoiceNumberAsync()
    {
        var lastInvoice = await _invoiceRepository.GetLastInvoiceNumberAsync();

        int nextNumber;
        if (lastInvoice != null)
        {
            nextNumber = int.Parse(lastInvoice.InvoiceNumber[3..]) + 1;
        }
        else
        {
            nextNumber = 1;
        }

        return $"INV{nextNumber:D6}";
    }
}
