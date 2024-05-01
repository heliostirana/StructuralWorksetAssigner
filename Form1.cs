using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HLO
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private UIApplication uiapp;
        private UIDocument uidoc;
        private Autodesk.Revit.ApplicationServices.Application app;
        private Document doc;
        public string worksetName = "";
        
        public Form1(ExternalCommandData commandData)
        {
            InitializeComponent();

            uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;


        }

        private void label1_Click(object sender, EventArgs e)
        {
            worksetName = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e) // adjust
        {
            worksetName = textBox1.Text;
            confirmButton.DialogResult = DialogResult.OK;
            Debug.WriteLine("OK button was clicked");
            Close();

            return;
        }

        private void button1_Click(object sender, EventArgs e) // cancel
        {
            cancelButton.DialogResult = DialogResult.Cancel;
            Debug.WriteLine("Cancel button was clicked");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
