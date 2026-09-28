using FieldMask.Enums;

namespace FieldMask.Tests;

public class VaccineHelpersTests
{
    [Theory]
    [InlineData(VaccineField.ChildName, true)]
    [InlineData(VaccineField.AgeMonths, true)]
    [InlineData(VaccineField.VaccineName, false)]
    public void GetField_ShouldReturnCorrectValue(VaccineField field, bool expected)
    {
        var mask = new VaccineFieldMask()
        {
            ChildName = true,
            AgeMonths = true,
            VaccineName = false,
        };

        var result = VaccineHelpers.Get(mask, field);
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(VaccineField.ChildName, true)]
    [InlineData(VaccineField.AgeMonths, true)]
    [InlineData(VaccineField.VaccineName, false)]
    public void SetField_ShouldSetCorrectValue(VaccineField field, bool value)
    {
        var mask = new VaccineFieldMask();
        
        VaccineHelpers.Set(mask, field, value);
        
        Assert.Equal(value, mask.GetType().GetProperty(field.ToString())?.GetValue(mask));
    }

    [Theory]
    [InlineData(VaccineField.ChildName, "Daniel Rusu")]
    [InlineData(VaccineField.AgeMonths, 6)]
    [InlineData(VaccineField.VaccineName, "Hepatitis B")]
    public void GetValue_ShouldReturnCorrectValue(VaccineField field, object expected)
    {
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
        
        var result = VaccineHelpers.GetValue(record, field);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData((VaccineField)9878)]
    [InlineData((VaccineField)345)]
    public void GetValue_ThrowsExceptionIfNoMatchingField(VaccineField field)
    {
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

        Assert.Throws<ArgumentOutOfRangeException>(() => VaccineHelpers.GetValue(record, field));
    }
}