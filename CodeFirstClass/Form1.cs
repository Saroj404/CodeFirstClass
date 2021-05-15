using System;
using System.Collections.Generic;
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
            ReloadSubjectClassCombo();
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
            var source = new List<string> { "" };
            source.AddRange(teachers.Select(p => $"{p.id}-{p.Name}").ToList());
            comboBox1.DataSource = source;
            comboBox1.Refresh();
        }
        void ReloadSubjectClassCombo()  
        {
            var classes = db.Class.ToList(); 
            var source = new List<string> ();
            source.AddRange(classes.Select(p => $"{p.id}-{p.ClassName}").ToList());
            comboBox3.DataSource = source;
            comboBox3.Refresh();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBoxclass.Text))
            {
                Classes classobj = new Classes() { ClassName = textBoxclass.Text };
                if(comboBox1.SelectedIndex>0)
                {
                    var item = (string)comboBox1.SelectedItem;
                    var array = item.Split('-');
                    var teacherid = Convert.ToInt32(array[0]);
                    classobj.TeacherId = teacherid;
                }
                db.Class.Add(classobj);
                db.SaveChanges();
                textBoxclass.Text = "";
                comboBox1.SelectedIndex = 0;
                ReloadClassGrid();
                ReloadSubjectClassCombo();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textSubject.Text) && !string.IsNullOrWhiteSpace(textCode.Text)
                && comboBox3.SelectedIndex >= 0)
            {
                Subjects subjects = new Subjects()
                {
                    SubjectName = textSubject.Text,
                    SubjectCode = textCode.Text
                };
                var item = (string)comboBox3.SelectedItem;
                var array = item.Split('-');
                var classId = Convert.ToInt32(array[0]);
                subjects.ClassId = classId;
                db.Subjects.Add(subjects);
                db.SaveChanges();
                textSubject.Text = "";
                textCode.Text = "";
                comboBox3.SelectedIndex = 0;
                ReloadSubjectsGrid();
            }

            
        }
    }
}
