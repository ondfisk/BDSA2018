using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture10.UwpApp.Models
{
    public interface ISettings
    {
        string Tenant { get; }
        string ClientId { get; }
        IReadOnlyCollection<string> Scopes { get; }
        string Authority { get; }
        string AuthorityEditProfile { get; }
        string AuthorityResetPassword { get; }
        Uri BackendUrl { get; }
        string EditProfilePolicy { get; }
        string ResetPasswordPolicy { get; }
        string SignUpSignInPolicy { get; }
    }
}