namespace CarService.Models
{
    // Customer.cs
    public record class Customer(
        int Id,
        string Name,
        string Address,
        List<CustomerInvoice>? CustomerInvoices = null);

    public record class CustomerInvoice(
        
        int Id,
        string Name,
        bool InProbation,
        List<CustomerPerService>? CustomerPerServices = null);

    public record class CustomerPerService(
         int Id,
        string Name,       
        bool IsOptional);


}
