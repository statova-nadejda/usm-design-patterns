using System.Diagnostics;
using FieldMask.Enums;

namespace FieldMask;

public class VaccineRecord
{
    public Guid Id { get; set; }
    public required string ChildName  { get; set; }
    public int AgeMonths  { get; set; }
    public required string VaccineName { get; set; }
    public float DoseMl { get; set; }
    public VaccineType  VaccineType { get; set; }
    public Status Status { get; set; }
    public required string DoctorName { get; set; }
}
