using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ipek.Controllers
{
    public class SeansController:ApiController
    {
        sinemaEntities _ent = new sinemaEntities();
        [HttpGet]
        public List<SeansTip> SeanslariGetir()
        {
            return _ent.seans.Select(p => new SeansTip()
            {
                seansID = p.seansID,
                seansZaman = p.seansZaman

            }).ToList();
        }
        [HttpPost]
        public List<SeansTip> SeansEkle (seans yseans)
        {
            try
            {
                seans s = new seans();
                s.seansID = yseans.seansID;
                s.seansZaman = yseans.seansZaman;
                _ent.seans.Add(s);
                _ent.SaveChanges();
                return SeanslariGetir();
            }
            catch(Exception s)
            {
                return null;
            }

        }
        [HttpGet]
        public List<SeansTip> SeansSil(int seansID)
        {
            List<gosterim> g = _ent.gosterim.Where(p => p.seansID == seansID).ToList();
            if ( g != null)
            {
                _ent.gosterim.RemoveRange(g);
                _ent.SaveChanges();
            }
            _ent.seans.Remove(_ent.seans.Find(seansID));
            _ent.SaveChanges();
            return SeanslariGetir();
        }
        
    }
    public class SeansTip
    {
        public int seansID { get; set; }
        public string seansZaman { get; set; }
    }
}