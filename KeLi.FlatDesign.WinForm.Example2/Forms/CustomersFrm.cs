using System;

using KeLi.FlatDesign.WinForm.Example2.Utils;
using KeLi.FlatDesign.WinForm.UI;

namespace KeLi.FlatDesign.WinForm.Example2.Forms
{
    public partial class CustomersFrm : BaseFrm
    {
        public CustomersFrm()
        {
            InitializeComponent();
        }

        private void CustomersFrm_Load(object sender, EventArgs e)
        {
            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.DataSource = CustomerUtil.GetCustomerModels();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            (ParentForm as MainFrm)?.ShowDefaultContent(true);

            Close();
        }
    }
}