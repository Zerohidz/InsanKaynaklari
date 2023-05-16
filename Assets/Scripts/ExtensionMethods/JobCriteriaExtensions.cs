
// GetDisplay()'ler dictionary yerine switch kullanýyor çünkü language support gelebilir
public static class GenderExtensions
{
    public static string GetDisplay(this Gender gender)
    {
        string displayText = gender switch
        {
            Gender.Male => "Erkek",
            Gender.Female => "Kadýn",
            _ => "Belirsiz hocam",
        };
        return displayText;
    }

    public static string GetDisplay(this JobField jobField)
    {
        string displayText = jobField switch
        {
            JobField.Education => "Eðitim",
            JobField.Health => "Saðlýk",
            JobField.MarketingAndEconomics => "Pazarlama ve Ekonomi",
            JobField.Engineering => "Mühendislik",
            _ => "Belirsiz alan",
        };
        return displayText;
    }

    public static string GetDisplay(this Job job)
    {
        string displayText = job switch
        {
            Job.Math => "Matematik",
            Job.Biology => "Biyoloji",
            Job.Chemistry => "Kimya",
            Job.Literature => "Edebiyat",
            Job.Geography => "Coðrafya",
            Job.History => "Tarih",
            Job.PhysicalEducation => "Beden Eðitimi",
            Job.Physics => "Fizik",
            Job.ForeignLanguage => "Yabancý Dil",
            Job.Geometry => "Geometri",

            Job.CardiovascularMD => "Kardiyovasküler týbba odaklanan Týp Doktoru (MD)",
            Job.InternalMedicineMD => "Dahiliye odaklý Týp Doktoru (MD)",
            Job.EmergencyMedicineMD => "Acil týp odaklý Týp Doktoru (MD)",
            Job.PediatricsMD => "Pediatri odaklý Týp Doktoru (MD)",
            Job.OncologyMD => "Onkoloji odaklý Týp Doktoru (MD)",
            Job.PsychiatryMD => "Psikiyatri odaklý Týp Doktoru (MD)",
            Job.DermatologyMD => "Dermatoloji odaklý Týp Doktoru (MD)",
            Job.NeurologyMD => "Nörolojiye odaklanan Týp Doktoru (MD)",
            Job.FamilyMedicineMD => "Aile hekimliðine odaklanan Týp Doktoru (MD)",
            Job.ObstetricsAndGynecologyMD => "Kadýn Hastalýklarý ve Doðum odaklý Týp Doktoru (MD)",

            Job.EconomicsBachelor => "Ekonomi lisans derecesi",
            Job.FinanceBachelor => "Finans alanýnda lisans derecesi",
            Job.MarketingBachelor => "Pazarlama lisans derecesi",
            Job.BusinessBachelor => "Ýþletme alanýnda lisans derecesi",
            Job.InternationalBusinessBachelor => "Uluslararasý iþletme lisans derecesi",
            Job.ManagementBachelor => "Yönetim alanýnda lisans derecesi",
            Job.SupplyChainManagementBachelor => "Tedarik zinciri yönetiminde lisans derecesi",
            Job.AdvertisingBachelor => "Reklamcýlýkta lisans derecesi",
            Job.PublicRelationsBachelor => "Halkla iliþkiler alanýnda lisans derecesi",
            Job.DigitalMarketingBachelor => "Dijital pazarlama alanýnda lisans derecesi",

            Job.ChemicalEngineeringBachelor => "Kimya mühendisliði lisans derecesi",
            Job.CivilEngineeringBachelor => "Ýnþaat mühendisliði lisans derecesi",
            Job.ComputerEngineeringBachelor => "Bilgisayar mühendisliði lisans derecesi",
            Job.ElectricalEngineeringBachelor => "Elektrik mühendisliði lisans derecesi",
            Job.EnvironmentalEngineeringBachelor => "Çevre mühendisliði lisans derecesi",
            Job.IndustrialEngineeringBachelor => "Endüstri mühendisliði lisans derecesi",
            Job.MaterialEngineeringBachelor => "Malzeme mühendisliði lisans derecesi",
            Job.MechanicalEngineeringBachelor => "Makine mühendisliði lisans derecesi",
            Job.SoftwareEngineeringBachelor => "Yazýlým mühendisliði lisans derecesi",
            Job.AerospaceEngineeringBachelor => "Havacýlýk ve uzay mühendisliði lisans derecesi",

            _ => "Belirsiz iþ",
        };
        return displayText;
    }

    public static string GetDisplay(this PositiveTrait positiveTrait)
    {
        string displayText = positiveTrait switch
        {
            PositiveTrait.Thorough => "Titiz",
            PositiveTrait.Optimistic => "Ýyimser",
            PositiveTrait.Punctual => "Dakiklik",
            PositiveTrait.Enterprising => "Giriþkenlik",
            PositiveTrait.Organized => "Düzen, Tertip",
            PositiveTrait.Professional => "Profesyonellik",
            PositiveTrait.TeamPlayer => "Takým Çalýþmacýsý",
            PositiveTrait.Responsible => "Sorumluluk Sahibi",
            PositiveTrait.HighCommunicationSkill => "Yüksek Ýletiþim Kabiliyeti",
            PositiveTrait.Adaptable => "Uyum Saðlayabilme, Esneklik",
            _ => "Belirsiz özellik",
        };
        return displayText;
    }

    public static string GetDisplay(this NegativeTrait negativeTrait)
    {
        string displayText = negativeTrait switch
        {
            NegativeTrait.PoorHygiene => "Kötü kiþisel hijyen veya bakým",
            NegativeTrait.Procrastination => "Erteleme veya zayýf zaman yönetimi",
            NegativeTrait.ChronicTardiness => "Sürekli geç kalma veya devamsýzlýk",
            NegativeTrait.DisrespectfulLanguage => "Saygýsýz veya uygunsuz dil veya davranýþ",
            NegativeTrait.DishonestBehavior => "Dürüst olmayan veya etik olmayan davranýþ",
            NegativeTrait.PoorCooperation => "Ýþbirliði içinde çalýþamama veya etkili iletiþim kuramama",
            NegativeTrait.LackOfAccountability => "Kiþinin iþi için hesap verebilirlik veya sorumluluk eksikliði",
            NegativeTrait.NegativeAttitude => "Meslektaþlara veya müþterilere karþý olumsuz tutum veya davranýþ",
            NegativeTrait.NoncomplianceWithCompanyPolicy => "Þirket politikalarýna veya prosedürlerine itaatsizlik veya meydan okuma",
            NegativeTrait.ExcessiveUseOfPersonalDevices => "Çalýþma saatlerinde kiþisel cihazlarýn veya sosyal medyanýn aþýrý kullanýmý.",
            _ => "Belirsiz özellik",
        };
        return displayText;
    }

    public static string GetDisplay(this PoliticView politicView)
    {
        string displayText = politicView switch
        {
            PoliticView.Liberalism => "Liberalizm",
            PoliticView.Conservatism => "Muhafazakarlýk",
            PoliticView.Socialism => "Sosyalizm",
            PoliticView.Capitalism => "Kapitalizm",
            PoliticView.Anarchism => "Anarþizm",
            PoliticView.Fascism => "Faþizm",
            PoliticView.Communism => "Komünizm",
            PoliticView.Nationalism => "Milliyetçilik",
            _ => "Belirsiz politik görüþ",
        };
        return displayText;
    }

    public static string GetDisplay(this Religion religion)
    {
        string displayText = religion switch
        {
            Religion.Christianity => "Hýristiyanlýk",
            Religion.Islam => "Ýslâm",
            Religion.Judaism => "Yahudilik",
            Religion.Buddhism => "Budizm",
            Religion.Hinduism => "Hinduizm",
            Religion.Atheism => "Ateizm",
            Religion.Deism => "Deizm",
            Religion.Agnosticism => "Agnostisizm",
            _ => "Belirsiz din",
        };
        return displayText;
    }
}