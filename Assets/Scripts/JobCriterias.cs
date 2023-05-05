using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public static class JobCriterias
{
    public static readonly int[] Years = { 25, 65 };
    public static readonly int[] ExperienceYears = { 0, 20 };

    public static readonly string[] JobFields = {
        "Eðitim",
        "Saðlýk",
        "Pazarlama ve Ekonomi",
        "Mühendislik",
    };

    public static readonly string[] EducationJobs = {
        "Matematik",
        "Biyoloji",
        "Kimya",
        "Edebiyat",
        "Coðrafya",
        "Tarih",
        "Beden Eðitimi",
        "Fizik",
        "Yabancý Dil",
        "Geometri",
    };

    public static readonly string[] HealthJobs = {
        "Kardiyovasküler týbba odaklanan Týp Doktoru (MD)",
        "Dahiliye odaklý Týp Doktoru (MD)",
        "Acil týp odaklý Týp Doktoru (MD)",
        "Pediatri odaklý Týp Doktoru (MD)",
        "Onkoloji odaklý Týp Doktoru (MD)",
        "Psikiyatri odaklý Týp Doktoru (MD)",
        "Dermatoloji odaklý Týp Doktoru (MD)",
        "Nörolojiye odaklanan Týp Doktoru (MD)",
        "Aile hekimliðine odaklanan Týp Doktoru (MD)",
        "Kadýn Hastalýklarý ve Doðum odaklý Týp Doktoru (MD)",
    };

    public static readonly string[] MarketingEconomyJobs = {
        "Ekonomi lisans derecesi",
        "Finans alanýnda lisans derecesi",
        "Pazarlama lisans derecesi",
        "Ýþletme alanýnda lisans derecesi",
        "Uluslararasý iþletme lisans derecesi",
        "Yönetim alanýnda lisans derecesi",
        "Tedarik zinciri yönetiminde lisans derecesi",
        "Reklamcýlýkta lisans derecesi",
        "Halkla iliþkiler alanýnda lisans derecesi",
        "Dijital pazarlama alanýnda lisans derecesi",
    };

    public static readonly string[] EngineeringJobs = {
        "Kimya mühendisliði lisans derecesi",
        "Ýnþaat mühendisliði lisans derecesi",
        "Bilgisayar mühendisliði lisans derecesi",
        "Elektrik mühendisliði lisans derecesi",
        "Çevre mühendisliði lisans derecesi",
        "Endüstri mühendisliði lisans derecesi",
        "malzeme mühendisliði lisans derecesi",
        "Makine mühendisliði lisans derecesi",
        "Yazýlým mühendisliði lisans derecesi",
        "Havacýlýk ve uzay mühendisliði lisans derecesi",
    };

    public static readonly string[] PositiveTraits = {
        "Titiz",
        "Ýyimser",
        "Dakiklik",
        "Giriþkenlik",
        "Düzen, Tertip",
        "Profesyonellik",
        "Takým Çalýþmacýsý",
        "Sorumluluk Sahibi",
        "Yüksek Ýletiþim Kabiliyeti",
        "Uyum Saðlayabilme, Esneklik",
    };

    public static readonly string[] NegativeTraits = {
        "Kötü kiþisel hijyen veya bakým",
        "Erteleme veya zayýf zaman yönetimi",
        "Sürekli geç kalma veya devamsýzlýk",
        "Saygýsýz veya uygunsuz dil veya davranýþ",
        "Dürüst olmayan veya etik olmayan davranýþ",
        "Ýþbirliði içinde çalýþamama veya etkili iletiþim kuramama",
        "Kiþinin iþi için hesap verebilirlik veya sorumluluk eksikliði",
        "Meslektaþlara veya müþterilere karþý olumsuz tutum veya davranýþ",
        "Þirket politikalarýna veya prosedürlerine itaatsizlik veya meydan okuma",
        "Çalýþma saatlerinde kiþisel cihazlarýn veya sosyal medyanýn aþýrý kullanýmý.",
    };


    public static readonly string[] PoliticView = {
        "Liberalizm",
        "Muhafazakarlýk",
        "Sosyalizm",
        "Kapitalizm",
        "Anarþizm",
        "Faþizm",
        "Komünizm",
        "Milliyetçilik",
    };

    public static readonly string[] Religions = {
        "Hýristiyanlýk",
        "Ýslâm",
        "Yahudilik",
        "Budizm",
        "Hinduizm",
        "Ateizm",
        "Deizm",
        "Agnostisizm",
    };

    public enum Race
    {
        Russsian,
        Turkish,
        Arab,
        German,
        American,
    }

}