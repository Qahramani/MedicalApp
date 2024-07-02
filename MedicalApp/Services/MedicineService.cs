using MedicalApp.Exceptions;
using MedicalApp.Models;

namespace MedicalApp.Services;

public class MedicineService 
{

    public Medicine CreateMedicine(Medicine medicine)
    {
        foreach (var category in DB.categories)
        {
            if (medicine.CategoryId == category.Id)
            {
                Array.Resize(ref DB.medicines, DB.medicines.Length + 1);
                DB.medicines[^1] = medicine;
            }
        }
        throw new NotFoundException("Category is not found");
    }

    public Medicine[] GetAllMedicines()
    {
        return DB.medicines;
    }

    public Medicine GetMedicineById(int id)
    {
        foreach (var medicine in DB.medicines)
        {
            if (medicine.Id == id)
                return medicine;
        }
        throw new NotFoundException("Medicine with given Id is not found");
    }
    public Medicine GetMedicineByName(string name)
    {
        foreach (var medicine in DB.medicines)
        {
            if (medicine.Name == name)
                return medicine;
        }
        throw new NotFoundException("Medicine with given name is not found");
    }


    public Medicine[] GetMedicineByCategory(int categoryId)
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
    public void RemoveMedicine(int id)
    {
        for (int i = 0; i < DB.medicines.Length; i++)
        {
            if (DB.medicines[i].Id == id)
            {
                for (int j = i; j < DB.medicines.Length - 1; j++)
                {
                    DB.medicines[j] = DB.medicines[j + 1];
                }
                Array.Resize(ref DB.medicines, DB.medicines.Length - 1);
                Console.WriteLine("Medicine removed succesfully");
                return;
            }
        }
        throw new NotFoundException("Medicine with given Id is not found");
    }

    public void UpdateMedicine(int id, Medicine medicine)
    {
        for (int i = 0; i < DB.medicines.Length; i++)
        {
            if (DB.medicines[i].Id == id)
            {
                DB.medicines[i] = medicine;
                return;
            }
        }
        throw new NotFoundException("Medicine with given Id is not found");
    }
}
