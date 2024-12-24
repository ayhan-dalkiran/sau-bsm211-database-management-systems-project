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
internal static partial class DatabaseApi {
	public static async Task<BindingList<EntityView>> SelectEntityAllViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"telephone_number",
				"address",
				"entity_name",
				"entity_type"
			FROM "public"."entity";
			""");

		var list = new BindingList<EntityView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new EntityView {
				Id = reader.GetInt32(0),
				TelephoneNumber = reader.GetString(1),
				Address = reader.GetString(2),
				EntityName = reader.GetString(3),
				EntityType = await reader.GetFieldValueAsync<EntityType>(4),
			};
			list.Add(data);
		}

		return list;
	}
	public static async Task<BindingList<CompanyView>> SelectCompanyViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"entity_name",
				"telephone_number",
				"address",
				"mersis_id"
			FROM "public"."company_view";
			""");

		var list = new BindingList<CompanyView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new CompanyView {
				Id = reader.GetInt32(0),
				EntityName = reader.GetString(1),
				TelephoneNumber = reader.GetString(2),
				Address = reader.GetString(3),
				MersisId = reader.GetString(4),
			};
			list.Add(data);
		}

		return list;
	}
	public static async Task<BindingList<PersonView>> SelectPersonViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"entity_name",
				"telephone_number",
				"address",
				"national_id"
			FROM "public"."person_view";
			""");

		var list = new BindingList<PersonView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new PersonView {
				Id = reader.GetInt32(0),
				EntityName = reader.GetString(1),
				TelephoneNumber = reader.GetString(2),
				Address = reader.GetString(3),
				NationalId = reader.GetString(4),
			};
			list.Add(data);
		}

		return list;
	}

	public static async Task<EntityView> SelectEntityView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"telephone_number",
				"address",
				"entity_name",
				"entity_type"
			FROM "public"."entity"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new EntityView {
			Id = reader.GetInt32(0),
			TelephoneNumber = reader.GetString(1),
			Address = reader.GetString(2),
			EntityName = reader.GetString(3),
			EntityType = await reader.GetFieldValueAsync<EntityType>(4),
		};

		return data;
	}
	public static async Task<CompanyView> SelectCompanyView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"entity_name",
				"telephone_number",
				"address",
				"mersis_id"
			FROM "public"."company_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new CompanyView {
			Id = reader.GetInt32(0),
			EntityName = reader.GetString(1),
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			MersisId = reader.GetString(4),
		};

		return data;
	}
	public static async Task<PersonView> SelectPersonView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"entity_name",
				"telephone_number",
				"address",
				"national_id"
			FROM "public"."person_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new PersonView {
			Id = reader.GetInt32(0),
			EntityName = reader.GetString(1),
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			NationalId = reader.GetString(4),
		};

		return data;
	}

	public static async Task<Entity> SelectEntity(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"telephone_number",
				"address",
				"entity_name",
				"entity_type"
			FROM "public"."entity"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Entity {
			Id = reader.GetInt32(0),
			TelephoneNumber = reader.GetString(1),
			Address = reader.GetString(2),
			EntityName = reader.GetString(3),
			EntityType = await reader.GetFieldValueAsync<EntityType>(4)
		};

		return data;
	}
	public static async Task<Company> SelectCompany(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"entity_name",
				"telephone_number",
				"address",
				"mersis_id"
			FROM "public"."company_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Company {
			Id = reader.GetInt32(0),
			EntityName = reader.GetString(1),
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			MersisId = reader.GetString(4),
			EntityType = EntityType.Company,
		};

		return data;
	}
	public static async Task<Person> SelectPerson(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"entity_name",
				"telephone_number",
				"address",
				"national_id"
			FROM "public"."person_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Person {
			Id = reader.GetInt32(0),
			EntityName = reader.GetString(1),
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			NationalId = reader.GetString(4),
			EntityType = EntityType.Person,
		};

		return data;
	}

	public static async Task InsertCompany(Company data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			CALL "public."insert_company"(@entity_name, @telephone_number, @address, @mersis_id)
			""");
		command.Parameters.Add(new NpgsqlParameter<string>("entity_name", data.EntityName));
		command.Parameters.Add(new NpgsqlParameter<string>("telephone_number", data.TelephoneNumber));
		command.Parameters.Add(new NpgsqlParameter<string>("address", data.Address));
		command.Parameters.Add(new NpgsqlParameter<string>("mersis_id", data.MersisId));
		command.ExecuteNonQuery();
	}
	public static async Task InsertPerson(Person data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			CALL "public."insert_person"(@entity_name, @telephone_number, @address, @national_id)
			""");
		command.Parameters.Add(new NpgsqlParameter<string>("entity_name", data.EntityName));
		command.Parameters.Add(new NpgsqlParameter<string>("telephone_number", data.TelephoneNumber));
		command.Parameters.Add(new NpgsqlParameter<string>("address", data.Address));
		command.Parameters.Add(new NpgsqlParameter<string>("national_id", data.NationalId));
		command.ExecuteNonQuery();
	}

	public static async Task UpdateCompany(Company data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			CALL "public."update_company"(@entity_id ,@entity_name, @telephone_number, @address, @mersis_id)
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("entity_id", data.Id));
		command.Parameters.Add(new NpgsqlParameter<string>("entity_name", data.EntityName));
		command.Parameters.Add(new NpgsqlParameter<string>("telephone_number", data.TelephoneNumber));
		command.Parameters.Add(new NpgsqlParameter<string>("address", data.Address));
		command.Parameters.Add(new NpgsqlParameter<string>("mersis_id", data.MersisId));
		command.ExecuteNonQuery();
	}
	public static async Task UpdatePerson(Person data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			CALL "public."update_person"(@entity_name, @telephone_number, @address, @national_id)
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("entity_id", data.Id));
		command.Parameters.Add(new NpgsqlParameter<string>("entity_name", data.EntityName));
		command.Parameters.Add(new NpgsqlParameter<string>("telephone_number", data.TelephoneNumber));
		command.Parameters.Add(new NpgsqlParameter<string>("address", data.Address));
		command.Parameters.Add(new NpgsqlParameter<string>("national_id", data.NationalId));
		command.ExecuteNonQuery();
	}

	public static async Task DeleteEntityBulk(List<int> list) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			DELETE FROM "public"."entity" WHERE "id" = ANY(@list)
			""");
		command.Parameters.Add(new NpgsqlParameter<List<int>>("list", list));
		command.ExecuteNonQuery();
	}
}

public enum EntityType : int {
	Undefined = -1,
	[PgName("company")] Company = 0,
	[PgName("person")] Person = 1,
}

public record EntityView {
	[DisplayName("Varlık No")] public required int Id { get; set; }
	[DisplayName("Varlık Adı")] public required string EntityName { get; set; }
	[DisplayName("Telefon Numarası")] public required string TelephoneNumber { get; set; }
	[DisplayName("Adres")] public required string Address { get; set; }
	[Browsable(false)] public required EntityType EntityType { get; set; }
	[DisplayName("Varlık Tipi")] public string EntityTypeString => this.EntityType switch {
		EntityType.Company => "Firma",
		EntityType.Person => "Kişi",
		_ => throw new InvalidEnumArgumentException(),
	};
}
public record Entity {
	public required int Id { get; set; }
	public required string EntityName { get; set; }
	public required string TelephoneNumber { get; set; }
	public required string Address { get; set; }
	public required EntityType EntityType { get; set; }
}

public record CompanyView {
	[DisplayName("Varlık No")] public required int Id { get; set; }
	[DisplayName("Firma Adı")] public required string EntityName { get; set; }
	[DisplayName("Telefon Numarası")] public required string TelephoneNumber { get; set; }
	[DisplayName("Adres")] public required string Address { get; set; }
	[DisplayName("Mersis No")] public required string MersisId { get; set; }
}
public record Company : Entity {
	public required string MersisId { get; set; }
}

public record PersonView {
	[DisplayName("Varlık No")] public required int Id { get; set; }
	[DisplayName("Kişi Adı")] public required string EntityName { get; set; }
	[DisplayName("Telefon Numarası")] public required string TelephoneNumber { get; set; }
	[DisplayName("Adres")] public required string Address { get; set; }
	[DisplayName("T.C. Kimlik No")] public required string NationalId { get; set; }
}
public record Person : Entity {
	public required string NationalId { get; set; }
}