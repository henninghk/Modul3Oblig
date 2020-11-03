using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m3op2
{
    public class FamilyApp
    {
        public List<Person> _people;
        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
        }
        internal string WelcomeMessage = "Hei! Welkommen til Family Appen!";
        internal string CommandPrompt = "Commandoene er hjelp, liste og vis \n";

        public object HandleCommand(string command)
        {
            int childrenSearchId = 0;
            string str = "";
            if (command == "hjelp")
            {
                str += @"hjelp => viser en hjelpetekst som forklarer alle kommandoene 
                         liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. 
                         vis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)";
            }

            if (command == "liste")
            {

                foreach (var person in _people)
                {
                    str += person.GetDescription() + "\n";
                }
            }

            if (command.Substring(0, 3) == "vis" && command.Length > 4)
            {
                int searchId = int.Parse(command.Substring(command.Length - 2));
                foreach (var person in _people)
                {
                    if (person.Id == searchId)
                    {
                        str += person.GetDescription();
                        childrenSearchId = person.Id;
                    }
                }
            }
            str = FindChildren(childrenSearchId, str);
            

            return str;
        }

        private string FindChildren(int childrenSearchId, string str)
        {
            if (childrenSearchId != 0)
            {
                int count = 0;
                foreach (var person in _people)
                {
                    
                        if (person.Father != null && childrenSearchId == person.Father.Id)
                        {
                            if (count == 0)
                            {
                                str += "\n  Barn:";
                                count++;
                            }
                            str += $"\n    {person.FirstName} (Id={person.Id}) Født: {person.BirthYear}";
                        }
                        if (person.Mother != null && childrenSearchId == person.Mother.Id)
                        {
                            if (count == 0)
                            {
                                str += "\n  Barn:";
                                count++;
                            }
                            str += $"\n    {person.FirstName} (Id={person.Id}) Født: {person.BirthYear}";
                        }
                    
                }

                if (count > 0)
                {
                    str += "\n";
                }
            }

            return str;
        }

        
        
    }
}