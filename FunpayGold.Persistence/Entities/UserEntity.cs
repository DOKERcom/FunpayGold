using Microsoft.AspNetCore.Identity;

namespace FunpayGold.Persistence.Entities;

public class UserEntity : IdentityUser
{
    public List<BotEntity> Bots { get; set; }

    public UserEntity()
    {
        Bots = new List<BotEntity>();
    }
}