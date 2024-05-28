namespace EsportsProfileWebApi.INFRASTRUCTURE;

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using EsportsProfileWebApi.Web.Orchestrators.Models;
using EsportsProfileWebApi.Web.Repository.Entities.Data;
using Dapper;
using System.Data;

public class DataRepository(IConfiguration configuration) : IDataRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();

    public async Task<UpdateDataResponseModel> UpdateData(UpdateDataRequestModel request)
    {
        if (request == null)
            return new UpdateDataResponseModel{ IsSuccessful = false};

        using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("p_user_id",request.Id, dbType: DbType.String);
        parameters.Add("p_first_name", request.FirstName, dbType: DbType.String);
        parameters.Add("p_last_name", request.LastName, dbType: DbType.String);
        parameters.Add("p_mouse", request.Mouse, dbType: DbType.String);
        parameters.Add("p_mouse_pad", request.MousePad, dbType: DbType.String);
        parameters.Add("p_head_set", request.HeadSet, dbType: DbType.String);
        parameters.Add("p_monitor", request.Monitor, dbType: DbType.String);
        parameters.Add("p_key_board", request.KeyBoard ,dbType: DbType.String);

        await connection.ExecuteAsync("UpdateUserDataById", parameters, commandType: CommandType.StoredProcedure);

        return new UpdateDataResponseModel { IsSuccessful = true };
    }

    public async Task<DataEntity> GetUserData(GetDataRequestModel request)
    {
        using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("p_user_name", request.Username, dbType: DbType.String);
        parameters.Add("user_name", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("email", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("first_name", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("last_name", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("mouse", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("mouse_pad", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("head_set", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("monitor", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("key_board", dbType: DbType.String, direction: ParameterDirection.Output);

        await connection.ExecuteAsync("getuserdatabyusername", parameters, commandType: CommandType.StoredProcedure);

        string email = parameters.Get<string>("email");
        string user_name = parameters.Get<string>("user_name");
        string first_name = parameters.Get<string>("first_name");
        string last_name = parameters.Get<string>("last_name");
        string mouse = parameters.Get<string>("mouse");
        string mouse_pad = parameters.Get<string>("mouse_pad");
        string head_set = parameters.Get<string>("head_set");
        string monitor = parameters.Get<string>("monitor");
        string key_board = parameters.Get<string>("key_board");

        return new DataEntity{
            Email = email ?? request.Username,
            UserName = user_name,
            FirstName = first_name,
            LastName = last_name,
            Mouse = mouse,
            MousePad = mouse_pad,
            HeadSet = head_set,
            Monitor = monitor,
            KeyBoard = key_board
        };
    }

    public async Task<DataEntity> GetProfileData(GetProfileRequestModel request)
    {
        using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        DynamicParameters parameters = new ();
        parameters.Add("p_user_id",request.Id, dbType: DbType.String);
        parameters.Add("user_name", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("email", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("first_name", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("last_name", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("mouse", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("mouse_pad", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("head_set", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("monitor", dbType: DbType.String, direction: ParameterDirection.Output);
        parameters.Add("key_board", dbType: DbType.String, direction: ParameterDirection.Output);

        await connection.ExecuteAsync("GetUserDataById", parameters, commandType: CommandType.StoredProcedure);

        string email = parameters.Get<string>("email");
        string user_name = parameters.Get<string>("user_name");
        string first_name = parameters.Get<string>("first_name");
        string last_name = parameters.Get<string>("last_name");
        string mouse = parameters.Get<string>("mouse");
        string mouse_pad = parameters.Get<string>("mouse_pad");
        string head_set = parameters.Get<string>("head_set");
        string monitor = parameters.Get<string>("monitor");
        string key_board = parameters.Get<string>("key_board");

        return new DataEntity{
            Email = email,
            UserName = user_name,
            FirstName = first_name,
            LastName = last_name,
            Mouse = mouse,
            MousePad = mouse_pad,
            HeadSet = head_set,
            Monitor = monitor,
            KeyBoard = key_board
        };
    }

    public async Task<List<DataEntity>> GetAllDataAsync()
    {
        return [];
    }
}
