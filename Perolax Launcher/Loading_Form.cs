using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using static Perolax_Launcher.GlobalVars;

namespace Perolax_Launcher
{
    public partial class Loading_Form : Form
    {
        #region Form
        public Loading_Form()
        {
            InitializeComponent();
        }

        private void Loading_Form_Load(object sender, EventArgs e)
        {

        }

        private void Loading_Form_Shown(object sender, EventArgs e)
        {
            label2.Text = "Step one _ Launcher Updater";
            Thread.Sleep(50);
            step1_LauncherUpdater();
            Thread.Sleep(50);
            label2.Text = "Finished!";
            InitEnd();
        }
        #endregion

        #region InitSteps
        //BackgroundWorker comes in the future
        //Cleanup comes in the future
        //^^THIS IS CURRENTLY ONLY A STRUCTURE: I WILL WORK ON IT LATER (if im not lazy, and you know coders...)^^
        //Check if the Launcher is Up2Date, if not update
        public void step1_LauncherUpdater()
        {
            string url = "https://raw.githubusercontent.com/YBGE/Perolax-Launcher/master/launcher_BuildVersion";
            string targetField = "launcher_BuildVersion";
            string extractedString = "";
            string version = "";
            JObject jsonObject;
            string Dir = @".\";

            try
            {

                if (File.Exists("cleanup.txt"))
                {
                    using (StreamReader reader = new StreamReader("cleanup.txt"))
                    {
                        string content = reader.ReadLine();
                        File.Delete(content);
                        File.Delete("cleanup.txt");
                    }
                }

                using (HttpClient client = new HttpClient())
                {
                    string json = client.GetStringAsync(url).Result;
                    jsonObject = JObject.Parse(json);

                    extractedString = jsonObject[targetField]?.ToString();

                    if (!string.IsNullOrEmpty(extractedString))
                    {
                        label2.Text = $"Extracted Build Version: {extractedString}";
                        version = extractedString;
                        Thread.Sleep(50);
                    }
                    else
                    {
                        label2.Text = $"Field '{targetField}' not found in the JSON data.";
                    }
                }

                if(extractedString != launcher_BuildVersion)
                {
                    targetField = "launcher_UpdateURL";
                    extractedString = jsonObject[targetField]?.ToString();

                    if (!string.IsNullOrEmpty(extractedString))
                    {
                        label2.Text = $"Extracted Update URL..";
                        Thread.Sleep(50);

                        //Install Update Code
                        try
                        {
                            //Generate a File to inform the Updated application that this old version needs to get deleted
                            using (StreamWriter writer = new StreamWriter("cleanup.txt"))
                            {
                                writer.WriteLine(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location));
                            }

                            //Now install the Update
                            // Download the update zip
                            using (var client = new WebClient())
                            {
                                string zipPath = Path.Combine(Dir, "update.zip");
                                if (!Directory.Exists(Dir))
                                {
                                    Directory.CreateDirectory(Dir);
                                }
                                client.DownloadFile(extractedString, zipPath);
                                ZipFile.ExtractToDirectory(zipPath, Dir);
                            }

                            Process.Start(Path.Combine(@".\", version + ".exe"));

                            // Exit
                            Application.Exit();
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        label2.Text = $"Field '{targetField}' not found in the JSON data.";
                    }
                }
            }
            catch (Exception ex)
            {
                label2.Text = $"An error occurred: {ex.Message}";
            }

        }

        //Get the Build Version of Project Perolax and store it in GlobalVars
        public void step2_perolax_BuildVersion()
        {
            //Place Holder currently
        }

        //Get the Release Date of the latest Project Perolax build and store it in GlobalVars
        public void step3_perolax_ReleaseDate()
        {
            //Place Holder currently
        }

        //Get the Tag of Update(Title) of the latest Project Perolax build and store it in GlobalVars
        public void step4_perolax_TagOfUpdate()
        {
            //Place Holder currently
        }

        //If Project Perolax is installed and is outdated, update it (else skip)
        public void step5_perolax_update()
        {
            //Place Holder currently
        }

        //Hide this and Show the Perolax Launcher UI
        public void InitEnd()
        {
            this.Hide();
            Launcher l = new Launcher();
            l.Show();
        }
        #endregion
    }
}