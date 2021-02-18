using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace asp.net.mvc.Models
{
    public class MusicModel
    {
        public string Music { get; set; }
 
        public MusicModel()
        {
            Music = GetMusicAsync().Result;
        }

        public HttpClient CreateMusicClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/Music");
            return client;
        }

        public async Task<String> GetMusicAsync()
        {
            using (var client = CreateMusicClient())
            {
                HttpResponseMessage response;
                response = client.GetAsync(client.BaseAddress).Result;

                if (response.IsSuccessStatusCode)
                {
                    var music = await response.Content.ReadAsStringAsync();
                    return music;
                }
                else
                {
                    return "??";
                }
            }
        }
    }
}
