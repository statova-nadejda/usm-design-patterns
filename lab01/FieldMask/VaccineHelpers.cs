using System.Diagnostics;
using FieldMask.Enums;

namespace FieldMask;

public static class VaccineHelpers
{
    public static void Print(VaccineRecord vaccine, VaccineFieldMask? mask = null)
    {
        mask ??= new VaccineFieldMask
        {
            ChildName = true,
            AgeMonths = true,
            VaccineName = true,
            DoseMl = true,
            VaccineType = true,
            Status = true,
            DoctorName = true
        };

        for (var i = VaccineField.FirstField; i < VaccineField.Count; i++)
        {
            if (Get(mask, i))
            {
                Console.WriteLine($"{i}: {GetValue(vaccine, i)}");
            }
        }
    }

    public static bool Get(VaccineFieldMask vaccineFieldMask, VaccineField vaccineField)
    {
        switch (vaccineField)
        {
            case VaccineField.ChildName:
            {
                return vaccineFieldMask.ChildName;
            }
            case VaccineField.AgeMonths:
            {
                return vaccineFieldMask.AgeMonths;
            }
            case VaccineField.VaccineName:
            {
                return vaccineFieldMask.VaccineName;
            }
            case VaccineField.DoseMl:
            {
                return vaccineFieldMask.DoseMl;
            }
            case VaccineField.VaccineType:
            {
                return vaccineFieldMask.VaccineType;
            }
            case VaccineField.Status:
            {
                return vaccineFieldMask.Status;
            }
            case VaccineField.DoctorName:
            {
                return vaccineFieldMask.DoctorName;
            }
            default:
            {
                Debug.Fail("Unknown field value");
                throw new ArgumentException("Invalid vaccine field");
            }
        }
    }

    public static VaccineFieldMask Set(VaccineFieldMask vaccineFieldMask, VaccineField vaccineField, bool value)
    {
        switch (vaccineField)
        {
            case VaccineField.ChildName:
            {
                vaccineFieldMask.ChildName = value;
                return vaccineFieldMask;
            }
            case VaccineField.AgeMonths:
            {
                vaccineFieldMask.AgeMonths = value;
                return vaccineFieldMask;
            }
            case VaccineField.VaccineName:
            {
                vaccineFieldMask.VaccineName = value;
                return vaccineFieldMask;
            }
            case VaccineField.DoseMl:
            {
                vaccineFieldMask.DoseMl = value;
                return vaccineFieldMask;
            }
            case VaccineField.VaccineType:
            {
                vaccineFieldMask.VaccineType = value;
                return vaccineFieldMask;
            }
            case VaccineField.Status:
            {
                vaccineFieldMask.Status = value;
                return vaccineFieldMask;
            }
            case VaccineField.DoctorName:
            {
                vaccineFieldMask.DoctorName = value;
                return vaccineFieldMask;
            }
            default:
            {
                Debug.Fail("Unknown field value");
                throw new ArgumentException("Invalid vaccine field");
            }
        }
    }

    public static object? GetValue(VaccineRecord vaccineRecord, VaccineField vaccineField)
    {
        return vaccineField switch
        {
            VaccineField.ChildName => vaccineRecord.ChildName,
            VaccineField.AgeMonths => vaccineRecord.AgeMonths,
            VaccineField.VaccineName => vaccineRecord.VaccineName,
            VaccineField.DoseMl => vaccineRecord.DoseMl,
            VaccineField.VaccineType => vaccineRecord.VaccineType,
            VaccineField.Status => vaccineRecord.Status,
            VaccineField.DoctorName => vaccineRecord.DoctorName,
            _ => throw new ArgumentException("Invalid vaccine field")
        };
    }
}