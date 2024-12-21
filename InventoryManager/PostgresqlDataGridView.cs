using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager;
public partial class PostgresqlDataGridView : UserControl {
	public object GridDataSource {
		get => this.dataGrid.DataSource;
		set => this.dataGrid.DataSource = value;
	}
	public string SearchBoxText {
		get => this.searchBox.Text;
		set => this.searchBox.Text = value;
	}
	public DataGridViewSelectedRowCollection SelectedRows => this.dataGrid.SelectedRows;
	public object SelectedRowObject => this.dataGrid.SelectedRows[0].DataBoundItem;

	public event EventHandler? OnAddRequest {
		add => this.addButton.Click += value;
		remove => this.addButton.Click -= value;
	}
	public event EventHandler? OnUpdateRequest {
		add => this.updateButton.Click += value;
		remove => this.updateButton.Click -= value;
	}
	public event EventHandler? OnDeleteRequest;
	public event EventHandler? OnSearchRequest {
		add => this.searchButton.Click += value;
		remove => this.searchButton.Click -= value;
	}

	public PostgresqlDataGridView() {
		InitializeComponent();
	}

	private void dataGrid_SelectionChanged(object sender, EventArgs e) {
		switch (this.dataGrid.SelectedRows.Count) {
			case 0:
				this.updateButton.Enabled = false;
				this.deleteButton.Enabled = false;
				break;
			case 1:
				this.updateButton.Enabled = true;
				this.deleteButton.Enabled = true;
				break;
			default:
				this.updateButton.Enabled = false;
				this.deleteButton.Enabled = true;
				break;
		}
	}

	private void deleteButton_Click(object sender, EventArgs e) {
		var result = MessageBox.Show(
			$"{this.dataGrid.SelectedRows.Count} tane kayıt silinecek. Devam etmek istiyor musunuz?",
			"Uyarı!",
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Exclamation,
			MessageBoxDefaultButton.Button2);

		if (result != DialogResult.Yes)
			return;

		this.OnDeleteRequest?.Invoke(sender, e);
	}
}

public enum RequestType : int {
	Add = 0,
	Update = 1,
	Delete = 2,
	Search = 3,
}
