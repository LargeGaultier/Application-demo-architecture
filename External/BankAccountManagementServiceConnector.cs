using Newtonsoft.Json;
using System.Text;

namespace Archi.AppBankAccountManagement.External
{
    public class BankAccountManagementServiceConnector
    {
        public async Task<bool> BankAccountCreation(long userId)
        {
           
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7183/");
                var request = new HttpRequestMessage(HttpMethod.Post, $"/api/bankaccounts/users/{userId}");
                var response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
          
            
        }
    }
}
