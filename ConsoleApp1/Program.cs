using System.Net.Http.Json;
using ChatRoom;
using Microsoft.AspNetCore.Components.Forms;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            WeatherForecast thingy = new WeatherForecast();

            var messageContent = Console.ReadLine();

            ConsoleColor color = ConsoleColor.Green;

            var response = await httpClient.PostAsync(@"https://localhost:7211/Chatroom/PostMessage", JsonContent.Create(messageContent));



            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch
            {
                Console.WriteLine("thingy no worky :(");
            }

            var message = await response.Content.ReadFromJsonAsync<Message>();

            Console.ForegroundColor = message.User;
            Console.WriteLine(message.MessageContent);

            //WeatherForecast[] content = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();
            ;
        }
    }
}
