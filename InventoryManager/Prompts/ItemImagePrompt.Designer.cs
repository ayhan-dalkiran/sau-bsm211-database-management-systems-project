namespace InventoryManager;

partial class ItemImagePrompt {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		this.entityIdLabel = new Label();
		this.entityIdBox = new TextBox();
		this.entityNameLabel = new Label();
		this.entityNameBox = new TextBox();
		this.telephoneNumberLabel = new Label();
		this.telephoneNumberBox = new MaskedTextBox();
		this.addressLabel = new Label();
		this.tableLayoutPanel1 = new TableLayoutPanel();
		this.pictureBox1 = new PictureBox();
		this.button1 = new Button();
		this.cancelButton = new Button();
		this.saveButton = new Button();
		this.tableLayoutPanel2 = new TableLayoutPanel();
		this.tableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.tableLayoutPanel2.SuspendLayout();
		this.SuspendLayout();
		// 
		// entityIdLabel
		// 
		this.entityIdLabel.AutoSize = true;
		this.entityIdLabel.Dock = DockStyle.Fill;
		this.entityIdLabel.Location = new Point(3, 0);
		this.entityIdLabel.Name = "entityIdLabel";
		this.entityIdLabel.Size = new Size(74, 29);
		this.entityIdLabel.TabIndex = 2;
		this.entityIdLabel.Text = "Fotoğraf No:";
		this.entityIdLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// entityIdBox
		// 
		this.entityIdBox.Dock = DockStyle.Fill;
		this.entityIdBox.Enabled = false;
		this.entityIdBox.Location = new Point(83, 3);
		this.entityIdBox.Name = "entityIdBox";
		this.entityIdBox.ReadOnly = true;
		this.entityIdBox.Size = new Size(714, 23);
		this.entityIdBox.TabIndex = 0;
		this.entityIdBox.Text = "0";
		// 
		// entityNameLabel
		// 
		this.entityNameLabel.AutoSize = true;
		this.entityNameLabel.Dock = DockStyle.Fill;
		this.entityNameLabel.Location = new Point(3, 29);
		this.entityNameLabel.Name = "entityNameLabel";
		this.entityNameLabel.Size = new Size(74, 29);
		this.entityNameLabel.TabIndex = 4;
		this.entityNameLabel.Text = "Kalem No:";
		this.entityNameLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// entityNameBox
		// 
		this.entityNameBox.Dock = DockStyle.Fill;
		this.entityNameBox.Location = new Point(83, 32);
		this.entityNameBox.MaxLength = 100;
		this.entityNameBox.Name = "entityNameBox";
		this.entityNameBox.Size = new Size(714, 23);
		this.entityNameBox.TabIndex = 1;
		// 
		// telephoneNumberLabel
		// 
		this.telephoneNumberLabel.AutoSize = true;
		this.telephoneNumberLabel.Dock = DockStyle.Fill;
		this.telephoneNumberLabel.Location = new Point(3, 58);
		this.telephoneNumberLabel.Name = "telephoneNumberLabel";
		this.telephoneNumberLabel.Size = new Size(74, 29);
		this.telephoneNumberLabel.TabIndex = 6;
		this.telephoneNumberLabel.Text = "Sıra:";
		this.telephoneNumberLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// telephoneNumberBox
		// 
		this.telephoneNumberBox.Dock = DockStyle.Fill;
		this.telephoneNumberBox.Location = new Point(83, 61);
		this.telephoneNumberBox.Mask = "(000) 000 0000";
		this.telephoneNumberBox.Name = "telephoneNumberBox";
		this.telephoneNumberBox.ResetOnSpace = false;
		this.telephoneNumberBox.Size = new Size(714, 23);
		this.telephoneNumberBox.TabIndex = 2;
		this.telephoneNumberBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
		// 
		// addressLabel
		// 
		this.addressLabel.AutoSize = true;
		this.addressLabel.Dock = DockStyle.Fill;
		this.addressLabel.Location = new Point(3, 87);
		this.addressLabel.Name = "addressLabel";
		this.addressLabel.Size = new Size(74, 297);
		this.addressLabel.TabIndex = 8;
		this.addressLabel.Text = "Fotoğraf:";
		this.addressLabel.TextAlign = ContentAlignment.TopRight;
		// 
		// tableLayoutPanel1
		// 
		this.tableLayoutPanel1.ColumnCount = 2;
		this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel1.Controls.Add(this.entityIdLabel, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.entityNameLabel, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.telephoneNumberBox, 1, 2);
		this.tableLayoutPanel1.Controls.Add(this.addressLabel, 0, 3);
		this.tableLayoutPanel1.Controls.Add(this.entityIdBox, 1, 0);
		this.tableLayoutPanel1.Controls.Add(this.entityNameBox, 1, 1);
		this.tableLayoutPanel1.Controls.Add(this.telephoneNumberLabel, 0, 2);
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
		this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 3);
		this.tableLayoutPanel1.Controls.Add(this.button1, 1, 4);
		this.tableLayoutPanel1.Dock = DockStyle.Fill;
		this.tableLayoutPanel1.Location = new Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 6;
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		this.tableLayoutPanel1.Size = new Size(800, 450);
		this.tableLayoutPanel1.TabIndex = 10;
		// 
		// pictureBox1
		// 
		this.pictureBox1.Dock = DockStyle.Fill;
		this.pictureBox1.Location = new Point(83, 90);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new Size(714, 291);
		this.pictureBox1.TabIndex = 11;
		this.pictureBox1.TabStop = false;
		// 
		// button1
		// 
		this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		this.button1.Location = new Point(722, 387);
		this.button1.Name = "button1";
		this.button1.Size = new Size(75, 23);
		this.button1.TabIndex = 12;
		this.button1.Text = "Seç..";
		this.button1.UseVisualStyleBackColor = true;
		// 
		// cancelButton
		// 
		this.cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		this.cancelButton.AutoSize = true;
		this.cancelButton.DialogResult = DialogResult.Cancel;
		this.cancelButton.Location = new Point(635, 3);
		this.cancelButton.Name = "cancelButton";
		this.cancelButton.Size = new Size(75, 25);
		this.cancelButton.TabIndex = 7;
		this.cancelButton.Text = "İptal..";
		this.cancelButton.UseVisualStyleBackColor = true;
		// 
		// saveButton
		// 
		this.saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		this.saveButton.AutoSize = true;
		this.saveButton.DialogResult = DialogResult.OK;
		this.saveButton.Location = new Point(716, 3);
		this.saveButton.Name = "saveButton";
		this.saveButton.Size = new Size(75, 25);
		this.saveButton.TabIndex = 8;
		this.saveButton.Text = "Kaydet..";
		this.saveButton.UseVisualStyleBackColor = true;
		// 
		// tableLayoutPanel2
		// 
		this.tableLayoutPanel2.AutoSize = true;
		this.tableLayoutPanel2.ColumnCount = 2;
		this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
		this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel2.Controls.Add(this.saveButton, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.cancelButton, 0, 0);
		this.tableLayoutPanel2.Dock = DockStyle.Fill;
		this.tableLayoutPanel2.Location = new Point(3, 416);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel2.Size = new Size(794, 31);
		this.tableLayoutPanel2.TabIndex = 10;
		// 
		// ItemImagePrompt
		// 
		this.AcceptButton = this.saveButton;
		this.AutoScaleDimensions = new SizeF(7F, 15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.CancelButton = this.cancelButton;
		this.ClientSize = new Size(800, 450);
		this.Controls.Add(this.tableLayoutPanel1);
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "ItemImagePrompt";
		this.ShowIcon = false;
		this.StartPosition = FormStartPosition.CenterParent;
		this.Text = "Varlık Düzenleyicisi";
		this.TopMost = true;
		this.FormClosing += this.EntityForm_FormClosing;
		this.Shown += this.EntityForm_Shown;
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.ResumeLayout(false);
	}

	#endregion
	private Label entityIdLabel;
	private TextBox entityIdBox;
	private Label entityNameLabel;
	private TextBox entityNameBox;
	private Label telephoneNumberLabel;
	private MaskedTextBox telephoneNumberBox;
	private Label addressLabel;
	private TableLayoutPanel tableLayoutPanel1;
	private PictureBox pictureBox1;
	private Button button1;
	private TableLayoutPanel tableLayoutPanel2;
	private Button saveButton;
	private Button cancelButton;
}