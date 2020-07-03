using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Stream_Wave
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        private void TextBoxGotFocus(object sender, EventArgs args) => HideCaret(textBox1.Handle); // hide carret

        // Variables
        public static Settings settings;
        public static Thread th;
        
        
        public Form1()
        {
            InitializeComponent();
            // Setup settings
            settings = Settings.GetSettings(); // get settings
            textBox1.Font = new Font("Arial", settings.TextSize);
            textBox1.ForeColor = settings.TextColor;
            textBox1.ReadOnly = true;
            textBox1.GotFocus += TextBoxGotFocus;
            
            HideCaret(textBox1.Handle); // hide it
            
            if (!settings.ShowWatermark) // Watermark setting
                label1.Text = "";
            
            CheckForIllegalCrossThreadCalls = false; // Allow the thread to fuck with the ui
            
            th = new Thread(() =>
            {
                // wav stuff
                WasapiLoopbackCapture CaptureInstance = new WasapiLoopbackCapture();
                CaptureInstance.DataAvailable += (s, a) =>
                {
                    float max = 0;
                    var buffer = new WaveBuffer(a.Buffer);
                    // interpret as 32 bit floating point audio
                    for (int index = 0; index < a.BytesRecorded / 4; index++)
                    {
                        var sample = buffer.FloatBuffer[index];

                        // absolute value 
                        if (sample < 0) sample = -sample;
                        // is this the max value?
                        if (sample > max) max = sample;
                    }

                    if (!max.Equals(0))
                    {
                        if (settings.AudioWarning)
                            textBox1.Text = textBox1.Text.Replace("No audio detected...", "");
                        textBox1.Text += CalcTheAnimation(max * 100) + "\r\n";
                    }
                    else
                        textBox1.Text = settings.AudioWarning ? "No audio detected..." : "";
                };
                // Record
                CaptureInstance.StartRecording();
                // sleeeep
                Thread.Sleep(-1);
            });
            // start
            th.Start();
            // No scroll bars and align correctly.
            textBox1.ScrollBars = ScrollBars.None;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // Close the thread and then save settings and gtfo
            FormClosed += (sender, args) =>
            {
                th.Abort();
                settings.SaveSettings();
                Application.Exit();
            };
        }

        public static string CalcTheAnimation(float peak)
        {
            // Simple animation calc
            string p;
            string bars = "";
            for (int i = 0; i < peak; i++)
            {
                if (!settings.BigWaves)
                {
                    if (i % 5 == 0) bars += settings.TextCharacter;
                }
                else bars += settings.TextCharacter;
            }
            p = bars + bars;
            return p;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Go to the end of the selection
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
    }
}
