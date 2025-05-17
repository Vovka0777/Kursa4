using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppКУРСОВАЯ
{
    class Owner
    {
        public int IdOwner { get; }
        public string FioOwner { get; }
        public string Phone { get; }
        public List<Animal> Animals { get; } = new List<Animal>();

        public Owner(int idOwner, string fioOwner, string phone)
        {
            IdOwner = idOwner;
            FioOwner = fioOwner;
            Phone = phone;
        }
    }
}
