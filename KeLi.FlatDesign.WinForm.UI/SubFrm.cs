using System.Windows.Forms;

namespace KeLi.FlatDesign.WinForm.UI
{
    public abstract partial class SubFrm : Form
    {
        protected SubFrm()
        {
            InitializeComponent();
        }

        protected SubFrm(Panel parent) : this()
        { 
            // ReSharper disable once VirtualMemberCallInConstructor
            Dock = DockStyle.Fill;

            TopLevel = false;
            Parent = parent;

            BringToFront();
        }
    }
}