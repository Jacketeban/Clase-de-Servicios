namespace Arepas.Api.Dtos;

public class LoginDto
{
    public string UserEmail { get; set; } = null!;

    public string Password { get; set; } = null!;
}