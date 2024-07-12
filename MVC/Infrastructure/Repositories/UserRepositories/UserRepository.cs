using MVC.Domain.DTOs;
using MVC.Domain.Entities;
using System.Data.SqlClient;
using System.Data;
namespace MVC.Infrastructure.Repositories.UserRepositories;
public class UserRepository(IConfiguration conf) : IUserRepository
{
    private readonly SqlAdoModel _ado = new();
    public async Task<bool> AddUser(User user)
    {
        _ado.SqlQuery = "insert into Users(user_id,user_name,hash_password,role) " +
                     "Values (@user_id,@user_name,@hash_password,@role);";
        _ado.ConString = conf.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() =>
            {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Connection.Open();
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@user_id", user.UserId);
                    _ado.Command.Parameters.AddWithValue("@user_name", user.UserName);
                    _ado.Command.Parameters.AddWithValue("@hash_password", user.HashPassword);
                    _ado.Command.Parameters.AddWithValue("@role", user.Role);

                    int i = _ado.Command.ExecuteNonQuery();
                    _ado.Connection.Close();
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteUser(string userId)
    {
        _ado.SqlQuery = "delete from Users where user_id = @user_id;";
        _ado.ConString = conf.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() =>
            {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Connection.Open();
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@user_id", userId);

                    int i = _ado.Command.ExecuteNonQuery();
                    _ado.Connection.Close();
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<User> GetUserById(string userId)
    {
        User user = null!;
        _ado.SqlQuery = "select * from Users where user_id = @user_id;";
        _ado.ConString = conf.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() => {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Connection.Open();
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@user_id", userId);

                    _ado.DataReader = _ado.Command.ExecuteReader();
                    while (_ado.DataReader.Read())
                    {
                        user = new User()
                        {
                            UserId = (string)_ado.DataReader["user_id"],
                            UserName = (string)_ado.DataReader["user_name"],
                            HashPassword = (string)_ado.DataReader["hash_password"],
                            Role = (string)_ado.DataReader["role"],
                        };
                    }
                    _ado.Connection.Close();
                }
                return user;
            });
        }
        catch (Exception)
        {
            return user;
        }
    }

    public async Task<User> GetUserByUserName(string userName)
    {
        User user = null!;
        _ado.SqlQuery = "select * from Users where user_name = @user_name;";
        _ado.ConString = conf.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() => {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Connection.Open();
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@user_name", userName);

                    _ado.DataReader = _ado.Command.ExecuteReader();
                    while (_ado.DataReader.Read())
                    {
                        user = new User()
                        {
                            UserId = (string)_ado.DataReader["user_id"],
                            UserName = (string)_ado.DataReader["user_name"],
                            HashPassword = (string)_ado.DataReader["hash_password"],
                            Role = (string)_ado.DataReader["role"]
                        };
                    }
                    _ado.Connection.Close();
                }
                return user;
            });
        }
        catch (Exception)
        {
            return user;
        }
    }

    public async Task<List<User>> GetUsers(string userName)
    {
        List<User> users = null!;
        _ado.SqlQuery = "select * from Users;";
        _ado.ConString = conf.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() => {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Connection.Open();
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;

                    _ado.DataReader = _ado.Command.ExecuteReader();
                    while (_ado.DataReader.Read())
                    {
                        User user = new()
                        {
                            UserId = (string)_ado.DataReader["user_id"],
                            UserName = (string)_ado.DataReader["user_name"],
                            HashPassword = (string)_ado.DataReader["hash_password"],
                            Role = (string)_ado.DataReader["role"]
                        };
                        users.Add(user);
                    }
                    _ado.Connection.Close();
                }
                return users;
            });
        }
        catch (Exception)
        {
            return users;
        }
    }

    public async Task<bool> UpdateUser(User user)
    {
        _ado.SqlQuery = "update Users set user_name = @user_name,hash_password = @hash_password," +
                        "where user_id = @user_id;";
        _ado.ConString = conf.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() =>
            {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Connection.Open();
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@user_name", user.UserName);
                    _ado.Command.Parameters.AddWithValue("@user_id", user.UserId);

                    int i = _ado.Command.ExecuteNonQuery();
                    _ado.Connection.Close();
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }
}