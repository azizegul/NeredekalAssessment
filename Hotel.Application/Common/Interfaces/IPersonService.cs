namespace Hotel.Application.Common.Interfaces
{
    public interface IPersonService
    {
        Task<List<Domain.Domain.Entities.Person>> List(Guid id, CancellationToken cancellationToken);
    }
}
