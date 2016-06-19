using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using NetFwTypeLib;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PMUSkinDatabase
{
    public partial class Form1 : Form{
        public Form1()
        {
            InitializeComponent();
            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            firewallRule.Description = "Allow downloading";
            firewallRule.ApplicationName = "\\PMUSkinDatabase.exe";
            firewallRule.Enabled = true;
            firewallRule.InterfaceTypes = "All";
            firewallRule.Name = "PMUSkinDatabase";

            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(firewallRule);
        }

        
        private string stringLink;
        private string skindirectory = "C:\\Program Files\\Pokemon Mystery Universe\\Client\\Client\\Skins";
        private string skinfilename;
        private string test;


        private void pictureBox1_Click(object sender, EventArgs e){

        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){

            if (!CheckForInternetConnection())
            {
                MessageBox.Show("This application needs an internet connection. Check your internet connection.", 
                    "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (listBox1.GetSelected(0) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\0.jpg"));
            }

            if (listBox1.GetSelected(1) == true){
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\1.png"));
            }

            if (listBox1.GetSelected(2) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\2.png"));
            }

            if (listBox1.GetSelected(3) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\3.jpg"));
            }

            if (listBox1.GetSelected(4) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\4.jpg"));
            }

            if (listBox1.GetSelected(5) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\5.png"));
            }

            if (listBox1.GetSelected(6) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\6.jpg"));
            }

            if (listBox1.GetSelected(7) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\7.jpg"));
            }

            if (listBox1.GetSelected(8) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\8.jpg"));
            }

            if (listBox1.GetSelected(9) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\9.jpg"));
            }

            if (listBox1.GetSelected(10) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\10.png"));
            }

            if (listBox1.GetSelected(11) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\11.png"));
            }

            if (listBox1.GetSelected(12) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\12.png"));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(skindirectory) == false)
            {
                MessageBox.Show("Select the correct folder of your Pokemon Mystery Universe skins. This is usually located in Local Disk, Program Files, Pokemon Mystery Universe, Client, Client, Skins.",
                    "Missing Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    skindirectory = folderBrowserDialog1.SelectedPath;
                }
            }
            if (Directory.Exists(skindirectory + "\\Downloads") == false)
            {
                Directory.CreateDirectory(skindirectory + "\\Downloads");
            }

            if (listBox1.GetSelected(0) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Ampharos+Theme.zip?index=11&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(1) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Azurill.pmuskn.zip?index=10&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(2) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Buizel+Theme.zip?index=9&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(3) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Cherubi+_+Cherrim.pmuskn.zip?index=8&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(4) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Chimeco.zip?index=14&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(5) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Flareon+Theme.zip?index=6&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(6) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Aerial+Avians+Skin+%281%29.zip?index=12&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(7) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Legendary+Skin+PMU.zip?index=5&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(8) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Raichu+skin.pmuskn.zip?index=3&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(9) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Umbreon+skin.pmuskn.zip?index=1&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(10) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Vulpix+Theme.rar?index=0&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(11) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Seika+with+Music.zip?index=2&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            if (listBox1.GetSelected(12) == true)
            {
                stringLink = "http://b2.ge.tt/gett/7gvJpZb2/Minun+_+Plusle.pmuskn.zip?index=4&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=";

            }

            WebClient client = new WebClient();

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);

            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            Uri uri = new Uri(stringLink);
            skinfilename = System.IO.Path.GetFileName(uri.LocalPath);
            client.DownloadFileAsync(new Uri(stringLink), Path.Combine(skindirectory, "Downloads\\tempskin.zip"));
            test = Path.Combine(skindirectory, "Downloads");

        }
        

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed. Skin will now be applied.",
                    "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                ZipFile.ExtractToDirectory(Path.Combine(skindirectory, "Downloads\\tempskin.zip"), skindirectory);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("This skin is already installed! Please select a different one, or if the skin dosen't work, try deleting it first from the Skins folder then reinstall it.",
                    "Skin already installed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.Delete(Path.Combine(skindirectory, "Downloads\\tempskin.zip"));
                Directory.Delete(Path.Combine(skindirectory, "Downloads"));
                Application.Exit();
            }
            File.Delete(Path.Combine(skindirectory, "Downloads\\tempskin.zip"));
            Directory.Delete(Path.Combine(skindirectory, "Downloads"));
            if (listBox1.GetSelected(7) == true)
            {
                File.Delete(Path.Combine(skindirectory, "_MACOSX"));
            }

            MessageBox.Show("Skin has been applied! Go into game, click skins, then click the words Main Theme, and choose the new one!",
                    "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
