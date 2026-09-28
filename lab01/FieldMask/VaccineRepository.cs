using FieldMask.Abstractions;
using FieldMask.Enums;

namespace FieldMask;

public class VaccineRepository : IVaccineRepository
{
    private readonly List<VaccineRecord> _vaccines =
    [
        new VaccineRecord
        {
            Id = Guid.NewGuid(),
            ChildName = "Alex",
            AgeMonths = 24,
            VaccineName = "MMR",
            DoseMl = 0.5f,
            VaccineType = VaccineType.Polio,
            Status = Status.Completed,
            DoctorName = "Dr. Maria"
        },

        new VaccineRecord
        {
            Id = Guid.NewGuid(),
            ChildName = "Daniel",
            AgeMonths = 12,
            VaccineName = "Hepatitis B",
            DoseMl = 0.5f,
            VaccineType = VaccineType.BGG,
            Status = Status.Completed,
            DoctorName = "Dr. Andrei"
        }
    ];

    public void AddRecord(VaccineRecord record)
    {
        _vaccines.Add(record);
    }

    public IEnumerable<VaccineRecord> GetAllRecords()
    {
        return _vaccines;
    }
    
    public IEnumerable<VaccineRecord> GetByVaccineName(string vaccineName)
    {
        return _vaccines.Where(record => record.VaccineName == vaccineName).ToList();
    }
}