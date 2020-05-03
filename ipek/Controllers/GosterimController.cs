using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ipek.Controllers
{
    public class GosterimController:ApiController
    {
        sinemaEntities _ent = new sinemaEntities();
        [HttpGet]
        public List<GosterimTip> GosterimdekiFilmler(int sinemaID)
        {
            return _ent.gosterim.Where(p => p.sinemaID == sinemaID).Select(p => new GosterimTip()
            {
                filmAd = p.film.filmAd,
                filmTur = p.film.filmTur,
                seansZaman = p.seans.seansZaman,
                salonNo = p.salon.salonNo,
                filmID = p.filmID,
                seansID = p.seansID,
                salonID = p.salonID,
                sinemaID = p.sinemaID,
                gosterimID = p.gosterimID
            }).ToList();
        }
        [HttpPost]
        public List<GosterimTip> YeniGosterim(GosterimTip yeni)
        {
            try
            {
                gosterim g = new gosterim();
                g.sinemaID = yeni.sinemaID;
                g.filmID = yeni.filmID;
                g.seansID = yeni.seansID;
                g.salonID = yeni.salonID;
                
               
                _ent.gosterim.Add(g);
                _ent.SaveChanges();
                return GosterimdekiFilmler(yeni.sinemaID);
            }
            catch(Exception a)
            {
                return null;
            }
        }
        [HttpGet]
        public List<GosterimTip> GosterimBitis (int gosterimID)
        {
            try
            {
                gosterim w = _ent.gosterim.Find(gosterimID);
                int sinemaid = w.sinemaID;
                _ent.gosterim.Remove(w);
                _ent.SaveChanges();
                return GosterimdekiFilmler(sinemaid);

            }
            catch(Exception a)
            {
                return null;
            }
        }

    }
}public class GosterimTip
{
    public int gosterimID { get; set; }
    public int filmID { get; set; }
    public string filmAd { get; set; }
    public string filmTur { get; set; }

    public int seansID { get; set; }
    public string seansZaman { get; set; }
    public int salonID { get; set; }
    public int salonNo { get; set; }
    public int sinemaID { get; set; }
}