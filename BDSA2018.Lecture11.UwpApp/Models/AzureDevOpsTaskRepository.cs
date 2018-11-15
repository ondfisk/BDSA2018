using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.UwpApp.Models
{
    public class AzureDevOpsTaskRepository
    {
        private readonly HttpClient _client;

        public AzureDevOpsTaskRepository(HttpClient client)
        {
            _client = client;
        }
    }
}
