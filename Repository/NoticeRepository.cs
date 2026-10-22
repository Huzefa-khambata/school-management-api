using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class NoticeRepository
    {
        public IDatabaseManager manager;

        public NoticeRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<NoticeBO> GetNoticeList()
        {
            List<NoticeBO> list = new List<NoticeBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(CommandType.StoredProcedure, "s_notice_list"))
                {
                    while (reader.Read())
                    {
                        NoticeBO notice = new NoticeBO
                        {
                            NoticeId = reader["noticeid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["noticeid"]),
                            NoticeTitle = reader["noticetitle"] == DBNull.Value ? string.Empty : reader["noticetitle"].ToString(),
                            NoticeDescription = reader["noticedescription"] == DBNull.Value ? string.Empty : reader["noticedescription"].ToString(),
                            NoticeCategory = reader["noticecategory"] == DBNull.Value ? string.Empty : reader["noticecategory"].ToString(),
                            PublishDate = reader["publishdate"] == DBNull.Value ? null : ((DateOnly)reader["publishdate"]).ToDateTime(TimeOnly.MinValue),
                            ExpiryDate = reader["expirydate"] == DBNull.Value ? null : ((DateOnly)reader["expirydate"]).ToDateTime(TimeOnly.MinValue),
                            TargetAudience = reader["targetaudience"] == DBNull.Value ? string.Empty : reader["targetaudience"].ToString(),
                            Status = reader["status"] == DBNull.Value ? string.Empty : reader["status"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(notice);
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