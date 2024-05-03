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
        public bool column = false, framing = false, slab = false, wall = false, foundation = false, shaft = false, stairs = false, fail = false;
        
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

        }

        private void button2_Click(object sender, EventArgs e) // adjust
        {
            confirmButton.DialogResult = DialogResult.OK;
            Debug.WriteLine("OK button was clicked");
            fail = true;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e) // col
        {
            if (columnCheck.Checked)
            {
                column = true;
            }
            else
                column = false;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) // fr
        {
            if (framingCheck.Checked)
            {
                framing = true;
            }
            else
                framing = false;
        }

        private void stairsCheck_CheckedChanged(object sender, EventArgs e) // stairs
        {
            if (stairsCheck.Checked)
            {
                stairs = true;
            }
            else
                stairs = false;
        }

        private void shaftCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (shaftCheck.Checked)
            {
                shaft = true;
            }
            else
                shaft = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void foundationCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (foundationCheck.Checked)
            {
                foundation = true;
            }
            else
                foundation = false;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) // wa
        {
            if (wallCheck.Checked)
            {
                wall = true;
            }
            else
                wall = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) // slab
        {
            if (slabCheck.Checked)
            {
                slab = true;
            }
            else
                slab = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
