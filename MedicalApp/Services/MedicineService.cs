using MedicalApp.Exceptions;
using MedicalApp.Models;
using MedicalApp.Utilities;

namespace MedicalApp.Services;

public class MedicineService
{

    public void CreateMedicine(Medicine medicine)
    {
        foreach (var category in DB.categories)
        {
            if (medicine.CategoryId == category.Id)
            {
                Array.Resize(ref DB.medicines, DB.medicines.Length + 1);
                DB.medicines[^1] = medicine;
                Colored.WriteLine("Medicine succesfully created!", ConsoleColor.Green);
                return;
            }
        }
        throw new NotFoundException("Category is not found");
    }

    public void GetAllMedicines(int userId)
    {
        foreach (var medicine in DB.medicines)
        {
            if (medicine.UserId == userId)
                Console.WriteLine(medicine);
        }
    }

    public void GetMedicineById(int medicineId, int userId)
    {
        foreach (var medicine in DB.medicines)
        {
            if (medicine.Id == medicineId && userId == medicine.UserId)
            {
                Console.WriteLine(medicine);
                return;
            }
        }
        throw new NotFoundException("Medicine with given Id is not found");
    }
    public void GetMedicineByName(string name , int userId)
    {
        foreach (var medicine in DB.medicines)
        {
            if (medicine.Name == name && userId == medicine.UserId)
            {
                Console.WriteLine(medicine);
                return;
            }
        }
        throw new NotFoundException("Medicine with given name is not found");
    }


    public Medicine[] GetMedicineByCategory(int categoryId , int userId)
    {
        Medicine[] result = new Medicine[0];
        for (int i = 0; i < DB.medicines.Length; i++)
        {
            if (DB.medicines[i].CategoryId == categoryId)
            {
                Array.Resize(ref result, result.Length + 1);
                result[^1] = DB.medicines[i];
            }
        }
        return result.Length > 0 ? result : throw new NotFoundException("Medicine with given Category is not found");
    }
    public void RemoveMedicine(int medicineId, int userId)
    {
        for (int i = 0; i < DB.medicines.Length; i++)
        {
            if (DB.medicines[i].Id == medicineId && userId == DB.medicines[i].UserId)
            {
                for (int j = i; j < DB.medicines.Length - 1; j++)
                {
                    DB.medicines[j] = DB.medicines[j + 1];
                }
                Array.Resize(ref DB.medicines, DB.medicines.Length - 1);
                Colored.WriteLine("Medicine succesfully removed!", ConsoleColor.Green);
                return;
            }
        }
        throw new NotFoundException("Medicine with given Id is not found");
    }

    public void UpdateMedicine(int id, Medicine medicine, int userId)
    {
        for (int i = 0; i < DB.medicines.Length; i++)
        {
            if (DB.medicines[i].Id == id && DB.medicines[i].UserId == userId)
            {
                DB.medicines[i].Name = medicine.Name;
                DB.medicines[i].Price = medicine.Price;
                DB.medicines[i].CategoryId = medicine.CategoryId;
                Colored.WriteLine("Medicine succesfully updated!", ConsoleColor.Green);
                return;
            }
        }
        throw new NotFoundException("Medicine with given Id is not found");
    }
}
