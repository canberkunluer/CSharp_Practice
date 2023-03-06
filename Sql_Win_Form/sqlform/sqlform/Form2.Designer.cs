namespace sqlform
{
    partial class Form2
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
            this.btnScalar = new System.Windows.Forms.Button();
            this.btnReader = new System.Windows.Forms.Button();
            this.btnProcedure = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScalar
            // 
            this.btnScalar.Location = new System.Drawing.Point(12, 329);
            this.btnScalar.Name = "btnScalar";
            this.btnScalar.Size = new System.Drawing.Size(165, 29);
            this.btnScalar.TabIndex = 0;
            this.btnScalar.Tag = "";
            this.btnScalar.Text = "Execute Scalar";
            this.btnScalar.UseVisualStyleBackColor = true;
            // 
            // btnReader
            // 
            this.btnReader.Location = new System.Drawing.Point(183, 329);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(166, 29);
            this.btnReader.TabIndex = 1;
            this.btnReader.Text = "Execute Reader";
            this.btnReader.UseVisualStyleBackColor = true;
            // 
            // btnProcedure
            // 
            this.btnProcedure.Location = new System.Drawing.Point(355, 329);
            this.btnProcedure.Name = "btnProcedure";
            this.btnProcedure.Size = new System.Drawing.Size(166, 29);
            this.btnProcedure.TabIndex = 2;
            this.btnProcedure.Text = "Execute Procedure";
            this.btnProcedure.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(14, 51);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(774, 268);
            this.txtResult.TabIndex = 3;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(136, 17);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(199, 27);
            this.txtCategoryName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Category Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Year:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(387, 17);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(187, 27);
            this.txtYear.TabIndex = 7;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(594, 16);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(94, 29);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Get Report";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(694, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 29);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 370);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnProcedure);
            this.Controls.Add(this.btnReader);
            this.Controls.Add(this.btnScalar);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnScalar;
        private Button btnReader;
        private Button btnProcedure;
        private TextBox txtResult;
        private TextBox txtCategoryName;
        private Label label1;
        private Label label2;
        private TextBox txtYear;
        private Button btnReport;
        private Button btnClear;
    }
}