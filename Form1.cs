using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpdaterService.Net;

namespace LuckyVPlayerCount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 5000;
            timer1.Start();
            timer1.Tick += Timer_Tick;

            timer1.Start();

            try
            {
                this.BackColor = Color.Black;
                if (File.Exists("playercount.txt"))
                {
                    playercount.Text = File.ReadAllText("playercount.txt");
                }

                if (File.Exists("fontsetting.txt"))
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    // Load an instance of Font from a string
                    fontDialog2.Font = (Font)converter.ConvertFromString(File.ReadAllText("fontsetting.txt"));
                }

                if (File.Exists("fontcolorsetting.txt"))
                {
                    playercount.ForeColor = Color.FromArgb(Convert.ToInt32(File.ReadAllText("fontcolorsetting.txt")));
                }
                

                if (File.Exists("colorsetting.txt"))
                {
                    // Load an instance of Font from a string
                    this.BackColor = Color.FromArgb(Convert.ToInt32(File.ReadAllText("colorsetting.txt")));
                }

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            // get player count
            // https://api.altstats.net/api/v1/server/998/ (obsolete)
            // https://api.altv.mp/servers/list

            try
            {
                var remoteUri = new Uri("https://api.altv.mp/servers/list");

                var http = new Fetch { Retries = 5, RetrySleep = 500, Timeout = 5000 };
                http.Load(remoteUri.AbsoluteUri);
                if (!http.Success)
                {
                    return;
                }
                string data = "{\"item\": "+Encoding.UTF8.GetString(http.ResponseData)+"}";

                dynamic stuff = JObject.Parse(data);

                foreach(dynamic item in stuff.item)
                {
                    if (item.id.ToString() == "bb7228a0d366fc575a5682a99359424f")
                    {
                        playercount.Text = item.players.ToString();
                    }
                } 
                File.WriteAllText("playercount.txt",playercount.Text);

            } catch(Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FontDialog fontDlg = new FontDialog();
            //fontDialog2.ShowDialog();
            fontDialog2.ShowColor = true;
            fontDialog2.ShowApply = true;
            fontDialog2.ShowEffects = true;
            fontDialog2.ShowHelp = true;
            fontDialog2.Font = playercount.Font;
            fontDialog2.Color = playercount.ForeColor;

            if (fontDialog2.ShowDialog() != DialogResult.Cancel)
            {
                playercount.Font = fontDialog2.Font;
                playercount.ForeColor = fontDialog2.Color;
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                // Saving Font object as a string
                string fontString = converter.ConvertToString(fontDialog2.Font);
                File.WriteAllText("fontsetting.txt", fontString);
                File.WriteAllText("fontcolorsetting.txt", fontDialog2.Color.ToArgb().ToString());

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            colorDialog1.ShowHelp = true;
            // Sets the initial color select to the current text color.
            colorDialog1.Color = this.BackColor;

            // Update the text box color if the user clicks OK 
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText("colorsetting.txt", this.BackColor.ToArgb().ToString());
                this.BackColor = colorDialog1.Color;
            }


        }
    }
}
