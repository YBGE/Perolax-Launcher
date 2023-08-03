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
            InitEnd(); //Since Project Perolax is currently empty, we are skipping to step 5 (The Loader is literally just a space holder for now)
        }
        #endregion

        #region InitSteps
        //Check if the Launcher is Up2Date, if not update
        public void step1_LauncherUpdater()
        {
            //Place Holder currently
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