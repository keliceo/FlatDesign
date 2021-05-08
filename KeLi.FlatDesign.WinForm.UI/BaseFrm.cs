using System.Windows.Forms;

using KeLi.FlatDesign.WinForm.UI.Utils;

namespace KeLi.FlatDesign.WinForm.UI
{
    public partial class BaseFrm : Form
    {
        protected BaseFrm()
        {
            InitializeComponent();
        }

        private void BaseFrm_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
                Handle.MoveWindow();
        }
    }
}