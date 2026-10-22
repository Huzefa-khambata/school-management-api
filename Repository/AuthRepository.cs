
using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Data;

namespace HSMS.API.Repository
{
    public class AuthRepository
    {
        public IDatabaseManager manager;

        public AuthRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public AuthUserBO? GetUserForLogin(string userId)
        {
            try
            {
                manager.CreateParameters(1);

                manager.AddParameter("userid", userId);

                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(
                    CommandType.Text,
                    @"SELECT userid, password, roleid, status, isactive
                      FROM public.t_user
                      WHERE userid = @userid
                      LIMIT 1"))
                {
                    if (reader.Read())
                    {
                        return new AuthUserBO
                        {
                            UserId = reader["userid"] == DBNull.Value
                                ? string.Empty
                                : reader["userid"].ToString()!,

                            PasswordHash = reader["password"] == DBNull.Value
                                ? string.Empty
                                : reader["password"].ToString()!,

                            RoleId = reader["roleid"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["roleid"]),

                            Status = reader["status"] == DBNull.Value
                                ? string.Empty
                                : reader["status"].ToString(),

                            IsActive = reader["isactive"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["isactive"])
                        };
                    }
                }

                return null;
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
