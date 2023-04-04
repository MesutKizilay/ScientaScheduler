namespace ScientaScheduler.Authentication.Authentication
{
    public interface IAuthorization
    {
        string CreateToken();

        bool ValidateToken(string token);
    }
}
