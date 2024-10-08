using Newtonsoft.Json;
using System.Text;

namespace Archi.AppBankAccountManagement.External
{
    public class BankAccountManagementServiceConnector
    {
        public async Task<bool> BankAccountCreation(long userId)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5000");
                var request = new HttpRequestMessage(HttpMethod.Post, $"/api/BankAccount/user/{userId}");
                var response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
