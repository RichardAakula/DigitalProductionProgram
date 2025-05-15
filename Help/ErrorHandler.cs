using System;
using DigitalProductionProgram.Log;

namespace DigitalProductionProgram.Help
{
    internal class ErrorHandler
    {
        public static async void Allmänt_Fel(Exception exception, string fel)
        {
            await Activity.Stop($@"Allmänt Fel: {exception.Message} - {fel}");
        }
    }
}
