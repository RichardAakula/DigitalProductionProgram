using System;
using DigitalProductionProgram.Log;

namespace DigitalProductionProgram.Help
{
    internal abstract class ErrorHandler
    {
        public static  void Allmänt_Fel(Exception exception, string fel)
        {
            _= Activity.Stop($@"Error: {exception.Message} - {fel}");
        }
    }
}
