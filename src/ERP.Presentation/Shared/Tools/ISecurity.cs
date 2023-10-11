namespace ERP.Presentation.Shared.Tools;

public interface ISecurity
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}
