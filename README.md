# Stream-Wave
Stream Wave is a software which displays a audio wave of anything that is playing, this can then be imported into a streaming software and shown on the streamers side for a nice audio wave effect!

# Video Showcase
https://youtu.be/SXvXNiJ0xQU

# Screenshots
![StreamWaveScreenshot](https://kadedev.software/screenshots/1z71h.png)

# How?
Step 0) Download the program from [here](https://github.com/KadeDev/Stream-Wave/latest)

Step 1) Run the program, and configure your settings.json

Step 2) Open up your streaming software and then capture the program window.

Step 3) Drag it anywhere you want in your stream overlay

Step 4) Use a chroma key, and key out the green.

Step 5) Just play any song and it will pickup on it! (**Only effects your stereo track, including game audio**)

# Default Settings
```
{
  "textColor": "White",
  "textSize": 14,
  "bigWaves": false,
  "showWatermark": true,
  "textCharacter": "|",
  "audioDetectedWarning": true
}
```

Documentation:


`textColor: Simple, just the text color. Don't make it green, becuase well. Obviously it will not show up.`


`textSize: Simple, the size of the text.`


`bigWaves: Allow for bigger audio waves to show up. (Doesn't have a size cap)`


`showWatermark: Enable or Disable the watermark in the bottom right.`


`textCharacter: What it uses to display the waves.`


`audioDetectedWarning: Shows a message instead of blanking out when audio isn't detected.`


# Contributing
PR it bby
