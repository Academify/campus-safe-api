using CampusSafe.Domain.Base.Models;
using CampusSafe.Domain.Base.Utils;

namespace CampusSafe.Domain.Entities;

public class User : Validatable
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    public User(Guid id, string name, string email)
    {
        if(id == Guid.Empty) AddNotification("Id can't be empty");
        if(string.IsNullOrEmpty(name)) AddNotification("Name can't be empty");
        if(!StringUtils.IsValidEmail(email)) AddNotification("Email must be valid");
        
        Validate();
        
        Id = id;
        Name = name;
        Email = email;
    }
}