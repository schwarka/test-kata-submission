namespace VendingMachineApp
{
    partial class VendingMachineController
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
            this.vendingMachineState_Textbox = new System.Windows.Forms.TextBox();
            this.insertQuarter_button = new System.Windows.Forms.Button();
            this.insertDime_button = new System.Windows.Forms.Button();
            this.insertNickel_button = new System.Windows.Forms.Button();
            this.insertPenny_button = new System.Windows.Forms.Button();
            this.total_TextBox = new System.Windows.Forms.TextBox();
            this.returnedTotal_TextBox = new System.Windows.Forms.TextBox();
            this.returnedTotal_TextBox_Label = new System.Windows.Forms.Label();
            this.total_TextBox_Label = new System.Windows.Forms.Label();
            this.chipsStock_Label = new System.Windows.Forms.Label();
            this.colaStock_Label = new System.Windows.Forms.Label();
            this.candyStock_Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buyCandy_Button = new System.Windows.Forms.Button();
            this.buyCola_Button = new System.Windows.Forms.Button();
            this.buyChips_Button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chipsPrice_Label = new System.Windows.Forms.Label();
            this.colaPrice_Label = new System.Windows.Forms.Label();
            this.twixPrice_Label = new System.Windows.Forms.Label();
            this.chips_PictureBox = new System.Windows.Forms.PictureBox();
            this.cola_PictureBox = new System.Windows.Forms.PictureBox();
            this.candy_PictureBox = new System.Windows.Forms.PictureBox();
            this.returnCoins_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chips_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cola_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candy_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // vendingMachineState_Textbox
            // 
            this.vendingMachineState_Textbox.Enabled = false;
            this.vendingMachineState_Textbox.Location = new System.Drawing.Point(206, 88);
            this.vendingMachineState_Textbox.Name = "vendingMachineState_Textbox";
            this.vendingMachineState_Textbox.Size = new System.Drawing.Size(146, 20);
            this.vendingMachineState_Textbox.TabIndex = 3;
            this.vendingMachineState_Textbox.Text = "PLEASE INSERT COIN";
            // 
            // insertQuarter_button
            // 
            this.insertQuarter_button.Location = new System.Drawing.Point(242, 114);
            this.insertQuarter_button.Name = "insertQuarter_button";
            this.insertQuarter_button.Size = new System.Drawing.Size(76, 23);
            this.insertQuarter_button.TabIndex = 4;
            this.insertQuarter_button.Text = "25¢";
            this.insertQuarter_button.UseVisualStyleBackColor = true;
            this.insertQuarter_button.Click += new System.EventHandler(this.insertQuarter_button_Click);
            // 
            // insertDime_button
            // 
            this.insertDime_button.Location = new System.Drawing.Point(242, 143);
            this.insertDime_button.Name = "insertDime_button";
            this.insertDime_button.Size = new System.Drawing.Size(76, 23);
            this.insertDime_button.TabIndex = 5;
            this.insertDime_button.Text = "10¢";
            this.insertDime_button.UseVisualStyleBackColor = true;
            this.insertDime_button.Click += new System.EventHandler(this.insertDime_button_Click);
            // 
            // insertNickel_button
            // 
            this.insertNickel_button.Location = new System.Drawing.Point(242, 172);
            this.insertNickel_button.Name = "insertNickel_button";
            this.insertNickel_button.Size = new System.Drawing.Size(76, 23);
            this.insertNickel_button.TabIndex = 6;
            this.insertNickel_button.Text = "5¢";
            this.insertNickel_button.UseVisualStyleBackColor = true;
            this.insertNickel_button.Click += new System.EventHandler(this.insertNickel_button_Click);
            // 
            // insertPenny_button
            // 
            this.insertPenny_button.Location = new System.Drawing.Point(242, 201);
            this.insertPenny_button.Name = "insertPenny_button";
            this.insertPenny_button.Size = new System.Drawing.Size(76, 23);
            this.insertPenny_button.TabIndex = 7;
            this.insertPenny_button.Text = "1¢";
            this.insertPenny_button.UseVisualStyleBackColor = true;
            this.insertPenny_button.Click += new System.EventHandler(this.insertPenny_button_Click);
            // 
            // total_TextBox
            // 
            this.total_TextBox.Enabled = false;
            this.total_TextBox.Location = new System.Drawing.Point(279, 233);
            this.total_TextBox.Name = "total_TextBox";
            this.total_TextBox.Size = new System.Drawing.Size(73, 20);
            this.total_TextBox.TabIndex = 9;
            // 
            // returnedTotal_TextBox
            // 
            this.returnedTotal_TextBox.Enabled = false;
            this.returnedTotal_TextBox.Location = new System.Drawing.Point(279, 256);
            this.returnedTotal_TextBox.Name = "returnedTotal_TextBox";
            this.returnedTotal_TextBox.Size = new System.Drawing.Size(73, 20);
            this.returnedTotal_TextBox.TabIndex = 10;
            // 
            // returnedTotal_TextBox_Label
            // 
            this.returnedTotal_TextBox_Label.AutoSize = true;
            this.returnedTotal_TextBox_Label.Location = new System.Drawing.Point(207, 262);
            this.returnedTotal_TextBox_Label.Name = "returnedTotal_TextBox_Label";
            this.returnedTotal_TextBox_Label.Size = new System.Drawing.Size(66, 13);
            this.returnedTotal_TextBox_Label.TabIndex = 11;
            this.returnedTotal_TextBox_Label.Text = "Coin Return:";
            // 
            // total_TextBox_Label
            // 
            this.total_TextBox_Label.AutoSize = true;
            this.total_TextBox_Label.Location = new System.Drawing.Point(239, 240);
            this.total_TextBox_Label.Name = "total_TextBox_Label";
            this.total_TextBox_Label.Size = new System.Drawing.Size(34, 13);
            this.total_TextBox_Label.TabIndex = 12;
            this.total_TextBox_Label.Text = "Total:";
            // 
            // chipsStock_Label
            // 
            this.chipsStock_Label.AutoSize = true;
            this.chipsStock_Label.Location = new System.Drawing.Point(6, 16);
            this.chipsStock_Label.Name = "chipsStock_Label";
            this.chipsStock_Label.Size = new System.Drawing.Size(47, 13);
            this.chipsStock_Label.TabIndex = 13;
            this.chipsStock_Label.Text = "Stock: 3";
            // 
            // colaStock_Label
            // 
            this.colaStock_Label.AutoSize = true;
            this.colaStock_Label.Location = new System.Drawing.Point(6, 160);
            this.colaStock_Label.Name = "colaStock_Label";
            this.colaStock_Label.Size = new System.Drawing.Size(47, 13);
            this.colaStock_Label.TabIndex = 14;
            this.colaStock_Label.Text = "Stock: 3";
            // 
            // candyStock_Label
            // 
            this.candyStock_Label.AutoSize = true;
            this.candyStock_Label.Location = new System.Drawing.Point(6, 251);
            this.candyStock_Label.Name = "candyStock_Label";
            this.candyStock_Label.Size = new System.Drawing.Size(47, 13);
            this.candyStock_Label.TabIndex = 15;
            this.candyStock_Label.Text = "Stock: 3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buyCandy_Button);
            this.groupBox1.Controls.Add(this.buyCola_Button);
            this.groupBox1.Controls.Add(this.buyChips_Button);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chips_PictureBox);
            this.groupBox1.Controls.Add(this.cola_PictureBox);
            this.groupBox1.Controls.Add(this.candy_PictureBox);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 340);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Products";
            // 
            // buyCandy_Button
            // 
            this.buyCandy_Button.Location = new System.Drawing.Point(6, 305);
            this.buyCandy_Button.Name = "buyCandy_Button";
            this.buyCandy_Button.Size = new System.Drawing.Size(75, 23);
            this.buyCandy_Button.TabIndex = 19;
            this.buyCandy_Button.Text = "Buy Candy";
            this.buyCandy_Button.UseVisualStyleBackColor = true;
            this.buyCandy_Button.Click += new System.EventHandler(this.buyCandy_Button_Click);
            // 
            // buyCola_Button
            // 
            this.buyCola_Button.Location = new System.Drawing.Point(6, 230);
            this.buyCola_Button.Name = "buyCola_Button";
            this.buyCola_Button.Size = new System.Drawing.Size(75, 23);
            this.buyCola_Button.TabIndex = 18;
            this.buyCola_Button.Text = "Buy Cola";
            this.buyCola_Button.UseVisualStyleBackColor = true;
            this.buyCola_Button.Click += new System.EventHandler(this.buyCola_Button_Click);
            // 
            // buyChips_Button
            // 
            this.buyChips_Button.Location = new System.Drawing.Point(6, 131);
            this.buyChips_Button.Name = "buyChips_Button";
            this.buyChips_Button.Size = new System.Drawing.Size(75, 23);
            this.buyChips_Button.TabIndex = 17;
            this.buyChips_Button.Text = "Buy Chips";
            this.buyChips_Button.UseVisualStyleBackColor = true;
            this.buyChips_Button.Click += new System.EventHandler(this.buyChips_Button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chipsPrice_Label);
            this.groupBox2.Controls.Add(this.colaPrice_Label);
            this.groupBox2.Controls.Add(this.twixPrice_Label);
            this.groupBox2.Controls.Add(this.chipsStock_Label);
            this.groupBox2.Controls.Add(this.colaStock_Label);
            this.groupBox2.Controls.Add(this.candyStock_Label);
            this.groupBox2.Location = new System.Drawing.Point(112, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(82, 318);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // chipsPrice_Label
            // 
            this.chipsPrice_Label.AutoSize = true;
            this.chipsPrice_Label.Location = new System.Drawing.Point(6, 29);
            this.chipsPrice_Label.Name = "chipsPrice_Label";
            this.chipsPrice_Label.Size = new System.Drawing.Size(67, 13);
            this.chipsPrice_Label.TabIndex = 16;
            this.chipsPrice_Label.Text = "Price : $0.50";
            // 
            // colaPrice_Label
            // 
            this.colaPrice_Label.AutoSize = true;
            this.colaPrice_Label.Location = new System.Drawing.Point(6, 173);
            this.colaPrice_Label.Name = "colaPrice_Label";
            this.colaPrice_Label.Size = new System.Drawing.Size(67, 13);
            this.colaPrice_Label.TabIndex = 17;
            this.colaPrice_Label.Text = "Price : $1.00";
            // 
            // twixPrice_Label
            // 
            this.twixPrice_Label.AutoSize = true;
            this.twixPrice_Label.Location = new System.Drawing.Point(6, 264);
            this.twixPrice_Label.Name = "twixPrice_Label";
            this.twixPrice_Label.Size = new System.Drawing.Size(67, 13);
            this.twixPrice_Label.TabIndex = 18;
            this.twixPrice_Label.Text = "Price : $0.65";
            // 
            // chips_PictureBox
            // 
            this.chips_PictureBox.Image = global::VendingMachineApp.Properties.Resources.lays_classic;
            this.chips_PictureBox.Location = new System.Drawing.Point(6, 19);
            this.chips_PictureBox.Name = "chips_PictureBox";
            this.chips_PictureBox.Size = new System.Drawing.Size(100, 106);
            this.chips_PictureBox.TabIndex = 0;
            this.chips_PictureBox.TabStop = false;
            // 
            // cola_PictureBox
            // 
            this.cola_PictureBox.Image = global::VendingMachineApp.Properties.Resources.lg_cocacola_can_bfff2166;
            this.cola_PictureBox.Location = new System.Drawing.Point(6, 172);
            this.cola_PictureBox.Name = "cola_PictureBox";
            this.cola_PictureBox.Size = new System.Drawing.Size(100, 52);
            this.cola_PictureBox.TabIndex = 1;
            this.cola_PictureBox.TabStop = false;
            // 
            // candy_PictureBox
            // 
            this.candy_PictureBox.Image = global::VendingMachineApp.Properties.Resources.twix_2;
            this.candy_PictureBox.Location = new System.Drawing.Point(6, 262);
            this.candy_PictureBox.Name = "candy_PictureBox";
            this.candy_PictureBox.Size = new System.Drawing.Size(87, 37);
            this.candy_PictureBox.TabIndex = 2;
            this.candy_PictureBox.TabStop = false;
            // 
            // returnCoins_Button
            // 
            this.returnCoins_Button.Location = new System.Drawing.Point(233, 282);
            this.returnCoins_Button.Name = "returnCoins_Button";
            this.returnCoins_Button.Size = new System.Drawing.Size(101, 23);
            this.returnCoins_Button.TabIndex = 17;
            this.returnCoins_Button.Text = "Return Coins";
            this.returnCoins_Button.UseVisualStyleBackColor = true;
            this.returnCoins_Button.Click += new System.EventHandler(this.returnCoins_Button_Click);
            // 
            // VendingMachineView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 342);
            this.Controls.Add(this.returnCoins_Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.total_TextBox_Label);
            this.Controls.Add(this.returnedTotal_TextBox_Label);
            this.Controls.Add(this.returnedTotal_TextBox);
            this.Controls.Add(this.total_TextBox);
            this.Controls.Add(this.insertPenny_button);
            this.Controls.Add(this.insertNickel_button);
            this.Controls.Add(this.insertDime_button);
            this.Controls.Add(this.insertQuarter_button);
            this.Controls.Add(this.vendingMachineState_Textbox);
            this.Name = "VendingMachineView";
            this.Text = "Vending Machine App";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chips_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cola_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candy_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox chips_PictureBox;
        private System.Windows.Forms.PictureBox cola_PictureBox;
        private System.Windows.Forms.PictureBox candy_PictureBox;
        public System.Windows.Forms.TextBox vendingMachineState_Textbox;
        public System.Windows.Forms.Button insertQuarter_button;
        public System.Windows.Forms.Button insertDime_button;
        public System.Windows.Forms.Button insertNickel_button;
        public System.Windows.Forms.Button insertPenny_button;
        public System.Windows.Forms.TextBox total_TextBox;
        public System.Windows.Forms.TextBox returnedTotal_TextBox;
        private System.Windows.Forms.Label returnedTotal_TextBox_Label;
        private System.Windows.Forms.Label total_TextBox_Label;
        private System.Windows.Forms.Label chipsStock_Label;
        private System.Windows.Forms.Label colaStock_Label;
        private System.Windows.Forms.Label candyStock_Label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label chipsPrice_Label;
        private System.Windows.Forms.Label colaPrice_Label;
        private System.Windows.Forms.Label twixPrice_Label;
        public System.Windows.Forms.Button buyCandy_Button;
        public System.Windows.Forms.Button buyCola_Button;
        public System.Windows.Forms.Button buyChips_Button;
        public System.Windows.Forms.Button returnCoins_Button;
    }
}

