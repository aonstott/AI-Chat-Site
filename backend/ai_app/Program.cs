using System;
using System.Threading.Tasks;
using AiApp.OllamaCaller; // Import the namespace where OllamaCaller is defined

namespace YourNamespace
{
    class Program
    {
        static async Task Main(string[] args)
        {
            OllamaCaller ollamaCaller = new OllamaCaller();
            await ollamaCaller.CallApi();
        }
    }
}
