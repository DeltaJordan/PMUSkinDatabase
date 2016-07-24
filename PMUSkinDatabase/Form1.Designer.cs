namespace PMUSkinDatabase
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Ampharos Skin by ShadowUmbreon",
            "Azurill Bubble Skin by pipplyRocks",
            "Buizel Skin by Kirk",
            "Cherubi & Cherrim Skin by pipplyRocks",
            "Chimecho Skin by Flareon",
            "Flareon Skin by Kirk",
            "Aerial Avians by Agunimon",
            "Legendary Skin by Agunimon",
            "Raichu Skin by pipplyRocks",
            "Umbreon Skin by princer13",
            "Vulpix skin by Kirk",
            "Sekia by Flare",
            "Plusle and Minun by Flare",
            "Bone Brothers Skin by Erlade",
            "Chandelure Family by SieylahXmaple",
            "Chinchou by calmchaos",
            "Eeveelutions by SieylahXmaple",
            "Fennekin by Zefa",
            "Gardevoir Skin by SieylahXmaple",
            "Ho-Oh Skin by SieylahXmaple",
            "Jarachi Skin by Zefa",
            "Pikachu Family Skin by Whitewingz",
            "Salamance Skin by ISoulMatter",
            "Snivy Theme by Shiju",
            "Snivy Family Skin by Whitewingz",
            "Space and Time by Drakon",
            "Tyranitar Family Skin by SieylahXmaple",
            "Typhlosion & Zangoose by charika",
            "Tyranitar Skin by ISoulMatter",
            "Haktsune Miku by RedTheMudkip",
            "Plated Beasts by Redstars78",
            "Yveltal Skin by Redstars78",
            "Xerneas Skin by Redstars78",
            "Whimsicott Skin by Tyson123",
            "Torterra Skin by hayarotle",
            "Shaymin Skin by Redstars78",
            "Seviper Skin by princer13",
            "Reshiram Skin by PachirisuBESTPOKE",
            "PMD Skin by Whitewingz",
            "Pikachu Skin by shinypikachu",
            "Pachirisu Skin by Pipply",
            "Luxray Skin by Agunimon",
            "Lugia Skin by calmchaos",
            "Lucario Skin by Tyson123",
            "Lady Raincorn Skin by Rawly08",
            "Jarachi Skin by calmchaos",
            "Glorious Grass Skin by Agunimon",
            "Furor of the Fishes Skin by Agunimon",
            "Empoleon Skin by Tyson123",
            "Emolga Skin by calmchaos",
            "Eeveeloutions Skin by Redstars78",
            "Drahsid\'s Theme by Drahsid",
            "Charmander Theme by Drahsid",
            "Bulbasaur Skin by Tyson123",
            "Sheepy Skin by Pipply",
            "Serperior & Samurott Skin by Asch"});
            this.listBox1.Location = new System.Drawing.Point(112, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(211, 264);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(382, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 264);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Kozuka Mincho Pro H", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(267, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(418, 84);
            this.button1.TabIndex = 3;
            this.button1.Text = "Apply Skin!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(83, 363);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(768, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Tag = "";
            this.progressBar1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 480);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Debug";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 480);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Enter Debug Code";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Kozuka Mincho Pro H", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(731, 453);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 51);
            this.button3.TabIndex = 7;
            this.button3.Text = "Run PMU";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(947, 516);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PMU Skin Database";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
    }
}

