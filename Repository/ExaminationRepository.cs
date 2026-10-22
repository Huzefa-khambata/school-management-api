using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class ExaminationRepository
    {
        public IDatabaseManager manager;

        public ExaminationRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<ExaminationBO> GetExaminationList()
        {
            List<ExaminationBO> list = new List<ExaminationBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(CommandType.StoredProcedure, "s_examination_list"))
                {
                    while (reader.Read())
                    {
                        ExaminationBO examination = new ExaminationBO
                        {
                            ExaminationId = reader["examinationid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["examinationid"]),
                            ExamCode = reader["examcode"] == DBNull.Value ? string.Empty : reader["examcode"].ToString(),
                            ExamName = reader["examname"] == DBNull.Value ? string.Empty : reader["examname"].ToString(),
                            ExamType = reader["examtype"] == DBNull.Value ? string.Empty : reader["examtype"].ToString(),
                            ClassName = reader["classname"] == DBNull.Value ? string.Empty : reader["classname"].ToString(),
                            StartDate = reader["startdate"] == DBNull.Value ? null : ((DateOnly)reader["startdate"]).ToDateTime(TimeOnly.MinValue),
                            EndDate = reader["enddate"] == DBNull.Value ? null : ((DateOnly)reader["enddate"]).ToDateTime(TimeOnly.MinValue),
                            MaxMarks = reader["maxmarks"] == DBNull.Value ? null : Convert.ToInt32(reader["maxmarks"]),
                            Status = reader["status"] == DBNull.Value ? string.Empty : reader["status"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(examination);
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