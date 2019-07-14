using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_11._07._2019.Models
{
  public class Pharmacy
    {
        private static int _id = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        private List<Medicine> medicines;

        public Pharmacy(string name,string address)
        {
            _id++;
            ID = _id;
            Name = name;
            Address = address;
            medicines = new List<Medicine>()
            {
                new Medicine{Name="Analgin",Price="15" +" Azn"},
                new Medicine{Name="Baralgin",Price="10" +" Azn"},
                new Medicine{Name="Aksenford",Price="12"+" Azn"},
                new Medicine{Name="Nimesil",Price="24"+" Azn"},
                new Medicine{Name="Teraflyu",Price="36"+" Azn"}
            };
         
        }

        public List<Medicine> GetMedicines()
        {
            return medicines;
        }

        public void AddMedicines(Medicine med)
        {
            medicines.Add(med);
        }

        public void DeleteMedicines(int id)
        {
            for (int i = 0; i < medicines.Count; i++)
            {
                if (id == medicines[i].ID)
                {
                    medicines.RemoveAt(i);
                    return;
                }
            }
        }

        public Medicine GetMedicine(int id)
        {
            Medicine result = null;
            for (int i = 0; i < medicines.Count; i++)
            {
                if (id == medicines[i].ID)
                {
                    result = medicines[i];
                }
            }
            return result;

        }

        public void UpdateMedicines(int id,string name,string price)
        {
            Medicine medicine = GetMedicine(id);
            medicine.Name = name;
            medicine.Price = price;
        }
    }
}
