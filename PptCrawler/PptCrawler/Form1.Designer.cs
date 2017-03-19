namespace PptCrawler
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
            this.label1 = new System.Windows.Forms.Label();
            this.page = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this._continue = new System.Windows.Forms.Button();
            this.end = new System.Windows.Forms.Button();
            this.content = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(149, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "已完成頁數 : ";
            // 
            // page
            // 
            this.page.AutoSize = true;
            this.page.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.page.Location = new System.Drawing.Point(279, 35);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(16, 16);
            this.page.TabIndex = 1;
            this.page.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(149, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "已下載圖片數 : ";
            // 
            // image
            // 
            this.image.AutoSize = true;
            this.image.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.image.Location = new System.Drawing.Point(279, 74);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(16, 16);
            this.image.TabIndex = 3;
            this.image.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(149, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "速度 : ";
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.speed.Location = new System.Drawing.Point(279, 115);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(16, 16);
            this.speed.TabIndex = 5;
            this.speed.Text = "0";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(16, 187);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 35);
            this.start.TabIndex = 6;
            this.start.Text = "開始";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(126, 187);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 35);
            this.stop.TabIndex = 7;
            this.stop.Text = "暫停";
            this.stop.UseVisualStyleBackColor = true;
            // 
            // _continue
            // 
            this._continue.Location = new System.Drawing.Point(242, 187);
            this._continue.Name = "_continue";
            this._continue.Size = new System.Drawing.Size(75, 35);
            this._continue.TabIndex = 8;
            this._continue.Text = "繼續";
            this._continue.UseVisualStyleBackColor = true;
            // 
            // end
            // 
            this.end.Location = new System.Drawing.Point(347, 187);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(75, 35);
            this.end.TabIndex = 9;
            this.end.Text = "結束";
            this.end.UseVisualStyleBackColor = true;
            this.end.Click += new System.EventHandler(this.end_Click);
            // 
            // content
            // 
            this.content.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.content.HoverSelection = true;
            this.content.Location = new System.Drawing.Point(16, 228);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(529, 97);
            this.content.TabIndex = 10;
            this.content.UseCompatibleStateImageBehavior = false;
            this.content.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 344);
            this.Controls.Add(this.content);
            this.Controls.Add(this.end);
            this.Controls.Add(this._continue);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.image);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.page);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label page;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label image;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label speed;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button _continue;
        private System.Windows.Forms.Button end;
        private System.Windows.Forms.ListView content;
    }
}

