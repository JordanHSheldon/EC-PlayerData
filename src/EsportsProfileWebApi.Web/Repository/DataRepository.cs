namespace EsportsProfileWebApi.Web.Repository;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Orchestrators.Models.Data;
using Entities.Data;
using Dapper;
using System.Data;

public class DataRepository(IConfiguration configuration) : IDataRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();

    private const string PeripheralsSQL = $"SELECT [picklist_peripheral_id], [picklist_peripheral_type],[picklist_peripheral_name] ,[picklist_peripheral_url] FROM [dbo].[picklist_peripherals]";
    
    public async Task<UpdateDataResponseModel> UpdateData(UpdateDataRequestModel request)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("p_user_id",request.Id, dbType: DbType.String);
        parameters.Add("p_mouse", request.Mouse, dbType: DbType.String);
        parameters.Add("p_mouse_pad", request.MousePad, dbType: DbType.String);
        parameters.Add("p_head_set", request.HeadSet, dbType: DbType.String);
        parameters.Add("p_monitor", request.Monitor, dbType: DbType.String);
        parameters.Add("p_key_board", request.KeyBoard ,dbType: DbType.String);

        await connection.ExecuteAsync("UpdateUserDataById", parameters, commandType: CommandType.StoredProcedure);
        
        await connection.CloseAsync();
        return new UpdateDataResponseModel { IsSuccessful = true };
    }

    public async Task<DataEntity> GetUserData(GetDataRequestModel request)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("p_id", request.Id, dbType: DbType.Int16);

        var userProfil = await connection.ExecuteAsync("get_user_profile", parameters, commandType: CommandType.StoredProcedure);

        await connection.CloseAsync();

        var userName = parameters.Get<string>("user_name");
        var mouse = parameters.Get<string>("mouse");
        var mousePad = parameters.Get<string>("mouse_pad");
        var headSet = parameters.Get<string>("head_set");
        var monitor = parameters.Get<string>("monitor");
        var keyboard = parameters.Get<string>("key_board");

        return new DataEntity{
            UserName = userName,
            Mouse = mouse,
            MousePad = mousePad,
            HeadSet = headSet,
            Monitor = monitor,
            KeyBoard = keyboard
        };
    }
    
    public async Task<DataEntity> GetProfileData(GetProfileRequestModel request)
    {
        await using var connection = new SqlConnection(_connectionString);
        
        DynamicParameters parameters = new ();
        parameters.Add("@user_id", request.Id, dbType: DbType.Int16);
        
        await connection.OpenAsync();

        var userProfile = await connection.QueryAsync<DataEntity>("get_user_peripherals", parameters, commandType: CommandType.StoredProcedure);

        await connection.CloseAsync();

        return userProfile.FirstOrDefault() ?? new DataEntity();
    }

    public async Task<List<DataEntity>> GetPaginatedUsersAsync(GetPaginatedUsersRequestModel req)
    {
        await using var connection = new SqlConnection(_connectionString);
        
        await connection.OpenAsync();

        var sql = $"[dbo].[get_paginated_users]";
        
        var users = await connection.QueryAsync<DataEntity>(sql);

        await connection.CloseAsync();
        
        return users.ToList();
    }

    public async Task<List<PeripheralEntity>> GetPeripheralsAsync()
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        
        var users = await connection.QueryAsync<PeripheralEntity>("get_peripherals", commandType: CommandType.StoredProcedure);

        await connection.CloseAsync();
        return users.ToList();
    }

    public async Task<UpdateDataResponseModel> UpdateUserPeripherals(UpdateUserPeripheralsRequest request)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var table = new DataTable();
        table.Columns.Add("peripheral_user_id", typeof(int));
        table.Columns.Add("picklist_peripheral_id", typeof(int));

        foreach (var peripheralId in request.PeripheralIds)
        {
            table.Rows.Add(request.UserId, peripheralId);
        }
        await connection.ExecuteAsync("update_user_peripherals", 
            new { newPeripherals = table.AsTableValuedParameter("dbo.InsertPeripheralsType") }, 
            commandType: CommandType.StoredProcedure);
        
        await connection.CloseAsync();
        return new UpdateDataResponseModel { IsSuccessful = true };
    }

    
    
}
