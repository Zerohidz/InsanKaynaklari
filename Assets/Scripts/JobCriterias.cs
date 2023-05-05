using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public static class JobCriterias
{
    public static readonly int[] Years = { 25, 65 };
    public static readonly int[] ExperienceYears = { 0, 20 };

    public static readonly string[] JobFields = {
        "E�itim",
        "Sa�l�k",
        "Pazarlama ve Ekonomi",
        "M�hendislik",
    };

    public static readonly string[] EducationJobs = {
        "Matematik",
        "Biyoloji",
        "Kimya",
        "Edebiyat",
        "Co�rafya",
        "Tarih",
        "Beden E�itimi",
        "Fizik",
        "Yabanc� Dil",
        "Geometri",
    };

    public static readonly string[] HealthJobs = {
        "Kardiyovask�ler t�bba odaklanan T�p Doktoru (MD)",
        "Dahiliye odakl� T�p Doktoru (MD)",
        "Acil t�p odakl� T�p Doktoru (MD)",
        "Pediatri odakl� T�p Doktoru (MD)",
        "Onkoloji odakl� T�p Doktoru (MD)",
        "Psikiyatri odakl� T�p Doktoru (MD)",
        "Dermatoloji odakl� T�p Doktoru (MD)",
        "N�rolojiye odaklanan T�p Doktoru (MD)",
        "Aile hekimli�ine odaklanan T�p Doktoru (MD)",
        "Kad�n Hastal�klar� ve Do�um odakl� T�p Doktoru (MD)",
    };

    public static readonly string[] MarketingEconomyJobs = {
        "Ekonomi lisans derecesi",
        "Finans alan�nda lisans derecesi",
        "Pazarlama lisans derecesi",
        "��letme alan�nda lisans derecesi",
        "Uluslararas� i�letme lisans derecesi",
        "Y�netim alan�nda lisans derecesi",
        "Tedarik zinciri y�netiminde lisans derecesi",
        "Reklamc�l�kta lisans derecesi",
        "Halkla ili�kiler alan�nda lisans derecesi",
        "Dijital pazarlama alan�nda lisans derecesi",
    };

    public static readonly string[] EngineeringJobs = {
        "Kimya m�hendisli�i lisans derecesi",
        "�n�aat m�hendisli�i lisans derecesi",
        "Bilgisayar m�hendisli�i lisans derecesi",
        "Elektrik m�hendisli�i lisans derecesi",
        "�evre m�hendisli�i lisans derecesi",
        "End�stri m�hendisli�i lisans derecesi",
        "malzeme m�hendisli�i lisans derecesi",
        "Makine m�hendisli�i lisans derecesi",
        "Yaz�l�m m�hendisli�i lisans derecesi",
        "Havac�l�k ve uzay m�hendisli�i lisans derecesi",
    };

    public static readonly string[] PositiveTraits = {
        "Titiz",
        "�yimser",
        "Dakiklik",
        "Giri�kenlik",
        "D�zen, Tertip",
        "Profesyonellik",
        "Tak�m �al��mac�s�",
        "Sorumluluk Sahibi",
        "Y�ksek �leti�im Kabiliyeti",
        "Uyum Sa�layabilme, Esneklik",
    };

    public static readonly string[] NegativeTraits = {
        "K�t� ki�isel hijyen veya bak�m",
        "Erteleme veya zay�f zaman y�netimi",
        "S�rekli ge� kalma veya devams�zl�k",
        "Sayg�s�z veya uygunsuz dil veya davran��",
        "D�r�st olmayan veya etik olmayan davran��",
        "��birli�i i�inde �al��amama veya etkili ileti�im kuramama",
        "Ki�inin i�i i�in hesap verebilirlik veya sorumluluk eksikli�i",
        "Meslekta�lara veya m��terilere kar�� olumsuz tutum veya davran��",
        "�irket politikalar�na veya prosed�rlerine itaatsizlik veya meydan okuma",
        "�al��ma saatlerinde ki�isel cihazlar�n veya sosyal medyan�n a��r� kullan�m�.",
    };


    public static readonly string[] PoliticView = {
        "Liberalizm",
        "Muhafazakarl�k",
        "Sosyalizm",
        "Kapitalizm",
        "Anar�izm",
        "Fa�izm",
        "Kom�nizm",
        "Milliyet�ilik",
    };

    public static readonly string[] Religions = {
        "H�ristiyanl�k",
        "�sl�m",
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