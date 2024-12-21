using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using NpgsqlTypes;

namespace InventoryManager;
internal static class DatabaseApi {
	public static BindingSource ItemView { get; } = new();
	public static BindingSource ReceiptView { get; } = new();
	public static BindingSource ShipmentView { get; } = new();
	public static BindingSource EntityView { get; } = new();
	public static BindingSource EmployeeView { get; } = new();
	public static BindingSource WorkplaceView { get; } = new();

	public static NpgsqlDataSourceBuilder Builder { get; } = new("""
		Host=localhost;
		Username=postgres;
		Password=admin;
		Database=Proje;
		Max Auto Prepare=30;
		Include Error Detail=true;
		""");
	static DatabaseApi() {
		Builder.MapEnum<ItemType>("item_type");
		Builder.MapEnum<EntityType>("entity_type");
		Builder.MapEnum<WorkplaceType>("workplace_type");
	}

	public static async Task UpdateViewBulk() {
		await DatabaseApi.UpdateItemView();
		//DatabaseApi.UpdateReceiptView();
		//DatabaseApi.UpdateShipmentView();
		await DatabaseApi.UpdateEntityView();
		//DatabaseApi.UpdateEmployeeView();
		//DatabaseApi.UpdateWorkplaceView();
	}

	#region ItemView

	public static async Task UpdateItemView(ItemType? itemType = null) {
		await using var dataSource = Builder.Build();

		if (itemType == ItemType.Other) {
			await using var command = dataSource.CreateCommand("""
				SELECT "id", "thumbnail_blob", "item_name", "manufacturer_id", "barcode", "amount", "item_type"
				FROM "public"."item_view"
				""");

			var list = new BindingList<Item>();
			using var reader = await command.ExecuteReaderAsync();
			while (await reader.ReadAsync()) {
				var item = new Item {
					Id = reader.GetInt32(0),
					Thumbnail = await reader.IsDBNullAsync(1) ? null : null,
					ItemName = reader.GetString(2),
					Manufacturer = await DatabaseApi.SelectCompany(reader.GetInt32(3)),
					Barcode = await reader.IsDBNullAsync(4) ? null : reader.GetString(4),
					Amount = reader.GetInt64(5),
					ItemType = await reader.GetFieldValueAsync<ItemType>(6)
				};
				list.Add(item);
			}
			ItemView.DataSource = list;
		}
		else if (itemType == ItemType.Food) {
			await using var command = dataSource.CreateCommand("""
				SELECT "id", "thumbnail_blob", "item_name", "manufacturer_id", "barcode", "amount",
				"energy", "fat", "saturated_fat", "carbonhydrate", "sugar", "protein", "salt"
				FROM "public"."food_view"
				""");

			var list = new BindingList<Food>();
			using var reader = await command.ExecuteReaderAsync();
			while (await reader.ReadAsync()) {
				var item = new Food {
					Id = reader.GetInt32(0),
					Thumbnail = await reader.IsDBNullAsync(1) ? null : null,
					ItemName = reader.GetString(2),
					Manufacturer = await DatabaseApi.SelectCompany(reader.GetInt32(3)),
					Barcode = await reader.IsDBNullAsync(4) ? null : reader.GetString(4),
					Amount = reader.GetInt64(5),
					Energy = reader.GetDecimal(6),
					Fat	= reader.GetDecimal(7),
					SaturatedFat = reader.GetDecimal(8),
					Carbonhydrate = reader.GetDecimal(9),
					Sugar = reader.GetDecimal(10),
					Protein = reader.GetDecimal(11),
					Salt = reader.GetDecimal(12),

				};
				list.Add(item);
			}
			ItemView.DataSource = list;
		}
		else {
			await using var command = dataSource.CreateCommand("""
				SELECT "id", "entity_name", "telephone_number", "address", "national_id",
				"explosive", "flammable", "oxidizing", "compressed_gas", "corrosive",
				"toxic", "health_hazard", "serious_health_hazard", "environment_hazard",
				"infectious", "radioactive"
				FROM "public"."chemical_view"
				""");

			var list = new BindingList<Chemical>();
			using var reader = await command.ExecuteReaderAsync();
			while (await reader.ReadAsync()) {
				var item = new Chemical {
					Id = reader.GetInt32(0),
					Thumbnail = await reader.IsDBNullAsync(1) ? null : null,
					ItemName = reader.GetString(2),
					Manufacturer = await DatabaseApi.SelectCompany(reader.GetInt32(3)),
					Barcode = await reader.IsDBNullAsync(4) ? null : reader.GetString(4),
					Amount = reader.GetInt64(5),
					Explosive = reader.GetBoolean(6),
					Flammable = reader.GetBoolean(7),
					Oxidizing = reader.GetBoolean(8),
					CompressedGas = reader.GetBoolean(9),
					Corrosive = reader.GetBoolean(10),
					Toxic = reader.GetBoolean(11),
					HealthHazard = reader.GetBoolean(12),
					SeriousHealthHazard = reader.GetBoolean(13),
					EnvironmentHazard = reader.GetBoolean(14),
					Infectious = reader.GetBoolean(15),
					Radioactive = reader.GetBoolean(16),
				};
				list.Add(item);
			}
			ItemView.DataSource = list;
		}
	}
	public static async Task<Item> SelectOtherItem(int itemId) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "thumbnail_blob", "item_name", "manufacturer_id", "barcode", "amount"
			FROM "public"."item_view" WHERE "id" = $1
			""");
		command.Parameters.AddWithValue(itemId);

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var item = new Item {
			Id = reader.GetInt32(0),
			Thumbnail = await reader.IsDBNullAsync(1) ? null : null,
			ItemName = reader.GetString(2),
			Manufacturer = await DatabaseApi.SelectCompany(reader.GetInt32(3)),
			Barcode = await reader.IsDBNullAsync(4) ? null : reader.GetString(4),
			Amount = reader.GetInt64(5),
			ItemType = ItemType.Other,
		};

		return item;
	}
	public static async Task<Food> SelectFood(int entityId) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "thumbnail_blob", "item_name", "manufacturer_id", "barcode", "amount",
			"energy", "fat", "saturated_fat", "carbonhydrate", "sugar", "protein", "salt"
			FROM "public"."food_view" WHERE "id" = $1
			""");
		command.Parameters.AddWithValue(entityId);

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var item = new Food {
			Id = reader.GetInt32(0),
			Thumbnail = await reader.IsDBNullAsync(1) ? null : null,
			ItemName = reader.GetString(2),
			Manufacturer = await DatabaseApi.SelectCompany(reader.GetInt32(3)),
			Barcode = await reader.IsDBNullAsync(4) ? null : reader.GetString(4),
			Amount = reader.GetInt64(5),
			Energy = reader.GetDecimal(6),
			Fat = reader.GetDecimal(7),
			SaturatedFat = reader.GetDecimal(8),
			Carbonhydrate = reader.GetDecimal(9),
			Sugar = reader.GetDecimal(10),
			Protein = reader.GetDecimal(11),
			Salt = reader.GetDecimal(12),

		};

		return item;
	}
	public static async Task<Chemical> SelectChemical(int entityId) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "entity_name", "telephone_number", "address", "national_id",
			"explosive", "flammable", "oxidizing", "compressed_gas", "corrosive",
			"toxic", "health_hazard", "serious_health_hazard", "environment_hazard",
			"infectious", "radioactive"
			FROM "public"."chemical_view" WHERE "id" = $1
			""");
		command.Parameters.AddWithValue(entityId);

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var item = new Chemical {
			Id = reader.GetInt32(0),
			Thumbnail = await reader.IsDBNullAsync(1) ? null : null,
			ItemName = reader.GetString(2),
			Manufacturer = await DatabaseApi.SelectCompany(reader.GetInt32(3)),
			Barcode = await reader.IsDBNullAsync(4) ? null : reader.GetString(4),
			Amount = reader.GetInt64(5),
			Explosive = reader.GetBoolean(6),
			Flammable = reader.GetBoolean(7),
			Oxidizing = reader.GetBoolean(8),
			CompressedGas = reader.GetBoolean(9),
			Corrosive = reader.GetBoolean(10),
			Toxic = reader.GetBoolean(11),
			HealthHazard = reader.GetBoolean(12),
			SeriousHealthHazard = reader.GetBoolean(13),
			EnvironmentHazard = reader.GetBoolean(14),
			Infectious = reader.GetBoolean(15),
			Radioactive = reader.GetBoolean(16),
		};

		return item;
	}
	public static async Task InsertItem(Item item) {
		await using var dataSource = Builder.Build();

		if (entity.EntityType == EntityType.Company) {
			var company = (Company)entity;
			await using var command = dataSource.CreateCommand("""
				CALL "public"."InsertCompany"($1, $2, $3, $4)
				""");
			command.Parameters.AddWithValue(company.EntityName);
			command.Parameters.AddWithValue((object?)company.TelephoneNumber ?? DBNull.Value);
			command.Parameters.AddWithValue((object?)company.Address ?? DBNull.Value);
			command.Parameters.AddWithValue(company.MersisId);
			command.ExecuteNonQuery();
		}
		else {
			var person = (Person)entity;
			await using var command = dataSource.CreateCommand("""
				CALL "public"."InsertPerson"($1, $2, $3, $4)
				""");
			command.Parameters.AddWithValue(person.EntityName);
			command.Parameters.AddWithValue((object?)person.TelephoneNumber ?? DBNull.Value);
			command.Parameters.AddWithValue((object?)person.Address ?? DBNull.Value);
			command.Parameters.AddWithValue(person.NationalId);
			command.ExecuteNonQuery();
		}
	}
	public static async Task UpdateEntity(Entity entity) {
		await using var dataSource = Builder.Build();

		if (entity.EntityType == EntityType.Company) {
			var company = (Company)entity;
			await using var command = dataSource.CreateCommand("""
				CALL "public"."UpdateCompany"($1, $2, $3, $4, $5)
				""");
			command.Parameters.AddWithValue(company.Id);
			command.Parameters.AddWithValue(company.EntityName);
			command.Parameters.AddWithValue((object?)company.TelephoneNumber ?? DBNull.Value);
			command.Parameters.AddWithValue((object?)company.Address ?? DBNull.Value);
			command.Parameters.AddWithValue(company.MersisId);
			command.ExecuteNonQuery();
		}
		else {
			var person = (Person)entity;
			await using var command = dataSource.CreateCommand("""
				CALL "public"."UpdatePerson"($1, $2, $3, $4, $5)
				""");
			command.Parameters.AddWithValue(person.Id);
			command.Parameters.AddWithValue(person.EntityName);
			command.Parameters.AddWithValue((object?)person.TelephoneNumber ?? DBNull.Value);
			command.Parameters.AddWithValue((object?)person.Address ?? DBNull.Value);
			command.Parameters.AddWithValue(person.NationalId);
			command.ExecuteNonQuery();
		}
	}
	public static async Task DeleteEntityBulk(List<int> list) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			DELETE FROM "public"."entity" WHERE "id" = ANY ($1)
			""");
		command.Parameters.AddWithValue(list);
		var c = command.ToString();
		command.ExecuteNonQuery();
	}

	#endregion

	//public static async Task UpdateReceiptView() { }
	//public static async Task UpdateShipmentView() { }
	//public static async Task UpdateEmployeeView() { }
	//public static async Task UpdateWorkplaceView() { }

	#region EntityView

	public static async Task UpdateEntityView(EntityType entityType = EntityType.Undefined) {
		await using var dataSource = Builder.Build();

		if (entityType == EntityType.Undefined) {
			await using var command = dataSource.CreateCommand("""
				SELECT "id", "entity_name", "telephone_number", "address", "entity_type"
				FROM "public"."entity"
				""");

			var list = new BindingList<Entity>();
			using var reader = await command.ExecuteReaderAsync();
			while (await reader.ReadAsync()) {
				var entity = new Entity {
					Id = reader.GetInt32(0),
					EntityName = reader.GetString(1),
					TelephoneNumber = await reader.IsDBNullAsync(2) ? null : reader.GetString(2),
					Address = await reader.IsDBNullAsync(3) ? null : reader.GetString(3),
					EntityType = await reader.GetFieldValueAsync<EntityType>(4),
				};
				list.Add(entity);
			}
			EntityView.DataSource = list;
		}
		else if (entityType == EntityType.Company) {
			await using var command = dataSource.CreateCommand("""
				SELECT "id", "entity_name", "telephone_number", "address", "mersis_id"
				FROM "public"."company_view"
				""");

			var list = new BindingList<Company>();
			using var reader = await command.ExecuteReaderAsync();
			while (await reader.ReadAsync()) {
				var entity = new Company {
					Id = reader.GetInt32(0),
					EntityName = reader.GetString(1),
					TelephoneNumber = await reader.IsDBNullAsync(2) ? null : reader.GetString(2),
					Address = await reader.IsDBNullAsync(3) ? null : reader.GetString(3),
					MersisId = reader.GetString(4),
				};
				list.Add(entity);
			}
			EntityView.DataSource = list;
		}
		else {
			await using var command = dataSource.CreateCommand("""
				SELECT "id", "entity_name", "telephone_number", "address", "national_id"
				FROM "public"."person_view"
				""");

			var list = new BindingList<Person>();
			using var reader = await command.ExecuteReaderAsync();
			while (await reader.ReadAsync()) {
				var entity = new Person {
					Id = reader.GetInt32(0),
					EntityName = reader.GetString(1),
					TelephoneNumber = await reader.IsDBNullAsync(2) ? null : reader.GetString(2),
					Address = await reader.IsDBNullAsync(3) ? null : reader.GetString(3),
					NationalId = reader.GetString(4),
				};
				list.Add(entity);
			}
			EntityView.DataSource = list;
		}
	}
	public static async Task<Company> SelectCompany(int entityId) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "entity_name", "telephone_number", "address", "mersis_id"
			FROM "public"."company_view" WHERE "id" = $1
			""");
		command.Parameters.AddWithValue(entityId);

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var entity = new Company {
			Id = reader.GetInt32(0),
			EntityName = reader.GetString(1),
			TelephoneNumber = await reader.IsDBNullAsync(2) ? null : reader.GetString(2),
			Address = await reader.IsDBNullAsync(3) ? null : reader.GetString(3),
			MersisId = reader.GetString(4),
		};
		
		return entity;
	}
	public static async Task<Person> SelectPerson(int entityId) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "entity_name", "telephone_number", "address", "national_id"
			FROM "public"."person_view" WHERE "id" = $1
			""");
		command.Parameters.AddWithValue(entityId);

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var entity = new Person {
			Id = reader.GetInt32(0),
			EntityName = reader.GetString(1),
			TelephoneNumber = await reader.IsDBNullAsync(2) ? null : reader.GetString(2),
			Address = await reader.IsDBNullAsync(3) ? null : reader.GetString(3),
			NationalId = reader.GetString(4),
		};

		return entity;
	}
	public static async Task InsertEntity(Entity entity) {
		await using var dataSource = Builder.Build();

		if (entity.EntityType == EntityType.Company) {
			var company = (Company)entity;
			await using var command = dataSource.CreateCommand("""
				CALL "public"."InsertCompany"($1, $2, $3, $4)
				""");
			command.Parameters.AddWithValue(company.EntityName);
			command.Parameters.AddWithValue((object?)company.TelephoneNumber ?? DBNull.Value);
			command.Parameters.AddWithValue((object?)company.Address ?? DBNull.Value);
			command.Parameters.AddWithValue(company.MersisId);
			command.ExecuteNonQuery();
		}
		else {
			var person = (Person)entity;
			await using var command = dataSource.CreateCommand("""
				CALL "public"."InsertPerson"($1, $2, $3, $4)
				""");
			command.Parameters.AddWithValue(person.EntityName);
			command.Parameters.AddWithValue((object?)person.TelephoneNumber ?? DBNull.Value);
			command.Parameters.AddWithValue((object?)person.Address ?? DBNull.Value);
			command.Parameters.AddWithValue(person.NationalId);
			command.ExecuteNonQuery();
		}
	}
	public static async Task UpdateEntity(Entity entity) {
		await using var dataSource = Builder.Build();

		if (entity.EntityType == EntityType.Company) {
			var company = (Company)entity;
			await using var command = dataSource.CreateCommand("""
				CALL "public"."UpdateCompany"($1, $2, $3, $4, $5)
				""");
			command.Parameters.AddWithValue(company.Id);
			command.Parameters.AddWithValue(company.EntityName);
			command.Parameters.AddWithValue((object?)company.TelephoneNumber ?? DBNull.Value);
			command.Parameters.AddWithValue((object?)company.Address ?? DBNull.Value);
			command.Parameters.AddWithValue(company.MersisId);
			command.ExecuteNonQuery();
		}
		else {
			var person = (Person)entity;
			await using var command = dataSource.CreateCommand("""
				CALL "public"."UpdatePerson"($1, $2, $3, $4, $5)
				""");
			command.Parameters.AddWithValue(person.Id);
			command.Parameters.AddWithValue(person.EntityName);
			command.Parameters.AddWithValue((object?)person.TelephoneNumber ?? DBNull.Value);
			command.Parameters.AddWithValue((object?)person.Address ?? DBNull.Value);
			command.Parameters.AddWithValue(person.NationalId);
			command.ExecuteNonQuery();
		}
	}
	public static async Task DeleteEntityBulk(List<int> list) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			DELETE FROM "public"."entity" WHERE "id" = ANY ($1)
			""");
		command.Parameters.AddWithValue(list);
		var c = command.ToString();
		command.ExecuteNonQuery();
	}

	#endregion
}

public enum ItemType : int {
	[PgName("other")] Other = 0,
	[PgName("food")] Food = 1,
	[PgName("chemical")] Chemical = 2,
}
public enum EntityType : int {
	Undefined = -1,
	[PgName("company")] Company = 0,
	[PgName("person")] Person = 1,
}
public enum WorkplaceType : int {
	Undefined = -1,
	[PgName("warehouse")] Warehouse = 0,
	[PgName("office")] Office = 1,
}

public record Item {
	[DisplayName("Kalem No")] public required int Id { get; set; }
	[DisplayName("Önizleme")] public required Image? Thumbnail { get; set; }
	[DisplayName("Kalem Adı")] public required string ItemName { get; set; }
	[Browsable(false)] public required Company Manufacturer { get; set; }
	[DisplayName("İmalatçı Adı")] public string ManufacturerName => Manufacturer.EntityName;
	[DisplayName("Barkod")] public required string? Barcode { get; set; }
	[DisplayName("Adet")] public required long Amount { get; set; }
	[Browsable(false)] public ItemType ItemType { get; set; } = ItemType.Other;
	[DisplayName("Kalem Tipi")] public string ItemTypeString => this.ItemType switch {
		ItemType.Other => "Diğer",
		ItemType.Food => "Gıda",
		ItemType.Chemical => "Kimyasal",
		_ => throw new InvalidEnumArgumentException(),
	};
}
public record Food : Item {
	[DisplayName("Enerji (kcal/100g)")] public required decimal Energy { get; set; }
	[DisplayName("Yağ (g/100g)")] public required decimal Fat { get; set; }
	[DisplayName("Doymuş Yağ (g/100g)")] public required decimal SaturatedFat { get; set; }
	[DisplayName("Karbonhidrat (g/100g)")] public required decimal Carbonhydrate { get; set; }
	[DisplayName("Şekerler (g/100g)")] public required decimal Sugar { get; set; }
	[DisplayName("Protein (g/100g)")] public required decimal Protein { get; set; }
	[DisplayName("Tuz (g/100g)")] public required decimal Salt { get; set; }

	public Food() => this.ItemType = ItemType.Food;
	[SetsRequiredMembers] public Food(
		Item item
	) : base(item) {

	}
}
public record Chemical : Item {
	[DisplayName("Patlayıcı")] public required bool Explosive { get; set; }
	[DisplayName("Yanıcı")] public required bool Flammable { get; set; }
	[DisplayName("Oksitleyici")] public required bool Oxidizing { get; set; }
	[DisplayName("Sıkıştırılmış Gaz")] public required bool CompressedGas { get; set; }
	[DisplayName("Aşındırıcı")] public required bool Corrosive { get; set; }
	[DisplayName("Zehirli")] public required bool Toxic { get; set; }
	[DisplayName("Zararlı")] public required bool HealthHazard { get; set; }
	[DisplayName("Sağlık Tehlikesi")] public required bool SeriousHealthHazard { get; set; }
	[DisplayName("Çevresel Tehlike")] public required bool EnvironmentHazard { get; set; }
	[DisplayName("Bulaşıcı Madde")] public required bool Infectious { get; set; }
	[DisplayName("Radyoaktif Materyal")] public required bool Radioactive { get; set; }

	public Chemical() => this.ItemType = ItemType.Chemical;
	[SetsRequiredMembers] public Chemical(
		Item item
	) : base(item) {

	}
}

public record Entity {
	[DisplayName("Varlık No")] public required int Id { get; set; }
	[DisplayName("Varlık Adı")] public required string EntityName { get; set; }
	[DisplayName("Telefon Numarası")] public required string? TelephoneNumber { get; set; }
	[DisplayName("Adres")] public required string? Address { get; set; }
	[Browsable(false)] public EntityType EntityType { get; set; } = EntityType.Undefined;
	[DisplayName("Varlık Tipi")] public string EntityTypeString => this.EntityType switch {
		EntityType.Undefined => "Varlık",
		EntityType.Company => "Firma",
		EntityType.Person => "Kişi",
		_ => throw new InvalidEnumArgumentException(),
	};
}
public record Company : Entity {
	[DisplayName("Mersis No")] public required string MersisId { get; set; }

	public Company() => this.EntityType = EntityType.Company;
	[SetsRequiredMembers] public Company(Entity entity, string mersisId) : base(entity) => this.MersisId = mersisId;
}
public record Person : Entity {
	[DisplayName("T.C. Kimlik No")] public required string NationalId { get; set; }

	public Person() => base.EntityType = EntityType.Person;
	[SetsRequiredMembers] public Person(Entity entity, string nationalId) : base(entity) => this.NationalId = nationalId;
}
