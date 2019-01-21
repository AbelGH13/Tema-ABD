using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;

namespace AutoWash
{
    class Utilities
    {
        static public bool VerificareEmail(string email)
        {
            using (var context = new AutoWash.SpalatorieEntities())
            {
                var allEmails = from customers in context.Clienti
                                 orderby customers.Nume
                                 select new
                                 {
                                     customers.AdresaEMAIL
                                 };
                foreach (var item in allEmails)
                {
                    if (email == item.AdresaEMAIL)
                        return true;  
                }
            }
            return false;
        }

        static public string GetName(string email)
        {
            using (var data = new SpalatorieEntities())
            {
                string nume = data.Clienti.First(c => c.AdresaEMAIL == email).Nume;
                return nume;
            }
        }
        static public string GetFirstName(string email)
        {
            using (var data = new SpalatorieEntities())
            {
                string prenume = data.Clienti.First(c => c.AdresaEMAIL == email).Prenume;
                return prenume;
            }
        }

        static public bool VerificareParola(string parola)
        {
            using (var context = new AutoWash.SpalatorieEntities())
            {
                var allPass = from customers in context.Clienti
                              orderby customers.Nume
                              select new
                              {
                                  customers.Parola
                              };
                foreach(var items in allPass)
                {
                    if (parola == items.Parola)
                        return true;
                }
            }
                return false;
        }
    }
}
