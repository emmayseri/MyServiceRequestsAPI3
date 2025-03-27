using MyServiceRequestsAPI3.Models;

namespace MyServiceRequestsAPI3.Services;

    public class ServiceRequestsService
    {
        private static readonly List<ServiceRequest> _requests = new();

        public List<ServiceRequest> GetAll() => _requests;

        public ServiceRequest? GetById(Guid id) =>
            _requests.FirstOrDefault(r => r.Id == id);

        public void Add(ServiceRequest request)
        {
            request.Id = Guid.NewGuid();
            request.CreatedDate = DateTime.UtcNow;
            _requests.Add(request);
        }

        public void Update(ServiceRequest updated)
        {
            var existing = GetById(updated.Id);
            if (existing == null) return;

            existing.BuildingCode = updated.BuildingCode;
            existing.Description = updated.Description;
            existing.CurrentStatus = updated.CurrentStatus;
            existing.LastModifiedBy = updated.LastModifiedBy;
            existing.LastModifiedDate = DateTime.UtcNow;
        }

        public void Delete(Guid id)
        {
            var request = GetById(id);
            if (request != null) _requests.Remove(request);
        }
    }
