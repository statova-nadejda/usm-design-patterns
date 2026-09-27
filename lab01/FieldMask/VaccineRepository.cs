using FieldMask.Abstractions;

namespace FieldMask;

public class VaccineRepository : IVaccineRepository
{
    private readonly List<VaccineRecord> _vaccines = [];

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