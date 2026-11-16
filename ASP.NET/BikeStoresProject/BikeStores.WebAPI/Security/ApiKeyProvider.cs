using System.Security.Cryptography;

namespace BikeStores.WebAPI.Security;
public class ApiKeyProvider
{
    public string SecretKey { get; }

    public ApiKeyProvider()
    {
        // 32 byte casuali -> stringa Base64 (generata a ogni avvio)
        SecretKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}
