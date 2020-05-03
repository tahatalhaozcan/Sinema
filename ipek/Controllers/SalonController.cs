using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ipek.Controllers
{
    public class SalonController:ApiController
    {
        sinemaEntities _ent = new sinemaEntities();
        [HttpGet]
        public List<SalonTip>SalonlariGetir()
        {
            return _ent.salon.Select(p => new SalonTip()
            {
                salonID = p.salonID,
                salonNo = p.salonNo,

            }).ToList();
        }
        [HttpGet]
        public int AdminGiris(string aka, string apsw)
        {
            admin l = _ent.admin.FirstOrDefault(g => g.kullaniciadi == aka && g.sifre == apsw);
            if (l != null)
            {
                return l.adminID;
            }
            else
            {
                return 0;
            }
        }
        [HttpPost]
        public List<SalonTip> SalonEkle(salon yeni)
        {
            try
            {
                salon s = new salon();
                s.salonID = yeni.salonID;
                s.salonNo = yeni.salonNo;
                
                _ent.salon.Add(s);
                _ent.SaveChanges();
                return SalonlariGetir();
            }
            catch (Exception a)
            {
                return null;
            }
        }
        [HttpGet]
        public int KullaniciGiris(string kka, string kpsw)
        {
            kullanici l = _ent.kullanici.FirstOrDefault(g => g.kullaniciadi == kka && g.kullanicisifre == kpsw);
            if (l != null)
            {
                return l.kullaniciID;
            }
            else
            {
                return 0;
            }
        }
        [HttpGet]
        public List<KullaniciTip> KullanicilariGetir()
        {
            return _ent.kullanici.Select(k => new KullaniciTip()
            {
                kullaniciID = k.kullaniciID,
                kullaniciadi = k.kullaniciadi,
                kullanicisifre = k.kullanicisifre

            }).ToList();
        }
        [HttpPost]
        public List<KullaniciTip> YeniKullanici(kullanici kayit)
        {
            try
            {
                kullanici k = new kullanici();
                k.kullaniciID = kayit.kullaniciID;
                k.kullaniciadi = kayit.kullaniciadi;
                k.kullanicisifre = kayit.kullanicisifre;
                _ent.kullanici.Add(k);
                _ent.SaveChanges();
                return KullanicilariGetir();
            }
            catch (Exception k)
            {
                return null;
            }
        }
    }
    public class SalonTip
    {
        public int salonID { get; set; }
        public int salonNo { get; set; }
    }
    public class KullaniciTip
    {
        public int kullaniciID { get; set; }
        public string kullaniciadi { get; set; }
        public string kullanicisifre { get; set; }
    }
}