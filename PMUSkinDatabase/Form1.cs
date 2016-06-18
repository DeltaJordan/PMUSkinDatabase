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
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/91D688473A5A4A5QQWE2025091EWQS/2lcr4og.jpg");
            }

            if (listBox1.GetSelected(1) == true){
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/9B9E06DA3A5A4A5QQWE2025092EWQS/azurill.png");
            }

            if (listBox1.GetSelected(2) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/A413ECB33A5A4A5QQWE2025099EWQS/Buizelskin2.png");
            }

            if (listBox1.GetSelected(3) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://178.33.61.6/putstorage/DownloadFileHash/A4A64A5C3A5A4A5QQWE3371594EWQS/cheribi.jpg");
            }

            if (listBox1.GetSelected(4) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/391C726B3A5A4A5QQWE2025144EWQS/chimeco.jpg");
            }

            if (listBox1.GetSelected(5) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/C9CFAB9B3A5A4A5QQWE2025109EWQS/Flareonthememainmenu.png");
            }

            if (listBox1.GetSelected(6) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/A66B1CE73A5A4A5QQWE2025118EWQS/Ariel.jpg");
            }

            if (listBox1.GetSelected(7) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://178.33.61.6/putstorage/DownloadFileHash/F80BBDB03A5A4A5QQWE3371586EWQS/Legends.jpg");
            }

            if (listBox1.GetSelected(8) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/551E37E43A5A4A5QQWE2025137EWQS/Raichu.jpg");
            }

            if (listBox1.GetSelected(9) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/8FE876173A5A4A5QQWE2025138EWQS/6095497493_dc292804a1_b.jpg");
            }

            if (listBox1.GetSelected(10) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/755CE3F83A5A4A5QQWE2025102EWQS/vulpix.png");
            }

            if (listBox1.GetSelected(11) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/738BEC983A5A4A5QQWE2025198EWQS/Sekia.png");
            }

            if (listBox1.GetSelected(12) == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("http://srv70.putdrive.com/putstorage/DownloadFileHash/D0A544BA3A5A4A5QQWE2025197EWQS/minunplusapreview1.png");
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
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/B12F2D953A5A4A5QQWE2025169EWQS/Ampharos%20Theme.zip";

            }

            if (listBox1.GetSelected(1) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/928B371C3A5A4A5QQWE2025164EWQS/Azurill.pmuskn.zip";

            }

            if (listBox1.GetSelected(2) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/0B6FFC463A5A4A5QQWE2025165EWQS/Buizel%20Theme.zip";

            }

            if (listBox1.GetSelected(3) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/28FB8BC23A5A4A5QQWE2025167EWQS/Cherubi%20_%20Cherrim.pmuskn.zip";

            }

            if (listBox1.GetSelected(4) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/4205DE6A3A5A4A5QQWE2025264EWQS/Chimeco.zip";

            }

            if (listBox1.GetSelected(5) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/A656EEDE3A5A4A5QQWE2025172EWQS/Flareon%20Theme.zip";

            }

            if (listBox1.GetSelected(6) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/65DFF8453A5A4A5QQWE2025171EWQS/Aerial%20Avians%20Skin.zip";

            }

            if (listBox1.GetSelected(7) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/0FEB62DD3A5A4A5QQWE2025168EWQS/Legendary%20Skin%20PMU.zip";

            }

            if (listBox1.GetSelected(8) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/C53A35753A5A4A5QQWE2025166EWQS/Raichu%20skin.pmuskn.zip";

            }

            if (listBox1.GetSelected(9) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/B6479BED3A5A4A5QQWE2025170EWQS/Umbreon%20skin.pmuskn.zip";

            }

            if (listBox1.GetSelected(10) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/150D02093A5A4A5QQWE2025263EWQS/Vulpix.zip";

            }

            if (listBox1.GetSelected(11) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/0A58E6283A5A4A5QQWE2025195EWQS/Seika%20with%20Music.zip";

            }

            if (listBox1.GetSelected(12) == true)
            {
                stringLink = "http://srv70.putdrive.com/putstorage/DownloadFileHash/C02B2A313A5A4A5QQWE2025246EWQS/Minun%20_%20Plusle.pmuskn.zip";

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

            ZipFile.ExtractToDirectory(Path.Combine(skindirectory, "Downloads\\tempskin.zip"), skindirectory);
            File.Delete(Path.Combine(skindirectory, "Downloads\\tempskin.zip"));

            MessageBox.Show("Skin has been applied! Go into game, click skins, then click the words Main Theme, and choose the new one!",
                    "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
