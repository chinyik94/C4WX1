namespace C4WX1.API.Features.Security
{
    public interface ISecurityService
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}
