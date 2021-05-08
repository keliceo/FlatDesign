using System;
using System.Threading;
using System.Windows.Forms;

using KeLi.FlatDesign.WinForm.Example2.Utils;
using KeLi.FlatDesign.WinForm.UI;

namespace KeLi.FlatDesign.WinForm.Example2.Forms
{
    public partial class CustomersFrm : SubFrm
    {
        public CustomersFrm(Panel parent) : base(parent)
        {
            InitializeComponent();
        }

        private void CustomersFrm_Load(object sender, EventArgs e)
        {
            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.DataSource = CustomerUtil.GetCustomerModels();
        }
    }
}