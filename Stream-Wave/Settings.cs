using System.Drawing;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Stream_Wave
{
    public class Settings
    {
        // J S O N  P O G
        [JsonProperty("textColor")] 
        public Color TextColor { get; set; }
        
        [JsonProperty("textSize")] 
        public int TextSize { get; set; }
        
        [JsonProperty("bigWaves")] 
        public bool BigWaves { get; set; }
        
        [JsonProperty("showWatermark")] 
        public bool ShowWatermark { get; set; }

        [JsonProperty("textCharacter")] 
        public string TextCharacter { get; set; }
        
        [JsonProperty("audioDetectedWarning")] 
        public bool AudioWarning { get; set; }

        // Get settings
        public static Settings GetSettings()
        {
            if (File.Exists("settings.json"))
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json")); // Actually get custom settings
            return new Settings
                {TextColor = Color.White, BigWaves = true, ShowWatermark = true, TextSize = 14, TextCharacter = "|", AudioWarning = true}; // Defaults
        }

        public void SaveSettings() => File.WriteAllText("settings.json", JsonConvert.SerializeObject(this, Formatting.Indented), Encoding.Default); // Save this
        
    }
}