using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture10.UwpApp.Models
{
    public class Settings : ISettings
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public Uri BackendUrl => new Uri("https://localhost:44326");

        public IReadOnlyCollection<string> Scopes => new[] { "d0104efa-486e-477a-a177-582ae81884e9/user_impersonation" };

        public string ClientId => "b29fa155-d4d2-4aef-9758-9297ae479865";

        public string TenantId => "bea229b6-7a08-4086-b44c-71f57f716bdb";
    }
}
