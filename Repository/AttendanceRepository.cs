using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class AttendanceRepository
    {
        public IDatabaseManager manager;

        public AttendanceRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<AttendanceBO> GetAttendanceList()
        {
            List<AttendanceBO> list = new List<AttendanceBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(CommandType.StoredProcedure, "s_attendance_list"))
                {
                    while (reader.Read())
                    {
                        AttendanceBO attendance = new AttendanceBO
                        {
                            AttendanceId = reader["attendanceid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["attendanceid"]),
                            StudentId = reader["studentid"] == DBNull.Value ? null : Convert.ToInt32(reader["studentid"]),
                            AdmissionNumber = reader["admissionnumber"] == DBNull.Value ? string.Empty : reader["admissionnumber"].ToString(),
                            ClassName = reader["classname"] == DBNull.Value ? string.Empty : reader["classname"].ToString(),
                            SectionName = reader["sectionname"] == DBNull.Value ? string.Empty : reader["sectionname"].ToString(),
                            AttendanceDate = reader["attendancedate"] == DBNull.Value ? null : ((DateOnly)reader["attendancedate"]).ToDateTime(TimeOnly.MinValue),
                            AttendanceStatus = reader["attendancestatus"] == DBNull.Value ? string.Empty : reader["attendancestatus"].ToString(),
                            Remarks = reader["remarks"] == DBNull.Value ? string.Empty : reader["remarks"].ToString(),
                            TeacherId = reader["teacherid"] == DBNull.Value ? null : Convert.ToInt32(reader["teacherid"]),
                            TeacherName = reader["teachername"] == DBNull.Value ? string.Empty : reader["teachername"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(attendance);
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