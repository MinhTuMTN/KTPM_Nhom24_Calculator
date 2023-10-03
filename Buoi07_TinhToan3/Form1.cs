using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            double? so1, so2, kq = 0;

            so1 = convertToNumber(txtSo1, e);
            so2 = convertToNumber(txtSo2, e);

            if (so1 == null || so2 == null)
                return;

            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.SelectAll();
        }

        private double? convertToNumber(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string message = "";
            double result = 0;
            if (textBox.Text.Trim().Length == 0)
                message = "Đầu vào không được để trống";
            else if (!double.TryParse(textBox.Text, out result))
                message = "Đầu vào không hợp lệ";

            if (message.Length > 0)
            {
                MessageBox.Show(message, "Thông báo");
                textBox.Focus();
                textBox.SelectAll();
                return null;
            }
            return result;
        }
    }
}
