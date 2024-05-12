namespace DLP.Infrastructure
{
    public interface IPasswrodHasher
    {
        string Generate(string password);
        bool Verify(string password, string hashedPasswrod);
    }
}