using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppКУРСОВАЯ
{
    class Veterinarian
    {
        public int IdVeter { get; }
        public string FioVeter { get; }
        public string Specialisation { get; }
        public List<Appointment> HistoryAppointments { get; } = new List<Appointment>();

        public Veterinarian(int idVeter, string fioVeter, string specialisation)
        {
            IdVeter = idVeter;
            FioVeter = fioVeter;
            Specialisation = specialisation;
        }
    }
}
