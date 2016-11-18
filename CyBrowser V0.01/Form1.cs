using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyBrowser_V0._01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // This function is called when the exit menu item is selected
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // This function opens a message box when the About menu item is selected
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This basic Web Browser was made by Cygran as his first project on November 18th 2016");
        }

        // This is the core function that will perform all navigation and control handling
        private void NavigateToPage()
        {
            toolStripStatusLabel1.Text = "Navigation has Started";
            button1.Enabled = false;
            textBox1.Enabled = false; 
            webBrowser1.Navigate(textBox1.Text);
        }

        // This Function is called when the Go Button is Pressed
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }
            
        // This function is called whenever a key is pressed and released in Text Bar
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the keystroke was enter then do something
            if (e.KeyChar == (char)ConsoleKey.Enter )
            {
                NavigateToPage();
            }
        }

        // This function reenables control and notifies ofter navigation is complete
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation Complete";
        }

        // This function is used to display the page processing progress
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            // Divide by 0 protection
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        
        }
    }
}
