using GestioneContatti;
using Handlaer;
using System;
using System.Linq;

namespace Esecutore
{
    class Program
    { 
        private static HandlerContatti Rub;
        private static void CreatePerson()
        {
            Console.WriteLine("nome");
            string nome = Console.ReadLine();
            Console.WriteLine("cogonme");
            string cognome = Console.ReadLine();
            Console.WriteLine("mail");
            string mail = Console.ReadLine();
            Console.WriteLine("telefono");
            string phone = Console.ReadLine();
            Console.WriteLine("data nascita");
            DateTime nascita = Convert.ToDateTime(Console.ReadLine());

            Persona newPerson = new Persona
            {
                Name = nome,
                SurName = cognome,
                Phone = phone,
                Email = mail,
                BirthDate = nascita
            };
            if (Rub.Modifica(newPerson) == true)
                Console.WriteLine("Aggiunto correttamente");
            else
                Console.WriteLine("Errore");
        }

        static void Main(string[] args)
        {
            Rub = new HandlerContatti(@"C:\DATA\miaRub.csv");
            Rub.Load();
            var personacercata = Rub.Cerca("g");
            Console.WriteLine("I contatti che rispecchiano la tua ricerca sono: ");
            foreach (var item in personacercata)
            {
                Console.WriteLine($"Nome: {item.Name} | Cognome: {item.SurName} | Telefono: {item.Phone}");
            }

            Rub.Add("Paolo", "Martedì", "08055145", "bianchi@tin.com", new DateTime(1984, 03, 01));

            Console.ReadLine();

            Rub.Save();

            string nameToLook = "Paolo";
            string surrToLook = "Martedì";

            var risultatoLook = Rub.Cerca(nameToLook, surrToLook);
            foreach (var tmp in risultatoLook)
            {
                Console.WriteLine($"Trovato persona {tmp.Name} e cognome {tmp.SurName}");
            }

            //ESEMPIO MODIFICA NOME PERSONA
            Console.WriteLine("Inserisci nome di utente da modificare");
            nameToLook = Console.ReadLine();
            var elenco = Rub.Cerca(nameToLook);
            if (elenco != null)
            {
                foreach (var tmp in elenco)
                {
                    Console.WriteLine($"utente {tmp.Name} {tmp.SurName} ID==> {tmp.Id}");
                }
                Console.WriteLine("Inserisci ID da modificare");
                int idToLook = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Inserisci nuovo nome da mettere");
                var newname = Console.ReadLine();
                var changedPers = elenco.Where(x => x.Id == idToLook).Single();
                changedPers.Name = newname;
                if (Rub.Modifica(changedPers) == true)
                    Console.WriteLine("Cambiamento avvenuto con successo");
                else
                    Console.WriteLine("Errore nel cambiamento");
            }

            //CREAZIONE NUOVO CONTATTO
            CreatePerson();

        }




    }
}
