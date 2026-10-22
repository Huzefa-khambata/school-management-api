using HSMS.API.BO;
using HSMS.API.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace HSMS.API.Repository
{
    public class StudentRepository
    {
        public IDatabaseManager manager;

        public StudentRepository(IDatabaseManager databaseManager)
        {
            manager = databaseManager;
        }

        public List<StudentBO> GetStudentList()
        {
            List<StudentBO> list = new List<StudentBO>();

            try
            {
                manager.CreateParameters(0);
                manager.OpenConnection();

                using (IDataReader reader = manager.ExecuteReader(
                    CommandType.StoredProcedure,
                    "s_student_list"))
                {
                    while (reader.Read())
                    {
                        StudentBO student = new StudentBO
                        {
                            StudentId = reader["studentid"] == DBNull.Value ? 0: Convert.ToInt32(reader["studentid"]),

                            StudentName = reader["studentname"] == DBNull.Value ? string.Empty : reader["studentname"].ToString(),

                            AdmissionNumber = reader["admissionnumber"] == DBNull.Value
                                ? string.Empty
                                : reader["admissionnumber"].ToString(),

                            Gender = reader["gender"] == DBNull.Value
                                ? string.Empty
                                : reader["gender"].ToString(),

                            DateOfBirth = reader["dateofbirth"] == DBNull.Value
                                ? null
    : ((DateOnly)reader["dateofbirth"]).ToDateTime(TimeOnly.MinValue),

                            BloodGroup = reader["bloodgroup"] == DBNull.Value
                                ? string.Empty
                                : reader["bloodgroup"].ToString(),

                            Nationality = reader["nationality"] == DBNull.Value
                                ? string.Empty
                                : reader["nationality"].ToString(),

                            Religion = reader["religion"] == DBNull.Value
                                ? string.Empty
                                : reader["religion"].ToString(),

                            Category = reader["category"] == DBNull.Value
                                ? string.Empty
                                : reader["category"].ToString(),

                            MotherTongue = reader["mothertongue"] == DBNull.Value
                                ? string.Empty
                                : reader["mothertongue"].ToString(),

                            AadhaarNumber = reader["aadhaarnumber"] == DBNull.Value
                                ? string.Empty
                                : reader["aadhaarnumber"].ToString(),

                            AdmissionDate = reader["admissiondate"] == DBNull.Value
                                ? null
    : ((DateOnly)reader["admissiondate"]).ToDateTime(TimeOnly.MinValue),
                            AcademicYear = reader["academicyear"] == DBNull.Value
                                ? string.Empty
                                : reader["academicyear"].ToString(),

                            AdmissionType = reader["admissiontype"] == DBNull.Value
                                ? string.Empty
                                : reader["admissiontype"].ToString(),

                            ClassName = reader["classname"] == DBNull.Value
                                ? string.Empty
                                : reader["classname"].ToString(),

                            SectionName = reader["sectionname"] == DBNull.Value
                                ? string.Empty
                                : reader["sectionname"].ToString(),

                            RollNumber = reader["rollnumber"] == DBNull.Value
                                ? string.Empty
                                : reader["rollnumber"].ToString(),

                            PreviousSchool = reader["previousschool"] == DBNull.Value
                                ? string.Empty
                                : reader["previousschool"].ToString(),

                            TransportRequired = reader["transportrequired"] == DBNull.Value
                                ? string.Empty
                                : reader["transportrequired"].ToString(),

                            HostelRequired = reader["hostelrequired"] == DBNull.Value
                                ? string.Empty
                                : reader["hostelrequired"].ToString(),

                            FatherGuardianName = reader["fatherguardianname"] == DBNull.Value
                                ? string.Empty
                                : reader["fatherguardianname"].ToString(),

                            ParentContact = reader["parentcontact"] == DBNull.Value
                                ? string.Empty
                                : reader["parentcontact"].ToString(),

                            ParentEmail = reader["parentemail"] == DBNull.Value
                                ? string.Empty
                                : reader["parentemail"].ToString(),

                            FatherOccupation = reader["fatheroccupation"] == DBNull.Value
                                ? string.Empty
                                : reader["fatheroccupation"].ToString(),

                            MotherName = reader["mothername"] == DBNull.Value
                                ? string.Empty
                                : reader["mothername"].ToString(),

                            MotherContact = reader["mothercontact"] == DBNull.Value
                                ? string.Empty
                                : reader["mothercontact"].ToString(),

                            MotherOccupation = reader["motheroccupation"] == DBNull.Value
                                ? string.Empty
                                : reader["motheroccupation"].ToString(),

                            LocalGuardianName = reader["localguardianname"] == DBNull.Value
                                ? string.Empty
                                : reader["localguardianname"].ToString(),

                            RelationWithStudent = reader["relationwithstudent"] == DBNull.Value
                                ? string.Empty
                                : reader["relationwithstudent"].ToString(),

                            GuardianContact = reader["guardiancontact"] == DBNull.Value
                                ? string.Empty
                                : reader["guardiancontact"].ToString(),

                            CurrentAddress = reader["currentaddress"] == DBNull.Value
                                ? string.Empty
                                : reader["currentaddress"].ToString(),

                            City = reader["city"] == DBNull.Value
                                ? string.Empty
                                : reader["city"].ToString(),

                            State = reader["state"] == DBNull.Value
                                ? string.Empty
                                : reader["state"].ToString(),

                            Pincode = reader["pincode"] == DBNull.Value
                                ? string.Empty
                                : reader["pincode"].ToString(),

                            PermanentAddress = reader["permanentaddress"] == DBNull.Value
                                ? string.Empty
                                : reader["permanentaddress"].ToString(),

                            EmergencyContactName = reader["emergencycontactname"] == DBNull.Value
                                ? string.Empty
                                : reader["emergencycontactname"].ToString(),

                            EmergencyContactNumber = reader["emergencycontactnumber"] == DBNull.Value
                                ? string.Empty
                                : reader["emergencycontactnumber"].ToString(),

                            MedicalConditions = reader["medicalconditions"] == DBNull.Value
                                ? string.Empty
                                : reader["medicalconditions"].ToString(),

                            Allergies = reader["allergies"] == DBNull.Value
                                ? string.Empty
                                : reader["allergies"].ToString(),

                            BirthCertificate = reader["birthcertificate"] == DBNull.Value
                                ? string.Empty
                                : reader["birthcertificate"].ToString(),

                            TransferCertificate = reader["transfercertificate"] == DBNull.Value
                                ? string.Empty
                                : reader["transfercertificate"].ToString(),

                            PreviousMarksheet = reader["previousmarksheet"] == DBNull.Value
                                ? string.Empty
                                : reader["previousmarksheet"].ToString(),

                            AadhaarCard = reader["aadhaarcard"] == DBNull.Value
                                ? string.Empty
                                : reader["aadhaarcard"].ToString(),

                            PassportSizePhoto = reader["passportsizephoto"] == DBNull.Value
                                ? string.Empty
                                : reader["passportsizephoto"].ToString(),

                            AddressProof = reader["addressproof"] == DBNull.Value
                                ? string.Empty
                                : reader["addressproof"].ToString(),

                            CreatedBy = reader["createdby"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["createdby"]),

                            CreatedOn = reader["createdon"] == DBNull.Value
                                ? null
                                : Convert.ToDateTime(reader["createdon"]),

                            LmodBy = reader["lmodby"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["lmodby"]),

                            LmodOn = reader["lmodon"] == DBNull.Value
                                ? null
                                : Convert.ToDateTime(reader["lmodon"]),

                            IsActive = reader["isactive"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["isactive"])
                        };

                        list.Add(student);
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