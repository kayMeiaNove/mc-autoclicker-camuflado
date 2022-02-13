using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace RobloxPlayer
{

    public partial class Form1 : Form
    {


        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            var Form2 = new Player();
            Form2.Show();
        }

        int mini;
        int maxi;
        IntPtr hWind;

        public string getActiveWindowName()
        {
            try
            {
                var activateHandle = GetForegroundWindow();

                Process[] processes = Process.GetProcesses();
                foreach (Process clsProcess in processes)
                {
                    if (activateHandle == clsProcess.MainWindowHandle)
                    {
                        string processName = clsProcess.ProcessName;
                        return processName;
                    }

                }
            }
            catch
            {

            }
            return null;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Rand_Tick(object sender, EventArgs e)
        {
            mini = 13 - 13;
            maxi = 15 + 15;
            Random rand = new Random();
        }

        private void Clicker_Tick(object sender, EventArgs e)
        {


            Clicker.Interval = 1000 / 13;
            Process[] processes = Process.GetProcessesByName("javaw");
            foreach (Process process in processes)
            {
                hWind = FindWindow(null, process.MainWindowTitle);
            }

            string currentWindow = getActiveWindowName();
            if (currentWindow == null)
            {
                return;
            }
            if (currentWindow.Contains("javaw"))
            {
                if (MouseButtons == MouseButtons.XButton2)
                {
                    label1.Text = "55jf";
                }


                if (MouseButtons == MouseButtons.XButton1)
                {
                    label1.Text = "55jr";
                }


                if(label1.Text == "55jf")
                {
                    if (MouseButtons == MouseButtons.Left)
                    {
                        try
                        {
                            PostMessage(hWind, 0x0201, 0, 0);
                            PostMessage(hWind, 0x0202, 0, 0);
                        }
                        catch
                        {
                            //erro
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
