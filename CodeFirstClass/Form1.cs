using System;
using System.Windows.Forms;
using CodeFirstClass.Models;

namespace CodeFirstClass
{
    public partial class Form1 : Form
    {
        public CodeFirst db = new CodeFirst();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            var Teacher = new Teacher()
            {
                Name = textBoxteacher.Text
            };
            db.ClassTeacher.Add(Teacher);
            db.SaveChanges();
               
           
        }
    }
}
