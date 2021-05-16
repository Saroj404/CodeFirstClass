using CodeFirstClass.Services;
using CodeFirstClass.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstClass
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new UserLoginViewModel() { Username = txtusername.Text, Password = txtpassword.Text };
            var result = UserService.Login(model);
            if(result.Item1)
            {
                SubjectTeacher subjectteacher = new SubjectTeacher();
                subjectteacher.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.Item2);
            }
        }
    }
}
