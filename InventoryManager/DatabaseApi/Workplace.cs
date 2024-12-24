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
	public static async Task<BindingList<WorkplaceView>> SelectWorkplaceViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"supervisor_name",
				"workplace_type"
			FROM "public"."workplace_view";
			""");

		var list = new BindingList<WorkplaceView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new WorkplaceView {
				Id = reader.GetInt32(0),
				WorkplaceName = reader.GetString(1),
				WorkplaceTelephoneNumber = reader.GetString(2),
				WorkplaceAddress = reader.GetString(3),
				SupervisorId = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4),
				SupervisorName = await reader.IsDBNullAsync(5) ? null : reader.GetString(5),
				WorkplaceType = await reader.GetFieldValueAsync<WorkplaceType>(6)
			};
			list.Add(data);
		}

		return list;
	}
	public static async Task<BindingList<WarehouseView>> SelectWarehouseViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"supervisor_name",
				"warehouse_volume"
			FROM "public"."warehouse_view";
			""");

		var list = new BindingList<WarehouseView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new WarehouseView {
				Id = reader.GetInt32(0),
				WorkplaceName = reader.GetString(1),
				WorkplaceTelephoneNumber = reader.GetString(2),
				WorkplaceAddress = reader.GetString(3),
				SupervisorId = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4),
				SupervisorName = await reader.IsDBNullAsync(5) ? null : reader.GetString(5),
				WarehouseVolume = reader.GetInt64(6),
			};
			list.Add(data);
		}

		return list;
	}
	public static async Task<BindingList<OfficeView>> SelectOfficeViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"supervisor_name",
				"floor_count",
				"floor_size"
			FROM "public"."office_view";
			""");

		var list = new BindingList<OfficeView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new OfficeView {
				Id = reader.GetInt32(0),
				WorkplaceName = reader.GetString(1),
				WorkplaceTelephoneNumber = reader.GetString(2),
				WorkplaceAddress = reader.GetString(3),
				SupervisorId = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4),
				SupervisorName = await reader.IsDBNullAsync(5) ? null : reader.GetString(5),
				FloorCount = reader.GetInt64(6),
				FloorSize = reader.GetInt64(7),
			};
			list.Add(data);
		}

		return list;
	}

	public static async Task<WorkplaceView> SelectWorkplaceView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"supervisor_name",
				"workplace_type"
			FROM "public"."workplace_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new WorkplaceView {
			Id = reader.GetInt32(0),
			WorkplaceName = reader.GetString(1),
			WorkplaceTelephoneNumber = reader.GetString(2),
			WorkplaceAddress = reader.GetString(3),
			SupervisorId = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4),
			SupervisorName = await reader.IsDBNullAsync(5) ? null : reader.GetString(5),
			WorkplaceType = await reader.GetFieldValueAsync<WorkplaceType>(6),
		};

		return data;
	}
	public static async Task<WarehouseView> SelectWarehouseView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"supervisor_name",
				"warehouse_volume"
			FROM "public"."warehouse_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new WarehouseView {
			Id = reader.GetInt32(0),
			WorkplaceName = reader.GetString(1),
			WorkplaceTelephoneNumber = reader.GetString(2),
			WorkplaceAddress = reader.GetString(3),
			SupervisorId = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4),
			SupervisorName = await reader.IsDBNullAsync(5) ? null : reader.GetString(5),
			WarehouseVolume = reader.GetInt64(6),
		};

		return data;
	}
	public static async Task<OfficeView> SelectOfficeView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"supervisor_name",
				"floor_count",
				"floor_size"
			FROM "public"."office_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new OfficeView {
			Id = reader.GetInt32(0),
			WorkplaceName = reader.GetString(1),
			WorkplaceTelephoneNumber = reader.GetString(2),
			WorkplaceAddress = reader.GetString(3),
			SupervisorId = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4),
			SupervisorName = await reader.IsDBNullAsync(5) ? null : reader.GetString(5),
			FloorCount = reader.GetInt64(6),
			FloorSize = reader.GetInt64(7),
		};

		return data;
	}

	public static async Task<Workplace> SelectWorkplace(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"workplace_type"
			FROM "public"."workplace_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Workplace {
			Id = reader.GetInt32(0),
			WorkplaceName = reader.GetString(1),
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			Supervisor = await reader.IsDBNullAsync(4) ? null : await DatabaseApi.SelectEmployeeView(reader.GetInt32(4)),
			WorkplaceType = await reader.GetFieldValueAsync<WorkplaceType>(5)
		};

		return data;
	}
	public static async Task<Warehouse> SelectWarehouse(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"warehouse_volume"
			FROM "public"."warehouse_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Warehouse {
			Id = reader.GetInt32(0),
			WorkplaceName = reader.GetString(1),
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			Supervisor = await reader.IsDBNullAsync(4) ? null : await DatabaseApi.SelectEmployeeView(reader.GetInt32(4)),
			WarehouseVolume = reader.GetInt64(5),
			WorkplaceType = WorkplaceType.Warehouse,
		};

		return data;
	}
	public static async Task<Office> SelectOffice(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"workplace_name",
				"workplace_telephone_number",
				"workplace_address",
				"supervisor_id",
				"floor_count",
				"floor_size"
			FROM "public"."office_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Office {
			Id = reader.GetInt32(0),
			WorkplaceName = reader.GetString(1),
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			Supervisor = await reader.IsDBNullAsync(4) ? null : await DatabaseApi.SelectEmployeeView(reader.GetInt32(4)),
			FloorCount = reader.GetInt64(5),
			FloorSize = reader.GetInt64(6),
			WorkplaceType = WorkplaceType.Warehouse,
		};

		return data;
	}

	public static async Task InsertWarehouse(Warehouse data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			CALL "public"."insert_warehouse"(@workplace_name, @telephone_number, @address, @warehouse_volume)
			""");
		command.Parameters.Add(new NpgsqlParameter<string>("workplace_name", data.WorkplaceName));
		command.Parameters.Add(new NpgsqlParameter<string>("telephone_number", data.TelephoneNumber));
		command.Parameters.Add(new NpgsqlParameter<string>("address", data.Address));
		command.Parameters.Add(new NpgsqlParameter<long>("warehouse_volume", data.WarehouseVolume));
		command.ExecuteNonQuery();
	}
	public static async Task InsertOffice(Office data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			CALL "public"."insert_office"(@entity_name, @telephone_number, @address, @floor_count, @floor_size)
			""");
		command.Parameters.Add(new NpgsqlParameter<string>("workplace_name", data.WorkplaceName));
		command.Parameters.Add(new NpgsqlParameter<string>("telephone_number", data.TelephoneNumber));
		command.Parameters.Add(new NpgsqlParameter<string>("address", data.Address));
		command.Parameters.Add(new NpgsqlParameter<long>("national_id", data.FloorCount));
		command.Parameters.Add(new NpgsqlParameter<long>("national_id", data.FloorSize));
		command.ExecuteNonQuery();
	}

	public static async Task UpdateCompany(Company data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			CALL "public"."update_warehouse"(@entity_id ,@entity_name, @telephone_number, @address, @mersis_id)
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("entity_id", data.Id));
		command.Parameters.Add(new NpgsqlParameter<string>("entity_name", data.EntityName));
		command.Parameters.Add(new NpgsqlParameter<string>("telephone_number", data.TelephoneNumber));
		command.Parameters.Add(new NpgsqlParameter<string>("address", data.Address));
		command.Parameters.Add(new NpgsqlParameter<string>("mersis_id", data.MersisId));
		command.ExecuteNonQuery();
	}
	public static async Task UpdateOffice(Person data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			CALL "public"."update_office"(@entity_id, @entity_name, @telephone_number, @address, @national_id)
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("entity_id", data.Id));
		command.Parameters.Add(new NpgsqlParameter<string>("entity_name", data.EntityName));
		command.Parameters.Add(new NpgsqlParameter<string>("telephone_number", data.TelephoneNumber));
		command.Parameters.Add(new NpgsqlParameter<string>("address", data.Address));
		command.Parameters.Add(new NpgsqlParameter<string>("national_id", data.NationalId));
		command.ExecuteNonQuery();
	}

	public static async Task DeleteWorkplaceBulk(List<int> list) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			DELETE FROM "public"."workplace" WHERE "id" = ANY(@list)
			""");
		command.Parameters.Add(new NpgsqlParameter<List<int>>("list", list));
		command.ExecuteNonQuery();
	}
}

public enum WorkplaceType : int {
	Undefined = -1,
	[PgName("warehouse")] Warehouse = 0,
	[PgName("office")] Office = 1,
}

public record WorkplaceView {
	[DisplayName("İşyeri No")] public required int Id { get; set; }
	[DisplayName("İşyeri Adı")] public required string WorkplaceName { get; set; }
	[DisplayName("İşyeri Telefon Numarası")] public required string WorkplaceTelephoneNumber { get; set; }
	[DisplayName("İşyeri Adresi")] public required string WorkplaceAddress { get; set; }
	[DisplayName("Yönetici No")] public required int? SupervisorId { get; set; }
	[DisplayName("Yönetici Adı")] public required string? SupervisorName { get; set; }
	[Browsable(false)] public required WorkplaceType WorkplaceType { get; set; }
	[DisplayName("İşyeri Tipi")] public string WorkplaceTypeString => this.WorkplaceType switch {
		WorkplaceType.Warehouse => "Depo",
		WorkplaceType.Office => "Ofis",
		_ => throw new InvalidEnumArgumentException(),
	};
}
public record Workplace {
	public required int Id { get; set; }
	public required string WorkplaceName { get; set; }
	public required string TelephoneNumber { get; set; }
	public required string Address { get; set; }
	public required EmployeeView? Supervisor { get; set; }
	public required WorkplaceType WorkplaceType { get; set; }
}

public record WarehouseView {
	[DisplayName("Depo No")] public required int Id { get; set; }
	[DisplayName("Depo Adı")] public required string WorkplaceName { get; set; }
	[DisplayName("Depo Telefon Numarası")] public required string WorkplaceTelephoneNumber { get; set; }
	[DisplayName("Depo Adresi")] public required string WorkplaceAddress { get; set; }
	[DisplayName("Yönetici No")] public required int? SupervisorId { get; set; }
	[DisplayName("Yönetici Adı")] public required string? SupervisorName { get; set; }
	[DisplayName("Depo Hacmi (m3)")] public required long WarehouseVolume { get; set; }
}
public record Warehouse : Workplace {
	public required long WarehouseVolume { get; set; }
}

public record OfficeView {
	[DisplayName("Ofis No")] public required int Id { get; set; }
	[DisplayName("Ofis Adı")] public required string WorkplaceName { get; set; }
	[DisplayName("Ofis Telefon Numarası")] public required string WorkplaceTelephoneNumber { get; set; }
	[DisplayName("Ofis Adresi")] public required string WorkplaceAddress { get; set; }
	[DisplayName("Yönetici No")] public required int? SupervisorId { get; set; }
	[DisplayName("Yönetici Adı")] public required string? SupervisorName { get; set; }
	[DisplayName("Kat Sayısı")] public required long FloorCount { get; set; }
	[DisplayName("Kullanım Alanı (m2)")] public required long FloorSize { get; set; }
}
public record Office : Workplace {
	public required long FloorCount { get; set; }
	public required long FloorSize { get; set; }
}