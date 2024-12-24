namespace InventoryManager;

partial class ItemPrompt {
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
		this.cancelButton = new Button();
		this.saveButton = new Button();
		this.entityIdLabel = new Label();
		this.entityIdBox = new TextBox();
		this.entityNameLabel = new Label();
		this.entityNameBox = new TextBox();
		this.telephoneNumberLabel = new Label();
		this.telephoneNumberBox = new MaskedTextBox();
		this.addressBox = new TextBox();
		this.addressLabel = new Label();
		this.tableLayoutPanel1 = new TableLayoutPanel();
		this.nationalIdBox = new MaskedTextBox();
		this.mersisIdBox = new MaskedTextBox();
		this.nationalIdLabel = new Label();
		this.mersisIdLabel = new Label();
		this.entityTypeLabel = new Label();
		this.tableLayoutPanel2 = new TableLayoutPanel();
		this.entityTypeBox = new ComboBox();
		this.tableLayoutPanel1.SuspendLayout();
		this.tableLayoutPanel2.SuspendLayout();
		this.SuspendLayout();
		// 
		// cancelButton
		// 
		this.cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		this.cancelButton.DialogResult = DialogResult.Cancel;
		this.cancelButton.Location = new Point(635, 215);
		this.cancelButton.Name = "cancelButton";
		this.cancelButton.Size = new Size(75, 23);
		this.cancelButton.TabIndex = 7;
		this.cancelButton.Text = "İptal..";
		this.cancelButton.UseVisualStyleBackColor = true;
		// 
		// saveButton
		// 
		this.saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		this.saveButton.DialogResult = DialogResult.OK;
		this.saveButton.Location = new Point(716, 215);
		this.saveButton.Name = "saveButton";
		this.saveButton.Size = new Size(75, 23);
		this.saveButton.TabIndex = 8;
		this.saveButton.Text = "Kaydet..";
		this.saveButton.UseVisualStyleBackColor = true;
		// 
		// entityIdLabel
		// 
		this.entityIdLabel.AutoSize = true;
		this.entityIdLabel.Dock = DockStyle.Fill;
		this.entityIdLabel.Location = new Point(3, 0);
		this.entityIdLabel.Name = "entityIdLabel";
		this.entityIdLabel.Size = new Size(85, 29);
		this.entityIdLabel.TabIndex = 2;
		this.entityIdLabel.Text = "Kalem No:";
		this.entityIdLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// entityIdBox
		// 
		this.entityIdBox.Dock = DockStyle.Fill;
		this.entityIdBox.Enabled = false;
		this.entityIdBox.Location = new Point(94, 3);
		this.entityIdBox.Name = "entityIdBox";
		this.entityIdBox.ReadOnly = true;
		this.entityIdBox.Size = new Size(703, 23);
		this.entityIdBox.TabIndex = 0;
		this.entityIdBox.Text = "0";
		// 
		// entityNameLabel
		// 
		this.entityNameLabel.AutoSize = true;
		this.entityNameLabel.Dock = DockStyle.Fill;
		this.entityNameLabel.Location = new Point(3, 29);
		this.entityNameLabel.Name = "entityNameLabel";
		this.entityNameLabel.Size = new Size(85, 29);
		this.entityNameLabel.TabIndex = 4;
		this.entityNameLabel.Text = "Kalem Adı:";
		this.entityNameLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// entityNameBox
		// 
		this.entityNameBox.Dock = DockStyle.Fill;
		this.entityNameBox.Location = new Point(94, 32);
		this.entityNameBox.MaxLength = 100;
		this.entityNameBox.Name = "entityNameBox";
		this.entityNameBox.Size = new Size(703, 23);
		this.entityNameBox.TabIndex = 1;
		// 
		// telephoneNumberLabel
		// 
		this.telephoneNumberLabel.AutoSize = true;
		this.telephoneNumberLabel.Dock = DockStyle.Fill;
		this.telephoneNumberLabel.Location = new Point(3, 58);
		this.telephoneNumberLabel.Name = "telephoneNumberLabel";
		this.telephoneNumberLabel.Size = new Size(85, 29);
		this.telephoneNumberLabel.TabIndex = 6;
		this.telephoneNumberLabel.Text = "Üretici Firma:";
		this.telephoneNumberLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// telephoneNumberBox
		// 
		this.telephoneNumberBox.Dock = DockStyle.Fill;
		this.telephoneNumberBox.Location = new Point(94, 61);
		this.telephoneNumberBox.Mask = "(000) 000 0000";
		this.telephoneNumberBox.Name = "telephoneNumberBox";
		this.telephoneNumberBox.ResetOnSpace = false;
		this.telephoneNumberBox.Size = new Size(703, 23);
		this.telephoneNumberBox.TabIndex = 2;
		this.telephoneNumberBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
		// 
		// addressBox
		// 
		this.addressBox.Dock = DockStyle.Fill;
		this.addressBox.Location = new Point(94, 90);
		this.addressBox.MaxLength = 200;
		this.addressBox.Name = "addressBox";
		this.addressBox.Size = new Size(703, 23);
		this.addressBox.TabIndex = 3;
		// 
		// addressLabel
		// 
		this.addressLabel.AutoSize = true;
		this.addressLabel.Dock = DockStyle.Fill;
		this.addressLabel.Location = new Point(3, 87);
		this.addressLabel.Name = "addressLabel";
		this.addressLabel.Size = new Size(85, 29);
		this.addressLabel.TabIndex = 8;
		this.addressLabel.Text = "Adres:";
		this.addressLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// tableLayoutPanel1
		// 
		this.tableLayoutPanel1.ColumnCount = 2;
		this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel1.Controls.Add(this.nationalIdBox, 1, 6);
		this.tableLayoutPanel1.Controls.Add(this.mersisIdBox, 1, 5);
		this.tableLayoutPanel1.Controls.Add(this.nationalIdLabel, 0, 6);
		this.tableLayoutPanel1.Controls.Add(this.mersisIdLabel, 0, 5);
		this.tableLayoutPanel1.Controls.Add(this.entityTypeLabel, 0, 4);
		this.tableLayoutPanel1.Controls.Add(this.entityIdLabel, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.addressBox, 1, 3);
		this.tableLayoutPanel1.Controls.Add(this.entityNameLabel, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.telephoneNumberBox, 1, 2);
		this.tableLayoutPanel1.Controls.Add(this.addressLabel, 0, 3);
		this.tableLayoutPanel1.Controls.Add(this.entityIdBox, 1, 0);
		this.tableLayoutPanel1.Controls.Add(this.entityNameBox, 1, 1);
		this.tableLayoutPanel1.Controls.Add(this.telephoneNumberLabel, 0, 2);
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 7);
		this.tableLayoutPanel1.Controls.Add(this.entityTypeBox, 1, 4);
		this.tableLayoutPanel1.Dock = DockStyle.Fill;
		this.tableLayoutPanel1.Location = new Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 8;
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		this.tableLayoutPanel1.Size = new Size(800, 450);
		this.tableLayoutPanel1.TabIndex = 10;
		// 
		// nationalIdBox
		// 
		this.nationalIdBox.Dock = DockStyle.Fill;
		this.nationalIdBox.Enabled = false;
		this.nationalIdBox.Location = new Point(94, 177);
		this.nationalIdBox.Mask = "00000000000";
		this.nationalIdBox.Name = "nationalIdBox";
		this.nationalIdBox.ResetOnSpace = false;
		this.nationalIdBox.Size = new Size(703, 23);
		this.nationalIdBox.TabIndex = 6;
		this.nationalIdBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
		// 
		// mersisIdBox
		// 
		this.mersisIdBox.Dock = DockStyle.Fill;
		this.mersisIdBox.Enabled = false;
		this.mersisIdBox.Location = new Point(94, 148);
		this.mersisIdBox.Mask = "0000000000000000";
		this.mersisIdBox.Name = "mersisIdBox";
		this.mersisIdBox.ResetOnSpace = false;
		this.mersisIdBox.Size = new Size(703, 23);
		this.mersisIdBox.TabIndex = 5;
		this.mersisIdBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
		// 
		// nationalIdLabel
		// 
		this.nationalIdLabel.AutoSize = true;
		this.nationalIdLabel.Dock = DockStyle.Fill;
		this.nationalIdLabel.Location = new Point(3, 174);
		this.nationalIdLabel.Name = "nationalIdLabel";
		this.nationalIdLabel.Size = new Size(85, 29);
		this.nationalIdLabel.TabIndex = 16;
		this.nationalIdLabel.Text = "T.C. Kimlik No:";
		this.nationalIdLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// mersisIdLabel
		// 
		this.mersisIdLabel.AutoSize = true;
		this.mersisIdLabel.Dock = DockStyle.Fill;
		this.mersisIdLabel.Location = new Point(3, 145);
		this.mersisIdLabel.Name = "mersisIdLabel";
		this.mersisIdLabel.Size = new Size(85, 29);
		this.mersisIdLabel.TabIndex = 13;
		this.mersisIdLabel.Text = "Mersis No:";
		this.mersisIdLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// entityTypeLabel
		// 
		this.entityTypeLabel.AutoSize = true;
		this.entityTypeLabel.Dock = DockStyle.Fill;
		this.entityTypeLabel.Location = new Point(3, 116);
		this.entityTypeLabel.Name = "entityTypeLabel";
		this.entityTypeLabel.Size = new Size(85, 29);
		this.entityTypeLabel.TabIndex = 11;
		this.entityTypeLabel.Text = "Varlık Tipi:";
		this.entityTypeLabel.TextAlign = ContentAlignment.MiddleRight;
		// 
		// tableLayoutPanel2
		// 
		this.tableLayoutPanel2.ColumnCount = 2;
		this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
		this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel2.Controls.Add(this.saveButton, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.cancelButton, 0, 0);
		this.tableLayoutPanel2.Location = new Point(3, 206);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel2.Size = new Size(794, 241);
		this.tableLayoutPanel2.TabIndex = 10;
		// 
		// entityTypeBox
		// 
		this.entityTypeBox.Dock = DockStyle.Fill;
		this.entityTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
		this.entityTypeBox.FormattingEnabled = true;
		this.entityTypeBox.Items.AddRange(new object[] { "Firma", "Kişi" });
		this.entityTypeBox.Location = new Point(94, 119);
		this.entityTypeBox.Name = "entityTypeBox";
		this.entityTypeBox.Size = new Size(703, 23);
		this.entityTypeBox.TabIndex = 4;
		this.entityTypeBox.SelectedIndexChanged += this.entityTypeBox_SelectedIndexChanged;
		// 
		// ItemPrompt
		// 
		this.AcceptButton = this.saveButton;
		this.AutoScaleDimensions = new SizeF(7F, 15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.CancelButton = this.cancelButton;
		this.ClientSize = new Size(800, 450);
		this.Controls.Add(this.tableLayoutPanel1);
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "ItemPrompt";
		this.ShowIcon = false;
		this.StartPosition = FormStartPosition.CenterParent;
		this.Text = "Kalem Düzenleyicisi";
		this.TopMost = true;
		this.FormClosing += this.EntityForm_FormClosing;
		this.Shown += this.EntityForm_Shown;
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		this.tableLayoutPanel2.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	#endregion

	private Button cancelButton;
	private Button saveButton;
	private Label entityIdLabel;
	private TextBox entityIdBox;
	private Label entityNameLabel;
	private TextBox entityNameBox;
	private Label telephoneNumberLabel;
	private MaskedTextBox telephoneNumberBox;
	private TextBox addressBox;
	private Label addressLabel;
	private TableLayoutPanel tableLayoutPanel1;
	private TableLayoutPanel tableLayoutPanel2;
	private Label mersisIdLabel;
	private Label entityTypeLabel;
	private ComboBox entityTypeBox;
	private Label nationalIdLabel;
	private MaskedTextBox nationalIdBox;
	private MaskedTextBox mersisIdBox;
}