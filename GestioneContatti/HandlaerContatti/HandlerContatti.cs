using System;
using System.Collections.Generic;
using ContactManager;
using GestioneContatti;
using FileHelper;

namespace Handlaer
{
    public class HandlerContatti
    {
        private Manager MyManager;
        private readonly string Path;
        private readonly MyFile MioFile;
        private readonly Traslate MyTranslate;

            public HandlerContatti(string path)
        {
            MyTranslate = new Traslate();
            MioFile = new MyFile();
            Path = path;
        }

        public void Load()
        {
            var listaStringhe = MioFile.GetRows(Path);
            var miaRub = MyTranslate.GetPersone(listaStringhe);
            MyManager = new Manager(miaRub);
        }

        public void Save()
        {
            var listOfPeople = MyTranslate.PutPersona(MyManager.getAll());
            MioFile.Put(Path, listOfPeople);
        }
        public void Add(string nome, string cognome, string telefono, string email, DateTime datanascita)
        {
            var persona = new Persona
            {
                Name = nome,
                SurName = cognome,
                Phone = telefono,
                Email = email,
                BirthDate = datanascita
            };

            MyManager.Add(persona);
        }

        public List<Persona> Cerca(string src)
        {
            return MyManager.Find(src);
        }

        public List<Persona> Cerca(string name,string surrName)
        {
            return MyManager.Find(name, surrName);
        }

        public Persona Cerca(int id)
        {
            return MyManager.Find(id);
        }

        public bool Modifica(Persona pers)
        {
            return MyManager.Update(pers);
        } 

        }
}
