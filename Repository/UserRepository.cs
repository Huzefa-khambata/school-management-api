using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class UserRepository
    {
        public IDatabaseManager manager;

        public UserRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<UserBO> GetUserList()
        {
            List<UserBO> list = new List<UserBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(CommandType.StoredProcedure, "s_user_list"))
                {
                    while (reader.Read())
                    {
                        UserBO user = new UserBO
                        {
                            UserId = reader["userid"] == DBNull.Value ? string.Empty : reader["userid"].ToString(),
                            EmployeeId = reader["employeeid"] == DBNull.Value ? string.Empty : reader["employeeid"].ToString(),
                            Name = reader["name"] == DBNull.Value ? string.Empty : reader["name"].ToString(),
                            Email = reader["email"] == DBNull.Value ? string.Empty : reader["email"].ToString(),
                            RoleId = reader["roleid"] == DBNull.Value ? null : Convert.ToInt32(reader["roleid"]),
                            RoleName = reader["rolename"] == DBNull.Value ? string.Empty : reader["rolename"].ToString(),
                            LastLogin = reader["lastlogin"] == DBNull.Value ? null : Convert.ToDateTime(reader["lastlogin"]),
                            Status = reader["status"] == DBNull.Value ? string.Empty : reader["status"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(user);
                    }
                }

                return list;
            }
            catch (Exception exception)
            {
                throw new ApplicationException(
                    $"Exception in {this.GetType().Name} - {exception.Message}",
                    exception);
            }
            finally
            {
                manager.CloseConnection();
            }
        }

        public bool AddUser(AddUserBO user)
        {
            try
            {
                int roleId = user.Role switch
                {
                    "Admin" => 1,
                    "HOD" => 2,
                    "Teacher" => 3,
                    _ => throw new ArgumentException("Invalid role selected.")
                };

                manager.CreateParameters(6);

                manager.AddParameter("userid", user.UserId);
                manager.AddParameter("password", BCrypt.Net.BCrypt.HashPassword(user.Password));
                manager.AddParameter("employeeid", user.EmployeeId);
                manager.AddParameter("roleid", roleId);
                manager.AddParameter("createdby", user.CreatedBy);
                manager.AddParameter("lmodby", user.CreatedBy);

                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(
                    CommandType.Text,
                    @"INSERT INTO public.t_user
              (userid, password, employeeid, roleid, status,
               createdby, createdon, lmodby, lmodon, isactive)
              VALUES
              (@userid, @password, @employeeid, @roleid, 'Active',
               @createdby, CURRENT_TIMESTAMP, @lmodby, CURRENT_TIMESTAMP, 1)
              RETURNING userid"))
                {
                    return reader.Read();
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException(
                    $"Exception in {GetType().Name} - {exception.Message}",
                    exception);
            }
            finally
            {
                manager.CloseConnection();
            }
        }

    }
}