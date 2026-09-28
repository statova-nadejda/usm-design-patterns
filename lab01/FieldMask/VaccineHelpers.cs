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
                return vaccineFieldMask.ChildName ?? false;
            }
            case VaccineField.AgeMonths:
            {
                return vaccineFieldMask.AgeMonths ?? false;
            }
            case VaccineField.VaccineName:
            {
                return vaccineFieldMask.VaccineName ?? false;
            }
            case VaccineField.DoseMl:
            {
                return vaccineFieldMask.DoseMl ?? false;;
            }
            case VaccineField.VaccineType:
            {
                return vaccineFieldMask.VaccineType ?? false;;
            }
            case VaccineField.Status:
            {
                return vaccineFieldMask.Status ?? false;;
            }
            case VaccineField.DoctorName:
            {
                return vaccineFieldMask.DoctorName ??  false;
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

    public static Dictionary<string, object?> GetVaccinesByMask(VaccineRecord vaccine, VaccineFieldMask? mask)
    {
        var maskIsEmpty = VaccineHelpers.MaskIsEmpty(mask);
        if (maskIsEmpty)
        {
            mask = new  VaccineFieldMask()
            {
                ChildName = true,
                AgeMonths = true,
                VaccineName = true,
                DoseMl = true,
                VaccineType = true,
                Status = true,
                DoctorName = true,
            };
        }
        
        var result = new Dictionary<string, object?>();

        for (var i = VaccineField.FirstField; i < VaccineField.Count; i++)
        {
            if (Get(mask, i))
            {
                result[i.ToString()] = GetValue(vaccine, i);
            }
        }
        return  result;
    }

    public static bool MaskIsEmpty(VaccineFieldMask mask)
    {
        return mask.ChildName is null
               && mask.AgeMonths is null
               && mask.VaccineName is null
               && mask.DoseMl is null
               && mask.VaccineType is null
               && mask.Status is null
               && mask.DoctorName is null;
    }
    
    public static VaccineFieldMask Union(
        VaccineFieldMask first,
        VaccineFieldMask second)
    {
        return new VaccineFieldMask
        {
            ChildName = (first.ChildName ?? false) || (second.ChildName ?? false),
            AgeMonths = (first.AgeMonths ?? false) || (second.AgeMonths ?? false),
            VaccineName = (first.VaccineName ?? false) || (second.VaccineName ?? false),
            DoseMl = (first.DoseMl ?? false) || (second.DoseMl ?? false),
            VaccineType = (first.VaccineType ?? false) || (second.VaccineType ?? false),
            Status = (first.Status ?? false) || (second.Status ?? false),
            DoctorName = (first.DoctorName ?? false) || (second.DoctorName ?? false)
        };
    }

    public static VaccineFieldMask Intersect(
        VaccineFieldMask first,
        VaccineFieldMask second)
    {
        return new VaccineFieldMask
        {
            ChildName = (first.ChildName ?? false) && (second.ChildName ?? false),
            AgeMonths = (first.AgeMonths ?? false) && (second.AgeMonths ?? false),
            VaccineName = (first.VaccineName ?? false) && (second.VaccineName ?? false),
            DoseMl = (first.DoseMl ?? false) && (second.DoseMl ?? false),
            VaccineType = (first.VaccineType ?? false) && (second.VaccineType ?? false),
            Status = (first.Status ?? false) && (second.Status ?? false),
            DoctorName = (first.DoctorName ?? false) && (second.DoctorName ?? false)
        };
    }

    public static VaccineFieldMask Invert(VaccineFieldMask mask)
    {
        return new VaccineFieldMask
        {
            ChildName = !(mask.ChildName ?? false),
            AgeMonths = !(mask.AgeMonths ?? false),
            VaccineName = !(mask.VaccineName ?? false),
            DoseMl = !(mask.DoseMl ?? false),
            VaccineType = !(mask.VaccineType ?? false),
            Status = !(mask.Status ?? false),
            DoctorName = !(mask.DoctorName ?? false)
        };
    }
}