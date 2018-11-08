using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture10.UwpApp.Models
{
    public class Settings : ISettings
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public Uri BackendUrl => new Uri("https://localhost:44326");

        public string Tenant => "ondfiskb2c.onmicrosoft.com";
        public string ClientId => "e0c76003-5ec4-497c-a3ed-6b5c41de4182";

        public string SignUpSignInPolicy => "b2c_1_susi";
        public string EditProfilePolicy => "b2c_1_edit_profile";
        public string ResetPasswordPolicy => "b2c_1_reset";

        public IReadOnlyCollection<string> Scopes => new[] { "https://ondfiskb2c.onmicrosoft.com/e0c76003-5ec4-497c-a3ed-6b5c41de4182/user_impersonation" };

        public string Authority => $"https://login.microsoftonline.com/tfp/{Tenant}/{SignUpSignInPolicy}/oauth2/v2.0/authorize";
        public string AuthorityEditProfile => $"https://login.microsoftonline.com/tfp/{Tenant}/{ResetPasswordPolicy}/oauth2/v2.0/authorize";
        public string AuthorityResetPassword => $"https://login.microsoftonline.com/tfp/{Tenant}/{SignUpSignInPolicy}/oauth2/v2.0/authorize";
    }
}
