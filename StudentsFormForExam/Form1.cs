using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsFormForExam
{
    public partial class Form1 : Form


    {
        List<int> ids = new List<int>();
        List<string> names = new List<string>();
        List<string> mobiles = new List<string>();
        List<string> addresses = new List<string>();
        List<int> ages = new List<int>();
        List<double> gpas = new List<double>();



        public Form1()
        {
            InitializeComponent();

            showButton.Enabled = false;
            searchButton.Enabled = false;

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string id = idTextBox.Text;
            string name = nameTextBox.Text;
            string mobile = mobileTextBox.Text;
            string address = addressTextBox.Text;
            string age = ageTextBox.Text;
            string gpa = gpaTextBox.Text;

            if (id == "" || name == "" || mobile == "" || address == "" || age == "" || gpa == "")
            {
                MessageBox.Show("Fill up all the fields");
                return;

            }

            if (id.Length != 4)
            {
                MessageBox.Show("Enter four digits please");
                return;
            }

            if (name.Length > 30)
            {
                MessageBox.Show("max 30 digits");
                return;
            }

            if (mobile.Length != 11)
            {
                MessageBox.Show("Invalid Mobile No");
                return;
            }

            double gpaPoint = Convert.ToDouble(gpaTextBox.Text);

            if (gpaPoint < 0 || gpaPoint > 4)
            {
                MessageBox.Show("Invalid GPA");
                return;
            }

            else
            {
                ids.Add(Convert.ToInt32(id));
                names.Add(name);
                mobiles.Add(mobile);
                addresses.Add(address);
                try
                {
                    ages.Add(Convert.ToInt32(age));
                }
                catch (Exception sd)
                {

                    MessageBox.Show("Please Enter numeric number!");
                }
                gpas.Add(Convert.ToDouble(gpa));

            }

            int index = ids.Count() - 1;
            showButton.Enabled = true;
            searchButton.Enabled = true;



            ShowStudentInfoOfDisplay(index, index);


            idTextBox.Clear();
            nameTextBox.Clear();
            mobileTextBox.Clear();
            addressTextBox.Clear();
            ageTextBox.Clear();
            gpaTextBox.Clear();

        }

        private void ShowStudentInfoOfDisplay(int startIndex, int endIndex)
        {
            showRichTextBox.Text = "";
            for (int i = startIndex; i <= endIndex; i++)
            {
                showRichTextBox.Text += "ID: " + ids[i] + ", " + "Name: " + names[i] + ", " + "Mobile Number: " + mobiles[i] + ", " + "Address: " + "," + addresses[i] +
                    ", " + "Age: " + ages[i] + "," + "GPA: " + gpas[i] + "\n";

            }

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowStudentInfoOfDisplay(0, ids.Count - 1);  //All Added information show

            // Mark check
            double maxgpa = gpas.Max();
            int index = gpas.IndexOf(maxgpa);
            string name = names[index];
            maxGpaTextBox.Text = maxgpa.ToString();
            maxNameTextBox.Text = name.ToString();

            double mingpa = gpas.Min();
            index = gpas.IndexOf(mingpa);
            name = names[index];
            minGpaTextBox.Text = mingpa.ToString();
            minNameTextBox.Text = name.ToString();

            double total = gpas.Sum();
            double avareage = total / gpas.Count();
            avrTextBox.Text = avareage.ToString();
            totalTextBox.Text = total.ToString();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (idRadioButton.Checked)
            {
                //string id = idTextBox.Text;
                //int index = ids.IndexOf(Convert.ToInt32(id));
                //showRichTextBox.Text = names[index] + ids[index] + addresses[index];
                //return;

                string id = searchTextBox.Text;
                int index = ids.IndexOf(Convert.ToInt32(id));
                showRichTextBox.Text = names[index] + ids[index] + addresses[index];
                return;

            }

            if (nameRadioButton.Checked)
            {
                string name = searchTextBox.Text;
                int index = names.IndexOf(name);
                showRichTextBox.Text = names[index] + ids[index] + addresses[index];
                return;

            }

            if (mobileRadioButton.Checked)
            {
                string mobile = searchTextBox.Text;
                int index = mobiles.IndexOf(mobile);
                showRichTextBox.Text = names[index] + ids[index] + addresses[index];
                return;

            }


        }
    }

}
