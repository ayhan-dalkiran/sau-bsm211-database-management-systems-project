namespace InventoryManager;

partial class PostgresqlDataGridView {
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

	#region Component Designer generated code

	/// <summary> 
	/// Required method for Designer support - do not modify 
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
		this.tableLayoutPanel1 = new TableLayoutPanel();
		this.dataGrid = new DataGridView();
		this.tableLayoutPanel2 = new TableLayoutPanel();
		this.searchButton = new Button();
		this.searchBox = new TextBox();
		this.tableLayoutPanel3 = new TableLayoutPanel();
		this.progressBar = new ProgressBar();
		this.addButton = new Button();
		this.updateButton = new Button();
		this.deleteButton = new Button();
		this.tableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGrid).BeginInit();
		this.tableLayoutPanel2.SuspendLayout();
		this.tableLayoutPanel3.SuspendLayout();
		this.SuspendLayout();
		// 
		// tableLayoutPanel1
		// 
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel1.Controls.Add(this.dataGrid, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
		this.tableLayoutPanel1.Dock = DockStyle.Fill;
		this.tableLayoutPanel1.Location = new Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 3;
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
		this.tableLayoutPanel1.Size = new Size(557, 303);
		this.tableLayoutPanel1.TabIndex = 0;
		// 
		// dataGrid
		// 
		this.dataGrid.AllowUserToAddRows = false;
		this.dataGrid.AllowUserToDeleteRows = false;
		this.dataGrid.AllowUserToOrderColumns = true;
		this.dataGrid.AllowUserToResizeRows = false;
		this.dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle1.BackColor = SystemColors.Window;
		dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
		dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle1.NullValue = "*boş*";
		dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
		this.dataGrid.DefaultCellStyle = dataGridViewCellStyle1;
		this.dataGrid.Dock = DockStyle.Fill;
		this.dataGrid.Location = new Point(6, 41);
		this.dataGrid.Margin = new Padding(6);
		this.dataGrid.Name = "dataGrid";
		this.dataGrid.ReadOnly = true;
		this.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGrid.Size = new Size(545, 222);
		this.dataGrid.TabIndex = 0;
		this.dataGrid.SelectionChanged += this.dataGrid_SelectionChanged;
		// 
		// tableLayoutPanel2
		// 
		this.tableLayoutPanel2.AutoSize = true;
		this.tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.tableLayoutPanel2.ColumnCount = 2;
		this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel2.Controls.Add(this.searchButton, 1, 0);
		this.tableLayoutPanel2.Controls.Add(this.searchBox, 0, 0);
		this.tableLayoutPanel2.Dock = DockStyle.Fill;
		this.tableLayoutPanel2.Location = new Point(3, 3);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel2.Size = new Size(551, 29);
		this.tableLayoutPanel2.TabIndex = 1;
		// 
		// searchButton
		// 
		this.searchButton.Dock = DockStyle.Fill;
		this.searchButton.Location = new Point(473, 3);
		this.searchButton.Name = "searchButton";
		this.searchButton.Size = new Size(75, 23);
		this.searchButton.TabIndex = 0;
		this.searchButton.Text = "Ara";
		this.searchButton.UseVisualStyleBackColor = true;
		this.searchButton.Click += this.searchButton_Click;
		// 
		// searchBox
		// 
		this.searchBox.Dock = DockStyle.Fill;
		this.searchBox.Location = new Point(3, 3);
		this.searchBox.Name = "searchBox";
		this.searchBox.Size = new Size(464, 23);
		this.searchBox.TabIndex = 1;
		// 
		// tableLayoutPanel3
		// 
		this.tableLayoutPanel3.ColumnCount = 4;
		this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
		this.tableLayoutPanel3.Controls.Add(this.progressBar, 0, 0);
		this.tableLayoutPanel3.Controls.Add(this.addButton, 1, 0);
		this.tableLayoutPanel3.Controls.Add(this.updateButton, 2, 0);
		this.tableLayoutPanel3.Controls.Add(this.deleteButton, 3, 0);
		this.tableLayoutPanel3.Dock = DockStyle.Fill;
		this.tableLayoutPanel3.Location = new Point(3, 272);
		this.tableLayoutPanel3.Name = "tableLayoutPanel3";
		this.tableLayoutPanel3.RowCount = 1;
		this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		this.tableLayoutPanel3.Size = new Size(551, 28);
		this.tableLayoutPanel3.TabIndex = 2;
		// 
		// progressBar
		// 
		this.progressBar.Dock = DockStyle.Fill;
		this.progressBar.Location = new Point(3, 3);
		this.progressBar.Name = "progressBar";
		this.progressBar.Size = new Size(302, 22);
		this.progressBar.TabIndex = 0;
		// 
		// addButton
		// 
		this.addButton.Location = new Point(311, 3);
		this.addButton.Name = "addButton";
		this.addButton.Size = new Size(75, 22);
		this.addButton.TabIndex = 1;
		this.addButton.Text = "Ekle..";
		this.addButton.UseVisualStyleBackColor = true;
		// 
		// updateButton
		// 
		this.updateButton.Enabled = false;
		this.updateButton.Location = new Point(392, 3);
		this.updateButton.Name = "updateButton";
		this.updateButton.Size = new Size(75, 22);
		this.updateButton.TabIndex = 2;
		this.updateButton.Text = "Güncelle..";
		this.updateButton.UseVisualStyleBackColor = true;
		// 
		// deleteButton
		// 
		this.deleteButton.Enabled = false;
		this.deleteButton.Location = new Point(473, 3);
		this.deleteButton.Name = "deleteButton";
		this.deleteButton.Size = new Size(75, 22);
		this.deleteButton.TabIndex = 3;
		this.deleteButton.Text = "Sil..";
		this.deleteButton.UseVisualStyleBackColor = true;
		this.deleteButton.Click += this.deleteButton_Click;
		// 
		// PostgresqlDataGridView
		// 
		this.AutoScaleDimensions = new SizeF(7F, 15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.Controls.Add(this.tableLayoutPanel1);
		this.Name = "PostgresqlDataGridView";
		this.Size = new Size(557, 303);
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGrid).EndInit();
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.tableLayoutPanel3.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	#endregion

	private TableLayoutPanel tableLayoutPanel1;
	private TableLayoutPanel tableLayoutPanel2;
	private Button searchButton;
	private TextBox searchBox;
	private TableLayoutPanel tableLayoutPanel3;
	private ProgressBar progressBar;
	private Button addButton;
	private Button updateButton;
	private Button deleteButton;
	private DataGridView dataGrid;
}
