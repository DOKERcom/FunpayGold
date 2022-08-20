namespace FunpayGold.Application.Models;

public class UserModel
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public List<BotModel> Bots { get; set; }

    public UserModel()
    {
        Bots = new List<BotModel>();
    }
}