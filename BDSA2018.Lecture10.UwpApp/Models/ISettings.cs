using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture10.UwpApp.Models
{
    public interface ISettings
    {
        Uri BackendUrl { get; }
        string ClientId { get; }
        IReadOnlyCollection<string> Scopes { get; }
        string TenantId { get; }
    }
}