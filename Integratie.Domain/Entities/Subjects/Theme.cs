using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Drawing;


namespace Integratie.Domain.Entities.Subjects
{
    public class Theme : Subject
    {
        public String Terms { get; set; }
        public byte[] Image { get; set; }
        public virtual List<TermMention> TermMentions { get; set; }
        public String TopPersons { get; set; }
        public String TopOrganisations { get; set; }
        public virtual List<Story> Stories { get; set; }


        [NotMapped]
        public List<String> TermsList
        {
            get
            {
                if (Terms != null)
                    return Terms.Split(',').Select(s => s.Trim()).ToList();
                else return new List<string>();
            }
            set
            {
                Terms = String.Join(", ", value.ToArray());
            }
        }
        [NotMapped]
        public List<String> TopPersonsList
        {
            get
            {
                return TopPersons.Split(',').Select(s => s.Trim()).ToList();
            }
            set
            {
                TopPersons = String.Join(", ", value.ToArray());
            }
        }
        [NotMapped]
        public List<String> TopOrganisationsList
        {
            get
            {
                return TopOrganisations.Split(',').Select(s => s.Trim()).ToList();
            }
            set
            {
                TopOrganisations = String.Join(", ", value.ToArray());
            }
        }

        public Theme()
        {

        }
        public Theme(string name) : base(name)
        {
        }
        public void SetImage(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Image = stream.ToArray();
        }
        public string GetImageSrc()
        {
            //MemoryStream memoryStream = new MemoryStream(Image);
            //Image i = System.Drawing.Image.FromStream(memoryStream);
            //return i;
            string imreBase64Data = Convert.ToBase64String(Image);
            string imgDataURL = string.Format("data:image/jpeg;base64,{0}", imreBase64Data);

            return imgDataURL;
        }
    }
}
