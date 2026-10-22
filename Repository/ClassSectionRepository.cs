using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class ClassSectionRepository
    {
        public IDatabaseManager manager;

        public ClassSectionRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<ClassSectionBO> GetClassSectionList()
        {
            List<ClassSectionBO> list = new List<ClassSectionBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(CommandType.StoredProcedure, "s_class_section_list"))
                {
                    while (reader.Read())
                    {
                        ClassSectionBO classSection = new ClassSectionBO
                        {
                            ClassSectionId = reader["classsectionid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["classsectionid"]),
                            ClassCode = reader["classcode"] == DBNull.Value ? string.Empty : reader["classcode"].ToString(),
                            ClassName = reader["classname"] == DBNull.Value ? string.Empty : reader["classname"].ToString(),
                            SectionName = reader["sectionname"] == DBNull.Value ? string.Empty : reader["sectionname"].ToString(),
                            Strength = reader["strength"] == DBNull.Value ? null : Convert.ToInt32(reader["strength"]),
                            ClassTeacher = reader["classteacher"] == DBNull.Value ? string.Empty : reader["classteacher"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(classSection);
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