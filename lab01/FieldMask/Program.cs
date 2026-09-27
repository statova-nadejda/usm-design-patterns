using FieldMask;
using FieldMask.Abstractions;
using FieldMask.Enums;

IVaccineRepository vaccineRepo = new VaccineRepository();

var vaccine = new VaccineRecord
{
    Id = Guid.NewGuid(),
    ChildName = "John Doe",
    AgeMonths = 12,
    VaccineName = "MMR",
    DoseMl = 0.5f,
    VaccineType = VaccineType.MMR,
    Status = Status.Completed,
    DoctorName = "Dr. Smith"
};

var record2 = new VaccineRecord
{
    Id = Guid.NewGuid(),
    ChildName = "John Doe 2",
    AgeMonths = 10,
    VaccineName = "MMR",
    DoseMl = 0.5f,
    VaccineType = VaccineType.MMR,
    Status = Status.Completed,
    DoctorName = "Dr. Smith"
};

VaccineHelpers.Print(vaccine, new VaccineFieldMask
{
    ChildName = false,
    AgeMonths = true,
    VaccineName = true,
    DoseMl = true,
    VaccineType = true,
    Status = false,
    DoctorName = false
});

vaccineRepo.AddRecord(vaccine);
vaccineRepo.AddRecord(record2);

var mmrVaccines = vaccineRepo.GetByVaccineName("MMR");

Console.WriteLine($"{mmrVaccines.Count()} matching records found");    