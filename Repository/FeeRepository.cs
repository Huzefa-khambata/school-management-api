using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class FeeRepository
    {
        public IDatabaseManager manager;

        public FeeRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        // =========================================================
        // FEE STRUCTURE
        // =========================================================

        public List<FeeStructureBO> GetFeeStructureList()
        {
            List<FeeStructureBO> list = new List<FeeStructureBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(
                    CommandType.StoredProcedure,
                    "s_fee_structure_list"))
                {
                    while (reader.Read())
                    {
                        FeeStructureBO fee = new FeeStructureBO
                        {
                            FeeStructureId = reader["feestructureid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["feestructureid"]),
                            AcademicYear = reader["academicyear"] == DBNull.Value ? string.Empty : reader["academicyear"].ToString(),
                            ClassName = reader["classname"] == DBNull.Value ? string.Empty : reader["classname"].ToString(),
                            SectionName = reader["sectionname"] == DBNull.Value ? string.Empty : reader["sectionname"].ToString(),
                            FeeHead = reader["feehead"] == DBNull.Value ? string.Empty : reader["feehead"].ToString(),
                            Amount = reader["amount"] == DBNull.Value ? null : Convert.ToInt32(reader["amount"]),
                            DueDate = reader["duedate"] == DBNull.Value ? null : ((DateOnly)reader["duedate"]).ToDateTime(TimeOnly.MinValue),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(fee);
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

        // =========================================================
        // FEE
        // =========================================================

        public List<FeeBO> GetFeeList()
        {
            List<FeeBO> list = new List<FeeBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(
                    CommandType.StoredProcedure,
                    "s_fee_list"))
                {
                    while (reader.Read())
                    {
                        FeeBO fee = new FeeBO
                        {
                            FeeId = reader["feeid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["feeid"]),
                            StudentId = reader["studentid"] == DBNull.Value ? null : Convert.ToInt32(reader["studentid"]),
                            AdmissionNumber = reader["admissionnumber"] == DBNull.Value ? string.Empty : reader["admissionnumber"].ToString(),
                            StudentName = reader["studentname"] == DBNull.Value ? string.Empty : reader["studentname"].ToString(),
                            ClassName = reader["classname"] == DBNull.Value ? string.Empty : reader["classname"].ToString(),
                            SectionName = reader["sectionname"] == DBNull.Value ? string.Empty : reader["sectionname"].ToString(),
                            TotalFee = reader["totalfee"] == DBNull.Value ? null : Convert.ToInt32(reader["totalfee"]),
                            Paid = reader["paid"] == DBNull.Value ? null : Convert.ToInt32(reader["paid"]),
                            LateFee = reader["latefee"] == DBNull.Value ? null : Convert.ToInt32(reader["latefee"]),
                            Balance = reader["balance"] == DBNull.Value ? null : Convert.ToInt32(reader["balance"]),
                            DueDate = reader["duedate"] == DBNull.Value ? null : ((DateOnly)reader["duedate"]).ToDateTime(TimeOnly.MinValue),
                            Status = reader["status"] == DBNull.Value ? string.Empty : reader["status"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(fee);
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

        // =========================================================
        // FEE PAYMENT
        // =========================================================

        public List<FeePaymentBO> GetFeePaymentList()
        {
            List<FeePaymentBO> list = new List<FeePaymentBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(
                    CommandType.StoredProcedure,
                    "s_fee_payment_list"))
                {
                    while (reader.Read())
                    {
                        FeePaymentBO payment = new FeePaymentBO
                        {
                            FeePaymentId = reader["feepaymentid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["feepaymentid"]),
                            FeeId = reader["feeid"] == DBNull.Value ? null : Convert.ToInt32(reader["feeid"]),
                            StudentId = reader["studentid"] == DBNull.Value ? null : Convert.ToInt32(reader["studentid"]),
                            AdmissionNumber = reader["admissionnumber"] == DBNull.Value ? string.Empty : reader["admissionnumber"].ToString(),
                            StudentName = reader["studentname"] == DBNull.Value ? string.Empty : reader["studentname"].ToString(),
                            FeeHead = reader["feehead"] == DBNull.Value ? string.Empty : reader["feehead"].ToString(),
                            Amount = reader["amount"] == DBNull.Value ? null : Convert.ToInt32(reader["amount"]),
                            PaymentDate = reader["paymentdate"] == DBNull.Value ? null : ((DateOnly)reader["paymentdate"]).ToDateTime(TimeOnly.MinValue),
                            PaymentMode = reader["paymentmode"] == DBNull.Value ? string.Empty : reader["paymentmode"].ToString(),
                            TransactionNumber = reader["transactionnumber"] == DBNull.Value ? string.Empty : reader["transactionnumber"].ToString(),
                            Remarks = reader["remarks"] == DBNull.Value ? string.Empty : reader["remarks"].ToString(),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(payment);
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

        // =========================================================
        // FEE RECEIPT
        // =========================================================

        public List<FeeReceiptBO> GetFeeReceiptList()
        {
            List<FeeReceiptBO> list = new List<FeeReceiptBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(
                    CommandType.StoredProcedure,
                    "s_fee_receipt_list"))
                {
                    while (reader.Read())
                    {
                        FeeReceiptBO receipt = new FeeReceiptBO
                        {
                            FeeReceiptId = reader["feereceiptid"] == DBNull.Value ? 0 : Convert.ToInt32(reader["feereceiptid"]),
                            ReceiptNumber = reader["receiptnumber"] == DBNull.Value ? string.Empty : reader["receiptnumber"].ToString(),
                            StudentName = reader["studentname"] == DBNull.Value ? string.Empty : reader["studentname"].ToString(),
                            ClassName = reader["classname"] == DBNull.Value ? string.Empty : reader["classname"].ToString(),
                            SectionName = reader["sectionname"] == DBNull.Value ? string.Empty : reader["sectionname"].ToString(),
                            FeeHead = reader["feehead"] == DBNull.Value ? string.Empty : reader["feehead"].ToString(),
                            Amount = reader["amount"] == DBNull.Value ? null : Convert.ToInt32(reader["amount"]),
                            PaymentMode = reader["paymentmode"] == DBNull.Value ? string.Empty : reader["paymentmode"].ToString(),
                            PaymentDate = reader["paymentdate"] == DBNull.Value ? null : ((DateOnly)reader["paymentdate"]).ToDateTime(TimeOnly.MinValue),
                            CreatedBy = reader["createdby"] == DBNull.Value ? null : Convert.ToInt32(reader["createdby"]),
                            CreatedOn = reader["createdon"] == DBNull.Value ? null : Convert.ToDateTime(reader["createdon"]),
                            LmodBy = reader["lmodby"] == DBNull.Value ? null : Convert.ToInt32(reader["lmodby"]),
                            LmodOn = reader["lmodon"] == DBNull.Value ? null : Convert.ToDateTime(reader["lmodon"]),
                            IsActive = reader["isactive"] == DBNull.Value ? null : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(receipt);
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