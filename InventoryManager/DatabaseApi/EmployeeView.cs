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
	public static async Task UpdateEmployeeView(EntityType entityType = EntityType.Undefined) {
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
					TelephoneNumber = reader.GetString(2),
					Address = reader.GetString(3),
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
					TelephoneNumber = reader.GetString(2),
					Address = reader.GetString(3),
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
					TelephoneNumber = reader.GetString(2),
					Address = reader.GetString(3),
					NationalId = reader.GetString(4),
				};
				list.Add(entity);
			}
			EntityView.DataSource = list;
		}
	}
	public static async Task<Employee> SelectEmployee(int entityId) {
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
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			MersisId = reader.GetString(4),
		};

		return entity;
	}
	public static async Task InsertEmployee(Entity entity) {
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
	public static async Task UpdateEmployee(Entity entity) {
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
	public static async Task DeleteEmployeeBulk(List<int> list) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			DELETE FROM "public"."entity" WHERE "id" = ANY ($1)
			""");
		command.Parameters.AddWithValue(list);
		var c = command.ToString();
		command.ExecuteNonQuery();
	}
}

public record Employee {
	[Browsable(false)] public required int PersonId {}
	[Browsable(false)] public Person Person { get; set; }
	[DisplayName("T.C. Kimlik No")] public string PersonNationalId { get; set; }
	[Browsable(false)] public required int? SupervisorId {
		get => this.Supervisor?.PersonId;
		set {
			if (value is not null)
				this.Supervisor = DatabaseApi.SelectEmployee((int)value).Result;
		}
	}
	[Browsable(false)] public required Employee? Supervisor { get; set; }
	[Browsable(false)] public required int WorkplaceId { get; set; }
	[DisplayName("İşe Alınış Tarihi")] public required DateOnly HireDate { get; set; }
	[DisplayName("Mevki")] public required string Position { get; set; }
	[DisplayName("Maaş")] public required decimal Wage { get; set; }


	[DisplayName("Varlık Adı")] public required string EntityName { get; set; }
	[DisplayName("Telefon Numarası")] public required string TelephoneNumber { get; set; }
	[DisplayName("Adres")] public required string Address { get; set; }
	[Browsable(false)] public EntityType EntityType { get; set; } = EntityType.Undefined;
	[DisplayName("Varlık Tipi")]
	public string EntityTypeString => this.EntityType switch {
		EntityType.Undefined => "Varlık",
		EntityType.Company => "Firma",
		EntityType.Person => "Kişi",
		_ => throw new InvalidEnumArgumentException(),
	};
}
