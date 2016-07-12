using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.ComponentModel;
using NetFwTypeLib;
using System.Diagnostics;
using System.Xml;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PMUSkinDatabase
{
    public partial class Form1 : Form{

        public Form1()
        {

            InitializeComponent();
            
            //setting.xml creator
            if (!(File.Exists(Path.Combine(Application.StartupPath, "settings.xml"))))
            {
                XmlTextWriter writer = new XmlTextWriter(Path.Combine(Application.StartupPath, "settings.xml"), System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("Settings");
                writer.WriteStartElement("FirewallEnabled");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }

            //
            //Firewall Entry
            //

            //XML Loading
            XmlDocument settingsXml = new XmlDocument();
            settingsXml.Load(Path.Combine(Application.StartupPath, "settings.xml"));
            XmlNode firewallException = settingsXml.DocumentElement["FirewallEnabled"];

            string firewallCheck = firewallException.InnerText;

            //Check if firewall has been set before.
            if (string.IsNullOrEmpty(firewallCheck))
            {
                //Add firewall exception
                INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                firewallRule.Description = "Allow downloading";
                firewallRule.ApplicationName = Path.Combine(Application.StartupPath, "PMUSkinDatabase.exe");
                firewallRule.Enabled = true;
                firewallRule.InterfaceTypes = "All";
                firewallRule.Name = "PMUSkinDatabase";
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                    Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Add(firewallRule);

                //Set firewall enabled to "true"
                firewallException.InnerText = "true";
                settingsXml.Save(Path.Combine(Application.StartupPath, "settings.xml"));

            }
            
        }

        
        public static bool isDebugEnabled = false;

        string tempFolder = (Path.Combine(Application.StartupPath, "temp"));

        //An easier way to add downloads to the database
        private string[] skinUrl = new string[] 
        {
            "http://b2.ge.tt/gett/7gvJpZb2/Ampharos+Theme.zip?index=11&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Azurill.pmuskn.zip?index=10&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Buizel+Theme.zip?index=9&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Cherubi+_+Cherrim.pmuskn.zip?index=8&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Chimeco.zip?index=14&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Flareon+Theme.zip?index=6&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Aerial+Avians+Skin+%281%29.zip?index=12&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b1.ge.tt/gett/7gvJpZb2/Legendary+Skin+PMU.zip?index=5&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Raichu+skin.pmuskn.zip?index=3&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Umbreon+skin.pmuskn.zip?index=1&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Vulpix.zip?index=13&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Seika+with+Music.zip?index=15&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/7gvJpZb2/Minun+_+Plusle.pmuskn.zip?index=4&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/BoneBrothersTheme.zip?index=11&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/79YF6sb2/PMU+Chandelure+Family.zip?index=0&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8mdv4sb2/Chinchou+Skin.zip?index=6&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/PMU+Eeveelution+skin.zip?index=2&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/FennekinSkin.zip?index=4&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/PMU+gardevoir+skin.zip?index=3&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5P6s7sb2/PMU+ho-oh.zip?index=0&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/Jirachi+Skin.zip?index=10&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/Pikachu+%2B+Family+Theme+v1+by+Whitewing.zip?index=5&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8mdv4sb2/Salamence+Skin.zip?index=1&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8mdv4sb2/Snivy+Skin.zip?index=0&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/Snivy+%2B+Family+Theme+v1+by+Whitewing.zip?index=9&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8mdv4sb2/Space+%26+Time.zip?index=5&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/PMU+Tyranitar+Fam.zip?index=1&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/5rED3sb2/Zangtyph+skin.zip?index=7&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8mdv4sb2/Tyranitar+Skin.zip?index=4&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/2PUo9sb2/Hatsune%2BMiku%2BTheme.zip?index=1&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Bladed+Beasts.zip?index=23&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/yveltal+skin.zip?index=21&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/xerneas+skin.zip?index=22&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Whimsicott+Skin.zip?index=19&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Torterra.zip?index=20&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Shaymin+Skin+V3+Alternate+Title+Music.zip?index=16&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Seviper+Skin.zip?index=17&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Reshiram+skin.zip?index=18&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Pok%C3%A9mon+Mystery+Dungeon+Theme.zip?index=13&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Pikachu+Shiny+Pikachu.zip?index=14&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Pachi+Theme.zip?index=15&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/LuxraySkin.zip?index=11&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Lugia+Skin.zip?index=10&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Lucario+Skin.zip?index=8&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Lady+Rainicorn+Skin.zip?index=12&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Jirachi+Skin.zip?index=9&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Glorious+Grass+Skin.zip?index=6&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/FurorOfTheFishesSkin.zip?index=7&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Empoleon+Skin.zip?index=5&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Emolga+Skin.zip?index=3&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Eeveelutions+Skin.zip?index=4&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Drahsids+Theme.zip?index=0&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Charmander+Theme.zip?index=1&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Bulbasaur.zip?index=2&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download=",

            "http://b2.ge.tt/gett/8CDIuLc2/Sheepy+Skin.pmuskn.zip?index=24&user=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&referrer=user-ZFZnqJt9p3WLQnX48HsNjnteglAWu85w6hwH2-&download="

        };
        private string skinDirectory = "\\Program Files\\Pokemon Mystery Universe\\Client\\Client\\Skins";
        private string skinFilename;

        //Debug Mode Checker
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "PMUSDDebug")
            {
                textBox1.Visible = false;
                button2.Visible = true;
                isDebugEnabled = true;
                MessageBox.Show("MiningGardevoir welcomes you to Debug Mode!", "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
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
                if (isDebugEnabled == true)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        //Loads preview picture into pictureBox1
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){

            if (!CheckForInternetConnection())
            {
                MessageBox.Show("This application needs an internet connection. Check your internet connection. The application will now exit.", 
                    "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            
            //Wow shortened 100+ lines of code to 8! >.<
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try {
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\" + listBox1.SelectedIndex + ".png"));
            }
            catch(FileNotFoundException)
            {
                pictureBox1.Load(Path.Combine(Application.StartupPath, "Resources\\" + listBox1.SelectedIndex + ".jpg"));
            }

        }

        //Confirms skin selection, then begins download
        private void button1_Click(object sender, EventArgs e)
        {
            
            bool skinSelected = true;
            if (Directory.Exists(skinDirectory) == false)
            {
                MessageBox.Show("Select the correct folder of your Pokemon Mystery Universe skins. This is usually located in Local Disk, Program Files, Pokemon Mystery Universe, Client, Client, Skins.",
                    "Missing Directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    skinDirectory = folderBrowserDialog1.SelectedPath;
                    if (skinDirectory.Length - 7 <= 0)
                    {
                        MessageBox.Show("This directory is still not correct. Please reopen the application after you have located the Skins folder.",
                   "Missing Directory", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }

                    else if (!File.Exists(Path.Combine(skinDirectory.Remove(skinDirectory.Length - 7), "PMU.exe")))
                    {
                        MessageBox.Show("This directory is still not correct. Please reopen the application after you have located the Skins folder.",
                    "Missing Directory", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("You must enter a directory. Please reopen the application after you have located the Skins folder.",
                   "Missing Directory", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }

            button1.Visible = false;

            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select a skin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                skinSelected = false;
                button1.Visible = true;
            }

            if (skinSelected)
            {

                //Temporary folder used for downloads and to find folder names
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "temp\\extracted\\"));

                WebClient client = new WebClient();

                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);

                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

                Uri uri = new Uri(skinUrl[listBox1.SelectedIndex]);
                skinFilename = Path.GetFileName(uri.LocalPath);
                client.DownloadFileAsync(new Uri(skinUrl[listBox1.SelectedIndex]), Path.Combine(tempFolder, "tempskin.zip"));
            }
        }


        /// <summary>
        /// Finds a value for the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            progressBar1.Visible = true;
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        private string[] folderName;

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            bool skinReplaced = false;
            MessageBox.Show("Download completed. Skin will now be applied.",
                    "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ZipFile.ExtractToDirectory(Path.Combine(tempFolder, "tempskin.zip"), (Path.Combine(tempFolder, "extracted\\")));
            string[] folderName = Directory.GetDirectories(Path.Combine(tempFolder, "extracted\\"));

            try
            {
                ZipFile.ExtractToDirectory(Path.Combine(tempFolder, "tempskin.zip"), skinDirectory);
            }

            catch (System.IO.IOException)
            {
                
                if (MessageBox.Show("This skin is already installed! Please select a different one, or would you like to reinstall this one?",
                    "Skin already installed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (listBox1.GetSelected(7) == true)
                    {
                        if (Directory.Exists(Path.Combine(skinDirectory, "__MACOSX")))
                        {
                            Directory.Delete(Path.Combine(skinDirectory, "__MACOSX"), true);
                        }
                    }

                    

                    if (listBox1.GetSelected(7) == true)
                    {
                        if (Directory.Exists(Path.Combine(tempFolder, "__MACOSX")))
                        {
                            Directory.Delete(Path.Combine(tempFolder, "__MACOSX"), true);
                        }
                        Directory.Delete(Path.Combine(skinDirectory, folderName[0].Remove(0, Path.Combine(tempFolder, "extracted\\").Length)), true);
                    }

                    else
                    {
                        Directory.Delete(Path.Combine(skinDirectory, folderName[0].Remove(0, Path.Combine(tempFolder, "extracted\\").Length)), true);
                    }

                    ZipFile.ExtractToDirectory(Path.Combine(tempFolder, "tempskin.zip"), skinDirectory);
                    skinReplaced = true;

                }
            }
            Directory.Delete(tempFolder, true);

            

            XmlDocument settingsPMU = new XmlDocument();
            settingsPMU.Load(Path.Combine(skinDirectory.Remove(skinDirectory.Length - 6), "settings.xml"));

            XmlNodeList generalNodes = settingsPMU.SelectNodes("/Options/General");

            XmlNode selectedSkin = generalNodes[0].ChildNodes[15];
            if (!(selectedSkin == null))
            {

                //Used to check the skin name if debug is enabled.
                if (isDebugEnabled)
                {
                    MessageBox.Show(folderName[0]);
                }

                if (skinReplaced == false)
                {
                    MessageBox.Show("Skin has been applied! Once you open PMU, the skin will be installed!",
                            "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedSkin.InnerText = folderName[0].Remove(0, Path.Combine(tempFolder, "extracted\\").Length);
                }

                else
                {
                    MessageBox.Show("Skin has been reinstalled! Once you open PMU, the skin will be installed!",
                            "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedSkin.InnerText = folderName[0].Remove(0, Path.Combine(tempFolder, "extracted\\").Length);
                }

                if (listBox1.GetSelected(7) == true)
                {
                    if (Directory.Exists(Path.Combine(skinDirectory, "__MACOSX")))
                    {
                        Directory.Delete(Path.Combine(skinDirectory, "__MACOSX"), true);
                    }
                    selectedSkin.InnerText = folderName[1].Remove(0, Path.Combine(tempFolder, "extracted\\").Length);
                }

            }
            settingsPMU.Save(Path.Combine(skinDirectory.Remove(skinDirectory.Length - 6), "settings.xml"));

            progressBar1.Visible = false;
            button1.Visible = true;

        }

        //Runs debug code (When needed)
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //Run PMU button
        private void button3_Click(object sender, EventArgs e)
        {
            
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Path.Combine(skinDirectory.Remove(skinDirectory.Length - 6), "PMU.exe");
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;

            
            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();
            }
        }
    }
}
