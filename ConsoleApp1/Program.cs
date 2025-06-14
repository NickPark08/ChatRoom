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
            bool userOne = true;

            while (true)
            {
                var getResponse = await httpClient.GetAsync(@"https://localhost:7211/Chat/GetMessages");
                List<Message> content = await getResponse.Content.ReadFromJsonAsync<List<Message>>();

                foreach (var mes in content)
                {
                    Console.ForegroundColor = mes.User;
                    Console.WriteLine(mes.MessageContent);
                }

                Console.ForegroundColor = ConsoleColor.White;
                var messageContent = Console.ReadLine();

                ConsoleColor color = userOne ? ConsoleColor.Green : ConsoleColor.Blue;
                var message = new Message(messageContent, color);

                var postResponse = await httpClient.PostAsync(@"https://localhost:7211/Chat/PostMessage", JsonContent.Create(message));

                try
                {
                    postResponse.EnsureSuccessStatusCode();
                }
                catch
                {
                    Console.WriteLine("thingy no worky :(");
                }

                userOne = !userOne;
                Console.Clear();

                ;
            }
        }
    }
}
