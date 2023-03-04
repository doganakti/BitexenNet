namespace BitexenNet.Models;

using System.Security.Cryptography;
using System.Text;

public class AuthHeader
{
    public string Signature { get; }
    public AuthHeader(Credentials credentials, long timestamp, string body = "{}")
    {
        var message = $"{credentials.ApiKey}{credentials.UserName}{credentials.Passphrase}{timestamp}{body}";
        Signature = HmacSHA256(credentials.SecretKey, message).ToUpper();
        System.Console.WriteLine($"AuthHeader created with signature: {Signature} and body: {body}");
    }

    public string HmacSHA256(string key, string data)
    {
        string hash;
        ASCIIEncoding encoder = new ASCIIEncoding();
        Byte[] code = encoder.GetBytes(key);
        using (HMACSHA256 hmac = new HMACSHA256(code))
        {
            Byte[] hmBytes = hmac.ComputeHash(encoder.GetBytes(data));
            hash = ToHexString(hmBytes);
        }
        return hash;
    }

    public static string ToHexString(byte[] array)
    {
        StringBuilder hex = new StringBuilder(array.Length * 2);
        foreach (byte b in array)
        {
            hex.AppendFormat("{0:x2}", b);
        }
        return hex.ToString();
    }
}

