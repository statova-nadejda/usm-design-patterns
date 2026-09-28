using FieldMask.Enums;

namespace FieldMask.Tests;

public class VaccineRepositoryTests
{
    [Fact]
    public void AddRecord_ShouldAddRecordToRepository()
    {
        var vaccineRepository = new VaccineRepository();
        var record = new VaccineRecord()
        {
            Id = Guid.NewGuid(),
            ChildName = "Daniel Rusu",
            AgeMonths = 6,
            VaccineName = "Hepatitis B",
            DoseMl = 0.5f,
            VaccineType = VaccineType.HepatitisB,
            Status = Status.Planned,
            DoctorName = "Dr. Andrei Popa"
        };
        
        vaccineRepository.AddRecord(record);
        
        Assert.Contains(record, vaccineRepository.GetAllRecords());
    }

    [Fact]
    public void GetAllRecords_ShouldReturnAllRecords()
    {
        var vaccineRepository = new VaccineRepository();
        var record1 = new VaccineRecord()
        {
            Id = Guid.NewGuid(),
            ChildName = "Daniel Rusu",
            AgeMonths = 6,
            VaccineName = "Hepatitis B",
            DoseMl = 0.5f,
            VaccineType = VaccineType.HepatitisB,
            Status = Status.Planned,
            DoctorName = "Dr. Andrei Popa"
        };
        var record2 = new VaccineRecord()
        {
            Id = Guid.NewGuid(),
            ChildName = "Alex Popescu",
            AgeMonths = 24,
            VaccineName = "MMR",
            DoseMl = 0.5f,
            VaccineType = VaccineType.Polio,
            Status = Status.Completed,
            DoctorName = "Dr. Maria Ionescu"
        };
        vaccineRepository.AddRecord(record1);
        vaccineRepository.AddRecord(record2);
        
        var result = vaccineRepository.GetAllRecords();
        
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetAllRecords_ShouldReturnEmptyListIfNoRecordsFound()
    {
        var vaccineRepository = new VaccineRepository();
        
        var result = vaccineRepository.GetAllRecords();
        
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetByVaccineName_ShouldReturnRecordsWithMatchingVaccineName()
    {
        var vaccineRepository = new VaccineRepository();
        var record1 = new VaccineRecord()
        {
            Id = Guid.NewGuid(),
            ChildName = "Daniel Rusu",
            AgeMonths = 6,
            VaccineName = "Hepatitis B",
            DoseMl = 0.5f,
            VaccineType = VaccineType.HepatitisB,
            Status = Status.Planned,
            DoctorName = "Dr. Andrei Popa"
        };
        var record2 = new VaccineRecord()
        {
            Id = Guid.NewGuid(),
            ChildName = "Alex Popescu",
            AgeMonths = 24,
            VaccineName = "MMR",
            DoseMl = 0.5f,
            VaccineType = VaccineType.Polio,
            Status = Status.Completed,
            DoctorName = "Dr. Maria Ionescu"
        };
        vaccineRepository.AddRecord(record1);
        vaccineRepository.AddRecord(record2);
        
        var result = vaccineRepository.GetByVaccineName("Hepatitis B");
        
        Assert.Single(result);
        Assert.Contains(record1, result);
    }

    [Fact]
    public void GetByVaccineName_ShouldReturnEmptyListIfNoRecordsFound()
    {
        var vaccineRepository = new VaccineRepository();
        
        var result = vaccineRepository.GetByVaccineName("fgbkjntrbn");
        
        Assert.Empty(result);
    }
}