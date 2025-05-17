using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppКУРСОВАЯ
{
    class Appointment
    {
        public int IdAppointment { get; }
        public Animal Animal { get; }
        public Veterinarian Veterinarian { get; }
        public DateTime Data { get; }
        public string Diagnosis { get; }
        public string Medication { get; }
        public decimal Cost { get; }

        public Appointment(int idAppointment, Animal animal, Veterinarian veterinarian, DateTime data, string diagnosis, string medication, decimal cost)
        {
            IdAppointment = idAppointment;
            Animal = animal;
            Veterinarian = veterinarian;
            Data = data;
            Diagnosis = diagnosis;
            Medication = medication;
            Cost = cost;
        }
    }
}
