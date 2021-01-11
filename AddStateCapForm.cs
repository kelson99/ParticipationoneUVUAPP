using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StateCapsSearchPart1
{
    public partial class AddStateCapForm : Form
    {

        string filename = "statecap.txt";

        public AddStateCapForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddStateCapForm_Load(object sender, EventArgs e)
        {

            StreamReader inputfile;

            try
            {
                inputfile = File.OpenText(filename);

                while (!inputfile.EndOfStream)
                {
                    LstBoxStateCaps.Items.Add(inputfile.ReadLine());
                }

                inputfile.Close();
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string userState = TxtBoxState.Text;
            string userCapital = TxtBoxCapital.Text;

            if (userState != "" && userCapital != "")
            {
                string statecap = userState + "," + userCapital;
                try
                {
                    StreamWriter outputfile = File.AppendText(filename);
                    outputfile.WriteLine(statecap);
                    outputfile.Close();

                    LstBoxStateCaps.Items.Add(statecap);
                    TxtBoxState.Clear();
                    TxtBoxCapital.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }


            }
        }
    }
}
