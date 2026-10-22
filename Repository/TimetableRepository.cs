using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class TimetableRepository
    {
        public IDatabaseManager manager;

        public TimetableRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<TimetableBO> GetTimetableList()
        {
            List<TimetableBO> list = new List<TimetableBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(CommandType.StoredProcedure, "s_timetable_list"))
                {
                    while (reader.Read())
                    {
                        TimetableBO timetable = new TimetableBO
                        {
                            TimetableId = reader["timetableid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["timetableid"]),
                            ClassName = reader["classname"] == DBNull.Value ? string.Empty : reader["classname"].ToString(),
                            SectionName = reader["sectionname"] == DBNull.Value ? string.Empty : reader["sectionname"].ToString(),
                            Day = reader["day"] == DBNull.Value ? string.Empty : reader["day"].ToString(),
                            Period = reader["period"] == DBNull.Value ? null : Convert.ToInt32(reader["period"]),
                            StartTime = reader["starttime"] == DBNull.Value ? null : (TimeSpan)reader["starttime"],
                            EndTime = reader["endtime"] == DBNull.Value ? null : (TimeSpan)reader["endtime"],
                            SubjectName = reader["subjectname"] == DBNull.Value ? string.Empty : reader["subjectname"].ToString(),
                            TeacherName = reader["teachername"] == DBNull.Value ? string.Empty : reader["teachername"].ToString(),
                            RoomNumber = reader["roomnumber"] == DBNull.Value ? string.Empty : reader["roomnumber"].ToString(),
                            TeacherId = reader["teacherid"] == DBNull.Value ? null : Convert.ToInt32(reader["teacherid"]),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(timetable);
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