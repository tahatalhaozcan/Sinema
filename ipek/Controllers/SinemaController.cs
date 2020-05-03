using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ipek.Controllers
{
    public class SinemaController:ApiController
    {
        sinemaEntities _ent = new sinemaEntities();
        [HttpGet]
        public List<SinemaTip> SinemalariGetir()
        {
            return _ent.sinema.Select(p => new SinemaTip()
            {
                sinemaID = p.sinemaID,
                sinemaAd = p.sinemaAd,
                sinemaYer = p.sinemaYer

            }).ToList();
            
        }
        [HttpPost]
        public List<SinemaTip>SinemaEkle( sinema yeni)
        {
            try
            {
                sinema s = new sinema();
                s.sinemaID = yeni.sinemaID;
                s.sinemaAd = yeni.sinemaAd;
                s.sinemaYer = yeni.sinemaYer;
                _ent.sinema.Add(s);
                _ent.SaveChanges();
                return SinemalariGetir();
            }
            catch(Exception a)
            {
                return null;
            }
        }

    }
    public class SinemaTip
    {
        public int sinemaID { get; set; }
        public string sinemaAd { get; set; }
        public string sinemaYer { get; set; }
    }
}