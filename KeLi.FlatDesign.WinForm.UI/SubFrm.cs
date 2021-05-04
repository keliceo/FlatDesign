using System;
using System.Windows.Forms;

namespace KeLi.FlatDesign.WinForm.UI
{
    public partial class SubFrm : Form
    {
        public SubFrm()
        {
            InitializeComponent();
        }

        public SubFrm(Panel parent) : this()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Dock = DockStyle.Fill;

            TopLevel = false;
            Parent = parent;

            BringToFront();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}