
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

    public static string GetDisplay(this EducationJob educationJob)
    {
        string displayText = educationJob switch
        {
            EducationJob.Math => "Matematik",
            EducationJob.Biology => "Biyoloji",
            EducationJob.Chemistry => "Kimya",
            EducationJob.Literature => "Edebiyat",
            EducationJob.Geography => "Coðrafya",
            EducationJob.History => "Tarih",
            EducationJob.PhysicalEducation => "Beden Eðitimi",
            EducationJob.Physics => "Fizik",
            EducationJob.ForeignLanguage => "Yabancý Dil",
            EducationJob.Geometry => "Geometri",
            _ => "Belirsiz iþ",
        };
        return displayText;
    }

    public static string GetDisplay(this HealthJob healthJob)
    {
        string displayText = healthJob switch
        {
            HealthJob.CardiovascularMD => "Kardiyovasküler týbba odaklanan Týp Doktoru (MD)",
            HealthJob.InternalMedicineMD => "Dahiliye odaklý Týp Doktoru (MD)",
            HealthJob.EmergencyMedicineMD => "Acil týp odaklý Týp Doktoru (MD)",
            HealthJob.PediatricsMD => "Pediatri odaklý Týp Doktoru (MD)",
            HealthJob.OncologyMD => "Onkoloji odaklý Týp Doktoru (MD)",
            HealthJob.PsychiatryMD => "Psikiyatri odaklý Týp Doktoru (MD)",
            HealthJob.DermatologyMD => "Dermatoloji odaklý Týp Doktoru (MD)",
            HealthJob.NeurologyMD => "Nörolojiye odaklanan Týp Doktoru (MD)",
            HealthJob.FamilyMedicineMD => "Aile hekimliðine odaklanan Týp Doktoru (MD)",
            HealthJob.ObstetricsAndGynecologyMD => "Kadýn Hastalýklarý ve Doðum odaklý Týp Doktoru (MD)",
            _ => "Belirsiz iþ",
        };
        return displayText;
    }

    public static string GetDisplay(this MarketingEconomyJob marketingEconomyJob)
    {
        string displayText = marketingEconomyJob switch
        {
            MarketingEconomyJob.EconomicsBachelor => "Ekonomi lisans derecesi",
            MarketingEconomyJob.FinanceBachelor => "Finans alanýnda lisans derecesi",
            MarketingEconomyJob.MarketingBachelor => "Pazarlama lisans derecesi",
            MarketingEconomyJob.BusinessBachelor => "Ýþletme alanýnda lisans derecesi",
            MarketingEconomyJob.InternationalBusinessBachelor => "Uluslararasý iþletme lisans derecesi",
            MarketingEconomyJob.ManagementBachelor => "Yönetim alanýnda lisans derecesi",
            MarketingEconomyJob.SupplyChainManagementBachelor => "Tedarik zinciri yönetiminde lisans derecesi",
            MarketingEconomyJob.AdvertisingBachelor => "Reklamcýlýkta lisans derecesi",
            MarketingEconomyJob.PublicRelationsBachelor => "Halkla iliþkiler alanýnda lisans derecesi",
            MarketingEconomyJob.DigitalMarketingBachelor => "Dijital pazarlama alanýnda lisans derecesi",
            _ => "Belirsiz iþ",
        };
        return displayText;
    }

    public static string GetDisplay(this EngineeringJob engineeringJob)
    {
        string displayText = engineeringJob switch
        {
            EngineeringJob.ChemicalEngineeringBachelor => "Kimya mühendisliði lisans derecesi",
            EngineeringJob.CivilEngineeringBachelor => "Ýnþaat mühendisliði lisans derecesi",
            EngineeringJob.ComputerEngineeringBachelor => "Bilgisayar mühendisliði lisans derecesi",
            EngineeringJob.ElectricalEngineeringBachelor => "Elektrik mühendisliði lisans derecesi",
            EngineeringJob.EnvironmentalEngineeringBachelor => "Çevre mühendisliði lisans derecesi",
            EngineeringJob.IndustrialEngineeringBachelor => "Endüstri mühendisliði lisans derecesi",
            EngineeringJob.MaterialEngineeringBachelor => "Malzeme mühendisliði lisans derecesi",
            EngineeringJob.MechanicalEngineeringBachelor => "Makine mühendisliði lisans derecesi",
            EngineeringJob.SoftwareEngineeringBachelor => "Yazýlým mühendisliði lisans derecesi",
            EngineeringJob.AerospaceEngineeringBachelor => "Havacýlýk ve uzay mühendisliði lisans derecesi",
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