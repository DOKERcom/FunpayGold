using Microsoft.AspNetCore.Identity;

namespace FunpayGold.Persistence.Entities;

public class UserEntity : IdentityUser
{
    public List<TaskEntity> Tasks { get; set; }

    public UserEntity()
    {
        Tasks = new List<TaskEntity>();
    }
}