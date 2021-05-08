using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using KeLi.FlatDesign.WinForm.UI.Utils;

namespace KeLi.FlatDesign.WinForm.UI
{
    public partial class ProgressBarFrm : BaseFrm
    {
        private readonly int _totalNum;

        private readonly string _completeTitle;

        private ProgressBarFrm()
        {
            InitializeComponent();
        }

        public ProgressBarFrm(Form parent, int totalNum, string loadingTitle = null, string completeTitle = null): this()
        {
            _totalNum = totalNum;

            if (!string.IsNullOrWhiteSpace(loadingTitle))
                lblTitle.Text = loadingTitle;

            _completeTitle = completeTitle;

            Visible = true;
            this.ComputeLocation(parent);
        }

        public void UpdateProgress(int completedNum)
        {
            var totalLength = pnlBorder.Size.Width - 4;
            var progress = completedNum * 1.0 / _totalNum;
            var currentWidth = (int)Math.Round(progress * totalLength);

            pnlProgress.Size = new Size(currentWidth, pnlProgress.Size.Height);
            lblProgress.Text = completedNum.ToString("N0") + "/" + _totalNum.ToString("N0");
            Refresh();

            if (completedNum == _totalNum)
            {
                if (!string.IsNullOrWhiteSpace(_completeTitle))
                {
                    lblTitle.Text = _completeTitle;
                    Refresh();
                }

                Thread.Sleep(1000);

                Close();
            }
        }
    }
}
