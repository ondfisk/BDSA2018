using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BDSA2018.Lecture10.Web.Controllers
{
    [Authorize]
    public class LogHub : Hub
    {
    }
}
