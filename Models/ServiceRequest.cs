using System.ComponentModel.DataAnnotations;

namespace MyServiceRequestsAPI3.Models;

public class ServiceRequest{
    public Guid Id {get; set; } = Guid.NewGuid();
    [Required]
    public required string BuildingCode {get; set;}
    [Required]
    public required string Description {get; set;}
    
    public CurrentStatus CurrentStatus {get; set;} = CurrentStatus.Created;
    [Required]
    public required string CreatedBy {get; set;}
    public DateTime CreatedDate {get; set;}
    public string? LastModifiedBy {get; set;}
    public DateTime? LastModifiedDate {get; set;}

}