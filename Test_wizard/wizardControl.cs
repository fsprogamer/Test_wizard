using System;
using System.Windows.Forms;
using AeroWizard;

namespace Test_wizard
{
    public partial class MainWizard : Form
    {
        int page_index = 0;
        const string FlowPanelName = "FlowPanel";

        public MainWizard()
        {
            InitializeComponent();
        }

        private void MainWizard_Load(object sender, EventArgs e)
        {

            page_index = 0;
            WizardPage page = new WizardPage();
            page.Text = page_index.ToString();
            page.Commit += wizardPage_Commit;
                  
            wizardControl.Pages.Add(page);

            FlowLayoutPanel flpanel = new FlowLayoutPanel();

            flpanel.FlowDirection = FlowDirection.TopDown;
            flpanel.AutoSize = true;
            flpanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpanel.WrapContents = true;
            flpanel.Dock = DockStyle.Fill;
            flpanel.Name = FlowPanelName;

            wizardControl.SelectedPage.Controls.Add(flpanel);

            for (int i = 0; i < 10; i++)
            {
                RadioButton box = new RadioButton();
                box.Text = i.ToString();
                box.AutoSize = true;
                box.Dock = System.Windows.Forms.DockStyle.Fill;
                box.Tag = i;
                flpanel.Controls.Add(box);
            }

            page = new WizardPage();
            wizardControl.Pages.Add(page);

            wizardControl.RestartPages();
        }

        void wizardPage_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {          
            //int forms_visit_id = 0;

            FlowLayoutPanel flpanel = (FlowLayoutPanel)e.Page.Controls[FlowPanelName];
            RadioButton rb = new RadioButton();

            if (1 != 0)
            {
                
                page_index++;
                wizardControl.Pages[page_index].Text = page_index.ToString();
                wizardControl.Pages[page_index].Commit += wizardPage_Commit;
                //wizardControl.Pages[page_index].Initialize += wizardPage_Initialize;

                FlowLayoutPanel flpanel_next = new FlowLayoutPanel();
                flpanel_next.FlowDirection = FlowDirection.TopDown;
                flpanel_next.AutoSize = true;
                flpanel_next.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flpanel_next.WrapContents = true;
                flpanel_next.Dock = DockStyle.Fill;
                flpanel_next.Name = FlowPanelName;

                wizardControl.Pages[page_index].Controls.Add(flpanel_next);

                for (int i=0; i<10; i++)
                {
                    RadioButton box = new RadioButton();
                    box.Text = i.ToString();
                    box.AutoSize = true;
                    box.Dock = System.Windows.Forms.DockStyle.Fill;
                    box.Tag = i;
                    flpanel_next.Controls.Add(box);
                }

                WizardPage page = new WizardPage();
                wizardControl.Pages.Add(page);

                //wizardControl.PreviousPage();
                wizardControl.RestartPages();
            }
            else
            {
                WizardPage finish_page = new WizardPage();
                finish_page.IsFinishPage = true;
                wizardControl.Pages.Add(finish_page);
            }
        }
    }
}
