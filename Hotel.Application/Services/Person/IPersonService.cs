namespace Hotel.Application.Services.Person
{
    public interface IPersonService
    {
        Task<List<Domain.Domain.Entities.Person>> List(Guid id, CancellationToken cancellationToken);
    }
}
