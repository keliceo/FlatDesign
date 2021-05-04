using System;
using System.Windows.Forms;

namespace KeLi.FlatDesign.WinForm.UI
{
    public partial class MessageBoxFrm : BaseFrm
    {
        private MessageBoxFrm()
        {
            InitializeComponent();
        }

        public MessageBoxFrm(string message) : this()
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            txtMessage.Text = message;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}