using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ipek.Controllers
{
    public class GirisveKayit : ApiController
    {
        sinemaEntities _ent = new sinemaEntities();
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
}
public class KullaniciTip
{
    public int kullaniciID { get; set; }
    public string kullaniciadi { get; set; }
    public string kullanicisifre { get; set; }
}
