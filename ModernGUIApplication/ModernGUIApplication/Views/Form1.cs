using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernGUIApplication
{
    public partial class MainMenu : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public MainMenu()
        {
            InitializeComponent();
            random = new Random();
        }
        //methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
               index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }
        private void OpenChildForm(Form childForm,object btnSender)
        {
            if (activeForm!= null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
           // this.panelDesktop.Tag
       
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        




        
    }
}
