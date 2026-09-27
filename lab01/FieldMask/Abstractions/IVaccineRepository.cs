namespace FieldMask.Abstractions;

public interface IVaccineRepository
{
    void AddRecord(VaccineRecord record);
    IEnumerable<VaccineRecord> GetAllRecords();
    IEnumerable<VaccineRecord> GetByVaccineName(string vaccineName);
}