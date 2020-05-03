var app = angular.module("filmsys", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/giris", {
            templateUrl: "giris.html",
            controller: "girisCtrl"
        })
        .when("/kayit", {
            templateUrl: "kayit.html",
            controller: "kayitCtrl"
        })
        .when("/silme", {
            templateUrl: "silmeislemleri.html",
            controller: "silmeCtrl"
        })
        .when("/filmlerigoster", {
            templateUrl: "gosterim.html",
            controller: "gosterimCtrl"
        });
     

});
app.controller('girisCtrl', function ($scope, $http, $window) {
    $scope.ygirisyap = function (aka, apsw) {
        $http.get("http://localhost:63270/api/Salon/AdminGiris?aka=" + aka + "&apsw=" + apsw)
            .then(function (response) {
                if (response.data != 0) {
                    $window.location.href = '/eklemeislemleri.html'
                }
                else {
                    alert("Hatalı giriş denemesi");
                }
            });
    }
    $scope.kgirisyap = function (kka, kpsw) {
        $http.get("http://localhost:63270/api/Salon/KullaniciGiris?kka=" + kka + "&kpsw=" + kpsw)
            .then(function (response) {
                if (response.data != 0) {
                    $window.location.href = '/gosterim.html'
                }
                else {
                    alert("Hatalı giriş denemesi");
                }
            });
    }
    $http.get("http://localhost:63270/api/Salon/KullanicilariGetir")
        .then(function (response) {
            $scope.kullanicilar = response.data;
        });
    $scope.kullaniciekle = function (kayit) {
        $http.post("http://localhost:63270/api/Salon/YeniKullanici", kayit)
            .then(function (response) {
                $scope.kullanicilar = response.data;
                $scope.kullanicii = {};
                alert("Girişe yönlendiriliyorsunuz");
                $window.location.href = 'giris.html';
            });
    }
});
app.controller('gosterimCtrl', function ($scope, $http) {
    $http.get("http://localhost:63270/api/Sinema/SinemalariGetir")
        .then(function (response) {
            $scope.sinemalar = response.data;
        });
    
    $scope.bilgilerigetir = function (siid) {
        $http.get("http://localhost:63270/api/Gosterim/GosterimdekiFilmler?sinemaID=" +siid)
            .then(function (response) {
                $scope.bilgiler = response.data;
            });

    }
});
app.controller('kayitCtrl', function ($scope, $http, $window) {
    $http.get("http://localhost:63270/api/Salon/KullanicilariGetir")
    .then(function (response) {
        $scope.kullanicilar = response.data;
    });
    $scope.kullaniciekle = function (kayit) {
        $http.post("http://localhost:63270/api/Salon/YeniKullanici", kayit)
            .then(function (response) {
                $scope.kullanicilar = response.data;
                $scope.kullanici = {};
                alert("Girişe yönlendiriliyorsunuz");
                $window.location.href = 'giris.html';
            });
    }
});
app.controller('eklemeCtrl', function ($scope, $http ) {
    $http.get("http://localhost:63270/api/Film/FilmleriGetir")
        .then(function (response) {
            $scope.filmler = response.data;
        });
    $scope.yenifilmekle = function (yeni) {
        $http.post("http://localhost:63270/api/Film/YeniFilm", yeni)
            .then(function (response) {
                $scope.filmler = response.data;
                $scope.kullanici = {};
                alert("Yeni Film Eklendi");
                
            });
    }
    $http.get("http://localhost:63270/api/Seans/SeanslariGetir")
        .then(function (response) {
            $scope.seanslar = response.data;
        });
    $scope.yeniseansekle = function (yseans) {
        $http.post("http://localhost:63270/api/Seans/SeansEkle", yseans)
            .then(function (response) {
                $scope.seanslar = response.data;
                $scope.kullanici = {};
                alert("Seans Eklendi");
                
            });
    }
    $http.get("http://localhost:63270/api/Salon/SalonlariGetir")
        .then(function (response) {
            $scope.salonlar = response.data;
        });
    $scope.yenisalonekle = function (yeni) {
        $http.post("http://localhost:63270/api/Salon/SalonEkle", yeni)
            .then(function (response) {
                $scope.salonlar = response.data;
                $scope.kullanici = {};
                alert("Yeni Salon Numarası Eklendi");
                
            });
    }
    $http.get("http://localhost:63270/api/Sinema/SinemalariGetir")
        .then(function (response) {
            $scope.sinemalar = response.data;
        });
    $scope.yenisinema = function (yeni) {
        $http.post("http://localhost:63270/api/Sinema/SinemaEkle", yeni)
            .then(function (response) {
                $scope.sinemalar = response.data;
                $scope.kullanici = {};
                alert("Yeni Sinema Eklendi");
               
            });
    }
    $scope.gosterimolustur = function (a, b, c, d) {
        $scope.yeni =
            {
            sinemaID: a,
            filmID: b,
            seansID: c,
            salonID:d

            }
        $http.post("http://localhost:63270/api/Gosterim/YeniGosterim", $scope.yeni)
            .then(function (response) {
                $scope.bilgiler = response.data;
            });
        alert("Gösterim Oluşturuluyor")
    }
});
app.controller('silmeCtrl', function ($scope, $http) {
    $http.get("http://localhost:63270/api/Salon/SalonlariGetir")
        .then(function (response) {
            $scope.salonlar = response.data;
        });
    $http.get("http://localhost:63270/api/Film/FilmleriGetir")
        .then(function (response) {
            $scope.filmler = response.data;
        });
    $http.get("http://localhost:63270/api/Seans/SeanslariGetir")
        .then(function (response) {
            $scope.seanslar = response.data;
        });
    $http.get("http://localhost:63270/api/Sinema/SinemalariGetir")
        .then(function (response) {
            $scope.sinemalar = response.data;
        });

    $scope.bilgilerigetir = function (siid) {
        $http.get("http://localhost:63270/api/Gosterim/GosterimdekiFilmler?sinemaID=" + siid)
            .then(function (response) {
                $scope.bilgiler = response.data;
            });
    }
    $scope.filmsil = function (tid) {
        alert("Siliniyor.");
        $http.get("http://localhost:63270/api/Film/FilmKaldir?filmID=" + tid)
            .then(function (response) {
                $scope.filmler = response.data;
            });
    }
    $scope.sil = function (sid) {
        alert("Siliniyor.");
        $http.get("http://localhost:63270/api/Seans/SeansSil?seansID=" + sid)
            .then(function (response) {
                $scope.seanslar = response.data;
            });
    }

    
    $scope.kaldir = function (gb) {
        alert("Gösterimden Kaldırılıyor");
        $http.get("http://localhost:63270/api/Gosterim/GosterimBitis?gosterimID=" + gb)
            .then(function (response) {
                $scope.bilgier = response.data;
            });
    }
});