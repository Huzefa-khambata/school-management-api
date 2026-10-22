using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class TeacherRepository
    {
        public IDatabaseManager manager;

        public TeacherRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<TeacherBO> GetTeacherList()
        {
            List<TeacherBO> list = new List<TeacherBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(CommandType.StoredProcedure, "s_teacher_list"))
                {
                    while (reader.Read())
                    {
                        TeacherBO teacher = new TeacherBO
                        {
                            TeacherId = reader["teacherid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["teacherid"]),
                            UserId = reader["userid"] == DBNull.Value ? string.Empty : reader["userid"].ToString(),
                            Password = reader["password"] == DBNull.Value ? string.Empty : reader["password"].ToString(),
                            TeacherName = reader["teachername"] == DBNull.Value ? string.Empty : reader["teachername"].ToString(),
                            Mobile = reader["mobile"] == DBNull.Value ? string.Empty : reader["mobile"].ToString(),
                            Email = reader["email"] == DBNull.Value ? string.Empty : reader["email"].ToString(),
                            EmployeeId = reader["employeeid"] == DBNull.Value ? string.Empty : reader["employeeid"].ToString(),
                            Qualification = reader["qualification"] == DBNull.Value ? string.Empty : reader["qualification"].ToString(),
                            Department = reader["department"] == DBNull.Value ? string.Empty : reader["department"].ToString(),
                            Status = reader["status"] == DBNull.Value ? string.Empty : reader["status"].ToString(),
                            Subject = reader["subject"] == DBNull.Value ? string.Empty : reader["subject"].ToString(),
                            AssignedClasses = reader["assignedclasses"] == DBNull.Value ? string.Empty : reader["assignedclasses"].ToString(),
                            Experience = reader["experience"] == DBNull.Value ? string.Empty : reader["experience"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(teacher);
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
    }
}