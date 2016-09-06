using System;
using System.Windows.Forms;
using AeroWizard;

namespace Test_wizard
{
    public partial class MainWizard : Form
    {
        //int page_index = 0;
        const string FlowPanelName = "FlowPanel";

        public MainWizard()
        {
            InitializeComponent();
        }

        private void MainWizard_Load(object sender, EventArgs e)
        {
            
            WizardPage page = new WizardPage();
            page.Tag = wizardControl.Pages.Count;
            page.Text = page.Tag.ToString();
            page.Commit += wizardPage_Commit;
                  
            wizardControl.Pages.Add(page);

            WizardPage nextpage = new WizardPage();
            wizardControl.Pages.Add(nextpage);

            wizardControl.RestartPages();
        }

        void wizardPage_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {          

                wizardControl.Pages[wizardControl.Pages.Count-1].Tag = wizardControl.Pages.Count-1;
                wizardControl.Pages[wizardControl.Pages.Count-1].Text = (wizardControl.Pages.Count-1).ToString();
                wizardControl.Pages[wizardControl.Pages.Count-1].Commit += wizardPage_Commit;

                WizardPage nextpage = new WizardPage();
                wizardControl.Pages.Insert(wizardControl.Pages.Count,nextpage);

                //wizardControl.RestartPages();
        }

        private void Pages_ItemAdded(object sender, System.Collections.Generic.EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            wizardControl.PreviousPage();
            throw new NotImplementedException();
        }
    }
}
