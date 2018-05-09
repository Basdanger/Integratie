using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class Organisation : Subject
    {
        public String Afkorting { get; set; }
        public String Site { get; set; }
        public int AantalLeden { get; set; }
        public Person Voorzitter { get; set; }
        public String Richting { get; set; }
        public String Ideologie { get; set; }
        public DateTime Opgericht { get; set; }
        

        public Organisation()
        {

        }

        public Organisation(int id, String full_name, String afkorting, String site, int aantalleden, Person voorzitter, String richting, String ideologie, DateTime opgericht)
        {
            ID = id;
            Full_Name = full_name;
            Afkorting = afkorting;
            Site = site;
            AantalLeden = aantalleden;
            Voorzitter = voorzitter;
            Richting = richting;
            Ideologie = ideologie;
            Opgericht = opgericht;
        }
        
    }
}
