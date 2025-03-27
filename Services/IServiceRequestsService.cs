using MyServiceRequestsAPI3.Models;

namespace MyServiceRequestsAPI3.Services
{
    public interface IServiceRequestsService
    {
        List<ServiceRequest> GetAll();
        ServiceRequest? GetById(Guid id);
        void Add(ServiceRequest request);
        void Update(ServiceRequest request);
        void Delete(Guid id);
    }
}