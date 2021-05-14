using System;
using System.Linq;
using System.Windows.Forms;
using CodeFirstClass.Models;

namespace CodeFirstClass
{
    public partial class SubjectTeacher : Form
    {
        public CodeFirst db = new CodeFirst();
        public SubjectTeacher()
        {
            InitializeComponent();
            ReloadAllGrid();
            ReloadClassesTeacherCombo();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxteacher.Text))
            {
                var Teacher = new Teacher()
                {
                    Name = textBoxteacher.Text
                };
                db.ClassTeacher.Add(Teacher);
                db.SaveChanges();
                ReloadTeachersGrid();
                textBoxteacher.Text = "";
                ReloadClassesTeacherCombo();

            }

        }

        void ReloadClassesTeacherCombo()
        {
            var teachers = db.ClassTeacher.ToList();
            comboBox1.DataSource = teachers.Select(p => $"{p.id}-{p.Name}").ToList();
            comboBox1.Refresh();
        }

        private void SubjectTeacher_Load(object sender, EventArgs e)
        {
            //var teachersList = db.ClassTeacher.ToList();
            //var classList = db.Class.ToList();
        }

        void ReloadTeachersGrid()
        {
            dataGridView1.DataSource = db.ClassTeacher.ToList();
            dataGridView1.Refresh();
        }
        void ReloadClassGrid()
        {
            dataGridView2.DataSource = db.Class.ToList();
            dataGridView2.Refresh();
        }
        void ReloadSubjectsGrid()
        {
            dataGridView3.DataSource = db.Subjects.ToList();
            dataGridView3.Refresh();
        }
        void ReloadAllGrid()
        {
            ReloadTeachersGrid();
            ReloadClassGrid();
            ReloadSubjectsGrid();

        }
    }
}
