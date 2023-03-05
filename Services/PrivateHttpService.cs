using System;
using BitexenNet.Helpers;
using BitexenNet.Models;

namespace BitexenNet.Services
{
    public class PrivateHttpService : HttpService
    {
        public PrivateHttpService(Credentials? credentials) : base(credentials)
        {
        }

        public override Result<T>? Get<T>(string url)
        {
            CheckCredencials();
            return base.Get<T>(url);
        }

        public override Result<T>? Post<T>(string url, object? data = null)
        {
            CheckCredencials();
            return base.Post<T>(url, data);
        }

        public bool CheckCredencials()
        {
            if (Credentials == null)
            {
                Console.WriteLine($"Failed to send request: credentials are required for private endpoints");
                throw new ArgumentNullException(nameof(Credentials));
            }
            return true;
        }

    }
}
