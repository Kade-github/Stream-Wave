using System.Drawing;
using System.IO;
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
        
        // Get settings
        public static Settings GetSettings()
        {
            if (File.Exists("settings.json"))
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json")); // Actually get custom settings
            return new Settings
                {TextColor = Color.White, BigWaves = false, ShowWatermark = true, TextSize = 14, TextCharacter = "|"}; // Defaults
        }

        public void SaveSettings() => File.WriteAllText("settings.json", JsonConvert.SerializeObject(this)); // Save this
        
    }
}