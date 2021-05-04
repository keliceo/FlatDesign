using System;
using System.Linq;
using System.Windows.Forms;

using KeLi.FlatDesign.WinForm.Example2.Forms;
using KeLi.FlatDesign.WinForm.UI;

namespace KeLi.FlatDesign.WinForm.Example2
{
    public partial class MainFrm : BaseFrm
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void PnlMenu_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
                Handle.MoveWindow();
        }

        private void PnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
                Handle.MoveWindow();
        }

        private void PnlContent_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
                Handle.MoveWindow();
        }

        private void PnlUser_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
                Handle.MoveWindow();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.OfType<Form>().ToList().ForEach(pnlContent.Controls.Remove);

            new DashboardFrm(pnlContent).Show();
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.OfType<Form>().ToList().ForEach(pnlContent.Controls.Remove);

            new CustomersFrm(pnlContent).Show();
        }

        private void BtnMembership_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.OfType<Form>().ToList().ForEach(pnlContent.Controls.Remove);

            new MembershipFrm(pnlContent).Show();
        }

        private void BtnPlans_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.OfType<Form>().ToList().ForEach(pnlContent.Controls.Remove);

            new PlansFrm(pnlContent).Show();
        }

        private void BtnDevices_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.OfType<Form>().ToList().ForEach(pnlContent.Controls.Remove);

            new DevicesFrm(pnlContent).Show();
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.OfType<Form>().ToList().ForEach(pnlContent.Controls.Remove);

            new UsersFrm(pnlContent).Show();
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnMax_Click(object sender, EventArgs e)
        {
            Size = Size == MaximumSize ? MinimumSize : MaximumSize;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void ShowDefaultContent(bool flag)
        {
            pbContentLogo.Visible = flag;
            lblDefaultTxt.Visible = flag;
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width == 230)
                tmrCollapseMenu.Start();

            else if (pnlMenu.Width == 55)
                tmrExpandMenu.Start();
        }

        private void TmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void TmrExpandMenu_Tick(object sender, EventArgs e)
        {
            if (pnlMenu.Width >= 230)
                tmrExpandMenu.Stop();

            else
                pnlMenu.Width += 5;
        }

        private void TmrCollapseMenu_Tick(object sender, EventArgs e)
        {
            if (pnlMenu.Width <= 55)
                tmrCollapseMenu.Stop();

            else
                pnlMenu.Width -= 5;
        }
    }
}