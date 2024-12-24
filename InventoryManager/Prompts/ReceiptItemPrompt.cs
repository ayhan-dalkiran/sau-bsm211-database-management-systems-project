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
public partial class ReceiptItemPrompt : Form {
	public RequestType RequestType { get; set; }

	public ReceiptItemPrompt() {
		InitializeComponent();
	}

	private void setSpecialPropertyStates(bool companyEnabled, bool personEnabled) {
		this.mersisIdBox.Enabled = companyEnabled;
		this.nationalIdBox.Enabled = personEnabled;

		if (companyEnabled)
			this.entityNameLabel.Text = "Firma Adı:";
		else if (personEnabled)
			this.entityNameLabel.Text = "Kişi Adı:";
		else
			this.entityNameLabel.Text = "Varlık Adı:";
	}

	private void entityTypeBox_SelectedIndexChanged(object sender, EventArgs e) {
		switch ((EntityType)this.entityTypeBox.SelectedIndex) {
			case EntityType.Company:
				setSpecialPropertyStates(true, false);
				break;
			case EntityType.Person:
				setSpecialPropertyStates(false, true);
				break;
			default:
				setSpecialPropertyStates(false, false);
				break;
		}
	}

	private void EntityForm_Shown(object sender, EventArgs e) {
		switch (this.RequestType) {
			case RequestType.Insert:
				this.entityTypeBox.SelectedIndex = (int)EntityType.Undefined;
				break;
			case RequestType.Update:
				this.entityTypeBox.Enabled = false;
				break;
			default:
				throw new InvalidEnumArgumentException();
		}
	}

	private void EntityForm_FormClosing(object sender, FormClosingEventArgs e) {
		if (this.DialogResult != DialogResult.OK)
			return;

		if (this.telephoneNumberBox.Text != string.Empty && !this.telephoneNumberBox.MaskCompleted) {
			e.Cancel = true;
			MessageBox.Show("Telefon numarasının boş ya da geçerli olması lazım!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		switch ((EntityType)this.entityTypeBox.SelectedIndex) {
			case EntityType.Undefined:
				e.Cancel = true;
				MessageBox.Show("Varlık tipinin seçilmesi lazım!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			case EntityType.Company:
				if (!this.mersisIdBox.MaskCompleted) {
					e.Cancel = true;
					MessageBox.Show("Geçersiz mersis numarası!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return;
			case EntityType.Person:
				if (!this.nationalIdBox.MaskCompleted) {
					e.Cancel = true;
					MessageBox.Show("Geçersiz T.C. kimlik numarası!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return;
		}
	}
}
