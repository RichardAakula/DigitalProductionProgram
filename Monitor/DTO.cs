using System;

namespace DigitalProductionProgram.Monitor
{
    // Note that this could be implemented as an interface instead, or could even be completely skipped if writing the adresses manually for each call is preferred. 
    public class DTO
    {
        public virtual string URL => throw new NotImplementedException();
    }
}