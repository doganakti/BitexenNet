namespace BitexenNet.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Credentials
{
    public string ApiKey { get; }

    public string UserName { get; }

    public string Passphrase { get; }

    public string SecretKey { get; }

    public Credentials(string apiKey, string userName, string passphrase, string secretKey)
    {
        ApiKey = apiKey;
        UserName = userName;
        Passphrase = passphrase;
        SecretKey = secretKey;
    }
}

