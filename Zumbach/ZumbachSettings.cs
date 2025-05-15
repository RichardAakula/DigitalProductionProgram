using Microsoft.Extensions.Configuration;
using System.IO.Ports;
using System.Text.Json.Serialization;
using System.Text.Json;
using static DigitalProductionProgram.Settings.Settings.Zumbach;

namespace DigitalProductionProgram.Zumbach
{
    public class ZumbachSettings
    {
        public string Portname { get; set; } = "COM1";
        public int Baudrate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public StopBits Stopbits { get; set; } = StopBits.One;
        public Handshake Handshake { get; set; } = Handshake.None;
        public string? Message { get; set; } = "g210";
        public int? DeleteMeasurements { get; set; } = 5;

        public static ZumbachSettings LoadComSettings()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

            if (!File.Exists(filePath))
                return new ZumbachSettings();

            var json = File.ReadAllText(filePath);
            var wrapper = JsonSerializer.Deserialize<ZumbachSettingsWrapper>(json);

            return wrapper?.ZumbachSettings ?? new ZumbachSettings();
        }
    }
}
