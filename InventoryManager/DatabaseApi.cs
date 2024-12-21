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
		Builder.MapEnum<EntityType>("entity_type");
		Builder.MapEnum<ItemType>("item_type");
	}

	public static async Task UpdateViewBulk() {
		await DatabaseApi.UpdateItemView();
		//DatabaseApi.UpdateReceiptView();
		//DatabaseApi.UpdateShipmentView();
		await DatabaseApi.UpdateEntityView();
		//DatabaseApi.UpdateEmployeeView();
		//DatabaseApi.UpdateWorkplaceView();
	}

	public static async Task UpdateItemView(ItemType? itemType = null) {

	}
	//public static async Task UpdateReceiptView() { }
	//public static async Task UpdateShipmentView() { }
	//public static async Task UpdateEmployeeView() { }
	//public static async Task UpdateWorkplaceView() { }

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
	[DisplayName("Kalem Adı")] public required string ItemName { get; set; }
	[Browsable(false)] public required Company Manufacturer { get; set; }
	[DisplayName("İmalatçı Adı")] public required string? Barcode { get; set; }
	[DisplayName("İmalatçı Adı")] public required long Amount { get; set; }
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
	[DisplayName("Enerji (kcal/100g)")] public required decimal Energy { get; set; }
	[DisplayName("Yağ (g/100g)")] public required double Fat { get; set; }
	[DisplayName("Doymuş Yağ (g/100g)")] public required double SaturatedFat { get; set; }
	[DisplayName("Karbonhidrat (g/100g)")] public required double Carbonhydrate { get; set; }
	[DisplayName("Şekerler (g/100g)")] public required double Sugar { get; set; }
	[DisplayName("Protein (g/100g)")] public required double Protein { get; set; }
	[DisplayName("Tuz (g/100g)")] public required double Salt { get; set; }

	public Chemical() => this.ItemType = ItemType.Food;
	[SetsRequiredMembers] public Chemical(
		Item item,
		string mersisId
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
