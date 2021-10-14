using System;
using System.Collections.Generic;
using GestioneContatti;

namespace ContactManager
{
    public interface IManager
    {
        List<Persona> Find(string name, string surname);
        List<Persona> Find(string search);

        Persona Find(Persona persona);
        bool Add(Persona persona);
        bool Delete(Persona persona);
        bool Delete(int id);
        bool Update(Persona persona);

        List<Persona> getAll();
    }
}
