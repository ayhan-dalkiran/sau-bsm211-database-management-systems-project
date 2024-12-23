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
public partial class EmployeePrompt : Form {
	public RequestType RequestType { get; set; }
	public Entity EntityObject {
		get {
			var entity = new Entity {
				Id = Convert.ToInt32(this.entityIdBox.Text),
				EntityName = this.entityNameBox.Text.Trim(),
				TelephoneNumber = this.telephoneNumberBox.Text.Trim() != string.Empty ? this.telephoneNumberBox.Text : null,
				Address = this.addressBox.Text.Trim() != string.Empty ? this.addressBox.Text : null,
			};

			return (EntityType)this.entityTypeBox.SelectedIndex switch {
				EntityType.Undefined => entity,
				EntityType.Company => new Company(entity, this.mersisIdBox.Text),
				EntityType.Person => new Person(entity, this.nationalIdBox.Text),
				_ => throw new InvalidEnumArgumentException(),
			};
		}
		set {
			this.entityIdBox.Text = Convert.ToString(value.Id);
			this.entityNameBox.Text = value.EntityName;
			this.telephoneNumberBox.Text = value.TelephoneNumber ?? string.Empty;
			this.addressBox.Text = value.Address ?? string.Empty;
			this.entityTypeBox.SelectedIndex = (int)value.EntityType;

			switch (value.EntityType) {
				case EntityType.Company:
					this.mersisIdBox.Text = ((Company)value).MersisId;
					break;
				case EntityType.Person:
					this.nationalIdBox.Text = ((Person)value).NationalId;
					break;
			}
		}
	}

	public EmployeePrompt() {
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
			case RequestType.Add:
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
