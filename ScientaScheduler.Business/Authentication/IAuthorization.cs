namespace ScientaScheduler.Business.Authentication
{
    public interface IAuthorization
    {
        string CreateToken(string[] loginKeys);

        bool ValidateToken(string token);
    }
}
