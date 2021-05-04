using System;
using System.Drawing;
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
            if (pnlMembershipMenu.Visible)
            {
                pnlMembershipMenu.Visible = false;
                btnPlans.Location = new Point(btnPlans.Location.X, btnPlans.Location.Y - pnlMembershipMenu.Size.Height);
                btnDevices.Location = new Point(btnDevices.Location.X, btnDevices.Location.Y - pnlMembershipMenu.Size.Height);
                btnUsers.Location = new Point(btnUsers.Location.X, btnUsers.Location.Y - pnlMembershipMenu.Size.Height);
            }

            else
            {
                pnlMembershipMenu.Visible = true;
                btnPlans.Location = new Point(btnPlans.Location.X, btnPlans.Location.Y + pnlMembershipMenu.Size.Height);
                btnDevices.Location = new Point(btnDevices.Location.X, btnDevices.Location.Y + pnlMembershipMenu.Size.Height);
                btnUsers.Location = new Point(btnUsers.Location.X, btnUsers.Location.Y + pnlMembershipMenu.Size.Height);
            }
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
            var maxSize = this.GetWorkingAreaSize();

            if (Size == maxSize)
            {
                Size = MinimumSize;

                var spaceSize = new Size(maxSize.Width - MinimumSize.Width, maxSize.Height - MinimumSize.Height);

                Location = new Point(spaceSize.Width / 2, spaceSize.Height / 2);
            }

            else
            {
                Size = maxSize;
                Location = new Point();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width == 230)
            {
                tmrCollapseMenu.Start();

                if (pnlMembershipMenu.Visible)
                    btnMembership.PerformClick();
            }
            
            else if (pnlMenu.Width == 55)
            {
                tmrExpandMenu.Start();
                
                if(!pnlMembershipMenu.Visible)
                    btnMembership.PerformClick();
            }
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