using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class SubjectRepository
    {
        public IDatabaseManager manager;

        public SubjectRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<SubjectBO> GetSubjectList()
        {
            List<SubjectBO> list = new List<SubjectBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(CommandType.StoredProcedure, "s_subject_list"))
                {
                    while (reader.Read())
                    {
                        SubjectBO subject = new SubjectBO
                        {
                            SubjectId = reader["subjectid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["subjectid"]),
                            SubjectCode = reader["subjectcode"] == DBNull.Value ? string.Empty : reader["subjectcode"].ToString(),
                            SubjectName = reader["subjectname"] == DBNull.Value ? string.Empty : reader["subjectname"].ToString(),
                            AssignedTeacher = reader["assignedteacher"] == DBNull.Value ? string.Empty : reader["assignedteacher"].ToString(),
                            ClassName = reader["classname"] == DBNull.Value ? string.Empty : reader["classname"].ToString(),
                            SectionName = reader["sectionname"] == DBNull.Value ? string.Empty : reader["sectionname"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(subject);
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