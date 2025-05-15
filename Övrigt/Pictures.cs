using System.IO;
using System.Reflection;

namespace DigitalProductionProgram.Övrigt
{
    internal class Pictures
    {
        private static readonly Assembly assembly = Assembly.GetExecutingAssembly();

        public class WeatherIcons
        {
            public static Stream Clear_Sky_Day => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.clear sky.png");
            public static Stream Clear_Sky_Night => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.clear sky 2.png");
            public static Stream Scattered_Clouds => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.scattered clouds.png");
            public static Stream Broken_Clouds => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.Broken clouds.png");
            public static Stream Light_Rain => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.Light Rain.png");
            public static Stream Light_Rain_Night => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.Light Rain Night.png");
            public static Stream Light_Intensity_Rain => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.Light Intensity Rain.png");
            public static Stream Few_Clouds => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.Few Clouds.png");
            public static Stream Few_Clouds_Night => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.Few Clouds Night.png");
            public static Stream Mist => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.WeatherIcons.Mist.png");
        }

        public class Tubes
        {
            public static Stream Neutral_1Layer => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.Cross_Section_Tube._1_Layer.Neutral.png");
            public static Stream Neutral_2Layer => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.Cross_Section_Tube.2_Layer.Neutral.png");
            public static Stream Neutral_3Layer => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.Cross_Section_Tube.3_Layer.Neutral.png");
        }

        public class Icons
        {
            public static Stream Info => assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.Icons.Info.png");
        }
    }
}
