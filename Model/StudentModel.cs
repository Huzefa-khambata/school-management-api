namespace HSMS.API.Model
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        public string? StudentName { get; set; }
        public string? AdmissionNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? BloodGroup { get; set; }
        public string? Nationality { get; set; }
        public string? Religion { get; set; }
        public string? Category { get; set; }
        public string? MotherTongue { get; set; }
        public string? AadhaarNumber { get; set; }

        public DateTime? AdmissionDate { get; set; }
        public string? AcademicYear { get; set; }
        public string? AdmissionType { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? RollNumber { get; set; }
        public string? PreviousSchool { get; set; }
        public string? TransportRequired { get; set; }
        public string? HostelRequired { get; set; }

        public string? FatherGuardianName { get; set; }
        public string? ParentContact { get; set; }
        public string? ParentEmail { get; set; }
        public string? FatherOccupation { get; set; }
        public string? MotherName { get; set; }
        public string? MotherContact { get; set; }
        public string? MotherOccupation { get; set; }
        public string? LocalGuardianName { get; set; }
        public string? RelationWithStudent { get; set; }
        public string? GuardianContact { get; set; }

        public string? CurrentAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Pincode { get; set; }
        public string? PermanentAddress { get; set; }

        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactNumber { get; set; }
        public string? MedicalConditions { get; set; }
        public string? Allergies { get; set; }

        public string? BirthCertificate { get; set; }
        public string? TransferCertificate { get; set; }
        public string? PreviousMarksheet { get; set; }
        public string? AadhaarCard { get; set; }
        public string? PassportSizePhoto { get; set; }
        public string? AddressProof { get; set; }
    }
}