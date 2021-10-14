using GestioneContatti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Manager : IManager
    {
        private readonly List<Persona> Persone;

        public Manager(List<Persona> persone)
        {
            if (persone == null)
                Persone = new List<Persona>();
            Persone = persone;
        }

        public bool Add(Persona persona)
        {
            var search = Find(persona);
            if (search == null)
            {
                persona.Id = FindMaxId() + 1;
                Persone.Add(persona);
                return true;
            }
            return false;
        }

        private int FindMaxId()
        {
            if (Persone == null || Persone.Count == 0)
                return 0;
            return Persone.Max(x => x.Id);
        }

        public bool Delete(Persona persona)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var index = Persone.FindIndex(x => x.Id.Equals(id));
            if (index > -1)
            {
                Persone.RemoveAt(index);
                return true;
            }
            return false;
            
        }

        public List<Persona> Find(string name, string surname)
        {
          return  Persone
                .Where(_ =>
                _.Name.Equals(name)
                && _.SurName == surname).ToList();
        }

        public List<Persona> Find(string search)
        {
            throw new NotImplementedException();
        }

        public Persona Find(Persona persona)
        {
            return Persone
                .Where(x =>
                x.Name.Equals(persona.Name) &&
                x.SurName.Equals(persona.SurName) &&
                x.Phone.Equals(persona.Phone) &&
                x.Email.Equals(persona.Email) &&
                x.BirthDate.Equals(persona.BirthDate)
                ).FirstOrDefault();
        }


        public Persona Find(int id)
        {
            return Persone
                .Where(x =>
                x.Id == id
                ).FirstOrDefault();
        }

        public bool Update(Persona persona)
        {
            var search = Find(persona.Id);
            if (search == null)
            {
                persona.Id = FindMaxId() + 1;
                Persone.Add(persona);
                return true;
            }
            search.Email = persona.Email;
            search.BirthDate = persona.BirthDate;
            search.Name = persona.Name;
            search.SurName = persona.SurName;
            search.Phone = persona.Phone;

            return true;
        }
    }
}
