﻿namespace Fase_1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Follow = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.FOLLOWS = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxScanner = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Follow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FOLLOWS)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "ARCHIVO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Follow
            // 
            this.Follow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Follow.Location = new System.Drawing.Point(130, 129);
            this.Follow.Name = "Follow";
            this.Follow.RowHeadersWidth = 51;
            this.Follow.RowTemplate.Height = 24;
            this.Follow.Size = new System.Drawing.Size(277, 425);
            this.Follow.TabIndex = 2;
            this.Follow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Follow_CellContentClick);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "TABLA DE TRANSICIONES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(460, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 13;
            this.button2.Text = "FIRST";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(460, 314);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 50);
            this.button3.TabIndex = 14;
            this.button3.Text = "LAST";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FOLLOWS
            // 
            this.FOLLOWS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FOLLOWS.Location = new System.Drawing.Point(597, 129);
            this.FOLLOWS.Name = "FOLLOWS";
            this.FOLLOWS.RowHeadersWidth = 51;
            this.FOLLOWS.RowTemplate.Height = 24;
            this.FOLLOWS.Size = new System.Drawing.Size(275, 425);
            this.FOLLOWS.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(642, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 39);
            this.label2.TabIndex = 16;
            this.label2.Text = "FOLLOW";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(460, 370);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 50);
            this.button4.TabIndex = 17;
            this.button4.Text = "SETS";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(994, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 39);
            this.label3.TabIndex = 18;
            this.label3.Text = "SCANNER";
            // 
            // tbxScanner
            // 
            this.tbxScanner.Location = new System.Drawing.Point(953, 129);
            this.tbxScanner.Multiline = true;
            this.tbxScanner.Name = "tbxScanner";
            this.tbxScanner.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxScanner.Size = new System.Drawing.Size(275, 425);
            this.tbxScanner.TabIndex = 19;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1272, 262);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 50);
            this.button5.TabIndex = 20;
            this.button5.Text = "GUARDAR";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1272, 345);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 50);
            this.button6.TabIndex = 21;
            this.button6.Text = "COMPILAR";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 603);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tbxScanner);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FOLLOWS);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Follow);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Follow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FOLLOWS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView Follow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView FOLLOWS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxScanner;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

