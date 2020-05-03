using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ipek.Controllers
{
    public class FilmController:ApiController
    {
        sinemaEntities _ent = new sinemaEntities();
        [HttpGet]
        public List<FilmTip> FilmleriGetir()
        {
            return _ent.film.Select(p => new FilmTip()
            {
                filmID = p.filmID,
                filmAd = p.filmAd,
                filmTur = p.filmTur

            }
            ).ToList();
        }
        [HttpPost]
        public List<FilmTip>YeniFilm( film yeni)
        {
            try
            {
                film f = new film();
                f.filmID = yeni.filmID;
                f.filmAd = yeni.filmAd;
                f.filmTur = yeni.filmTur;
                _ent.film.Add(f);
                _ent.SaveChanges();
                return FilmleriGetir();
                

            }
            catch(Exception f)
            {
                return null;
            }
        }
        [HttpGet]
        public List<FilmTip>FilmKaldir(int filmID)
        {
            List<gosterim> g = _ent.gosterim.Where(p => p.filmID == filmID).ToList();
            if(g !=  null)
            {
                _ent.gosterim.RemoveRange(g);
                _ent.SaveChanges();
            }
            _ent.film.Remove(_ent.film.Find(filmID));
            _ent.SaveChanges();
            return FilmleriGetir();
        }

    }
    public class FilmTip
    {
        public int filmID { get; set; }
        public string filmAd { get; set; }
        public string filmTur { get; set; }
    }
}