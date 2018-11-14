using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture11.UwpApp.Models
{
    public class Settings : ISettings
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public Uri BackendUrl => new Uri("https://localhost:44327");

        public IReadOnlyCollection<string> Scopes => new[] { "api://3fc11f95-6cd9-47ad-b77e-f93feb93d095/access_as_user" };

        public string ClientId => "1c2c5ab9-bd1d-4c2f-85c9-02f349ae9576";

        public string TenantId => "b461d90e-0c15-44ec-adc2-51d14f9f5731";

        public string Authority => $"https://login.microsoftonline.com/{TenantId}/v2.0/";
    }
}
