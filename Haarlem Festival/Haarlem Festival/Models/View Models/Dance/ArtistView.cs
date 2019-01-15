using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Domain_Models.Dance;

namespace Haarlem_Festival.Models.View_Models.Dance
{
    public class ArtistView
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }

        public IList<ArtistView> DomainToView(IEnumerable<Artist> Artists)
        {
            List<ArtistView> Artistlist = new List<ArtistView>();
            foreach(Artist a in Artists)
            {
                Name = a.Name;
                ImgUrl = a.ImgUrl;
                Description = a.Description;
                Artistlist.Add(this);
            }
            return Artistlist;
        }
    }
}