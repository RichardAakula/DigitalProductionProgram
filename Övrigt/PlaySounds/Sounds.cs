using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalProductionProgram.Övrigt.PlaySounds
{
    internal class Sounds
    {
        private static IWavePlayer waveOut;
        private static WaveStream mp3Reader;

        public static void PlayGollum()
        {
            var mp3Data = Properties.Resources.Gollum;
            var ms = new MemoryStream(mp3Data);

            // Set up the MP3 reader and output device
            mp3Reader = new Mp3FileReader(ms);
            waveOut = new WaveOutEvent();
            waveOut.Init(mp3Reader);
            waveOut.Play();

            // Optional: stop/dispose when playback ends
            waveOut.PlaybackStopped += (s, e) =>
            {
                waveOut.Dispose();
                mp3Reader.Dispose();
                ms.Dispose();
            };
        }
    }
}
