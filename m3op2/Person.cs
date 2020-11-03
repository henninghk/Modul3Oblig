using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m3op2
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }

        public string GetDescription()
        {
            if (FirstName == null || LastName == null || BirthYear == 0 || DeathYear == 0 || Father == null || Mother == null)
            {
                return CheckWhichEmptyField();
            }

            return $"{FirstName} {LastName} (Id={Id}) Født: {BirthYear} Død: {DeathYear} Far: {Father.FirstName} (Id={Father.Id}) Mor: {Mother.FirstName} (Id={Mother.Id})";
        }

        private string CheckWhichEmptyField()
        {

            string str = "";
            if (FirstName != null)
            {
                str += $"{FirstName} ";
            }
            if (LastName != null)
            {
                str += $"{LastName} ";
            }
            if (Id != 0)
            {
                str += $"(Id={Id}) ";
            }
            if (BirthYear != 0)
            {
                str += $"Født: {BirthYear} ";
            }
            if (DeathYear != 0)
            {
                str += $"Død: {DeathYear} ";
            }
            if (Father != null)
            {
                str += $"Far: {Father.FirstName} (Id={Father.Id}) ";
            }
            if (Mother != null)
            {
                str += $"Mor: {Mother.FirstName} (Id={Mother.Id})";
            }

            return str;
        }
    }
}
