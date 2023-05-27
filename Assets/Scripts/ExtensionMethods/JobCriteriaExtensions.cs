
// GetDisplay()'ler dictionary yerine switch kullanıyor çünkü language support gelebilir
public static class GenderExtensions
{
    public static string GetDisplay(this Gender gender)
    {
        string displayText = gender switch
        {
            Gender.Male => "Erkek",
            Gender.Female => "Kadın",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplayAsYears(this int years)
    {
        return years.ToString() + " Yıl";
    }

    public static string GetDisplay(this Race race)
    {
        string displayText = race switch
        {
            Race.Russsian => "Rus",
            Race.Turkish => "Türk",
            Race.Arab => "Arap",
            Race.German => "Alman",
            Race.American => "Amerikan",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this JobField jobField)
    {
        string displayText = jobField switch
        {
            JobField.Education => "Eğitim",
            JobField.Health => "Sağlık",
            JobField.MarketingAndEconomics => "Pazarlama ve Ekonomi",
            JobField.Engineering => "Mühendislik",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this Job job)
    {
        string displayText = job switch
        {
            Job.MathTeacher => "Matematik Öğretmeni",
            Job.BiologyTeacher => "Biyoloji Öğretmeni",
            Job.ChemistryTeacher => "Kimya Öğretmeni",
            Job.LiteratureTeacher => "Edebiyat Öğretmeni",
            Job.GeographyTeacher => "Coğrafya Öğretmeni",
            Job.HistoryTeacher => "Tarih Öğretmeni",
            Job.PhysicalEducationTeacher => "Beden Eğitimi Öğretmeni",
            Job.PhysicsTeacher => "Fizik Öğretmeni",
            Job.ForeignLanguageTeacher => "Yabancı Dil Öğretmeni",
            Job.GeometryTeacher => "Geometri Öğretmeni",

            Job.CardiovascularMD => "Kardiyovasküler tıbba odaklanan Tıp Doktoru (MD)",
            Job.InternalMedicineMD => "Dahiliye odaklı Tıp Doktoru (MD)",
            Job.EmergencyMedicineMD => "Acil tıp odaklı Tıp Doktoru (MD)",
            Job.PediatricsMD => "Pediatri odaklı Tıp Doktoru (MD)",
            Job.OncologyMD => "Onkoloji odaklı Tıp Doktoru (MD)",
            Job.PsychiatryMD => "Psikiyatri odaklı Tıp Doktoru (MD)",
            Job.DermatologyMD => "Dermatoloji odaklı Tıp Doktoru (MD)",
            Job.NeurologyMD => "Nörolojiye odaklanan Tıp Doktoru (MD)",
            Job.FamilyMedicineMD => "Aile hekimliğine odaklanan Tıp Doktoru (MD)",
            Job.ObstetricsAndGynecologyMD => "Kadın Hastalıkları ve Doğum odaklı Tıp Doktoru (MD)",

            Job.EconomicsBachelor => "Ekonomi lisans derecesi",
            Job.FinanceBachelor => "Finans alanında lisans derecesi",
            Job.MarketingBachelor => "Pazarlama lisans derecesi",
            Job.BusinessBachelor => "İşletme alanında lisans derecesi",
            Job.InternationalBusinessBachelor => "Uluslararası işletme lisans derecesi",
            Job.ManagementBachelor => "Yönetim alanında lisans derecesi",
            Job.SupplyChainManagementBachelor => "Tedarik zinciri yönetiminde lisans derecesi",
            Job.AdvertisingBachelor => "Reklamcılıkta lisans derecesi",
            Job.PublicRelationsBachelor => "Halkla ilişkiler alanında lisans derecesi",
            Job.DigitalMarketingBachelor => "Dijital pazarlama alanında lisans derecesi",

            Job.ChemicalEngineeringBachelor => "Kimya mühendisliği lisans derecesi",
            Job.CivilEngineeringBachelor => "İnşaat mühendisliği lisans derecesi",
            Job.ComputerEngineeringBachelor => "Bilgisayar mühendisliği lisans derecesi",
            Job.ElectricalEngineeringBachelor => "Elektrik mühendisliği lisans derecesi",
            Job.EnvironmentalEngineeringBachelor => "Çevre mühendisliği lisans derecesi",
            Job.IndustrialEngineeringBachelor => "Endüstri mühendisliği lisans derecesi",
            Job.MaterialEngineeringBachelor => "Malzeme mühendisliği lisans derecesi",
            Job.MechanicalEngineeringBachelor => "Makine mühendisliği lisans derecesi",
            Job.SoftwareEngineeringBachelor => "Yazılım mühendisliği lisans derecesi",
            Job.AerospaceEngineeringBachelor => "Havacılık ve uzay mühendisliği lisans derecesi",

            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this PositiveTrait positiveTrait)
    {
        string displayText = positiveTrait switch
        {
            PositiveTrait.Punctual => "Dakiklik",
            PositiveTrait.Organized => "Düzen, Tertip",
            PositiveTrait.Adaptable => "Esneklik",
            PositiveTrait.Enterprising => "Girişkenlik",
            PositiveTrait.Responsible => "Sorumluluk Sahibi",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this NegativeTrait negativeTrait)
    {
        string displayText = negativeTrait switch
        {
            NegativeTrait.DisrespectfulLanguage => "Saygısız veya uygunsuz dil veya davranış",
            NegativeTrait.PoorHygiene => "Kötü kişisel hijyen veya bakım",
            NegativeTrait.NoncomplianceWithCompanyPolicy => "Şirket politikalarına veya prosedürlerine itaatsizlik veya meydan okuma",
            NegativeTrait.Procrastination => "Erteleme veya zayıf zaman yönetimi",
            NegativeTrait.PoorCooperation => "İşbirliği içinde çalışamama veya etkili iletişim kuramama",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this PoliticView politicView)
    {
        string displayText = politicView switch
        {
            PoliticView.Liberalism => "Liberalizm",
            PoliticView.Conservatism => "Muhafazakarlık",
            PoliticView.Socialism => "Sosyalizm",
            PoliticView.Capitalism => "Kapitalizm",
            PoliticView.Anarchism => "Anarşizm",
            PoliticView.Fascism => "Faşizm",
            PoliticView.Communism => "Komünizm",
            PoliticView.Nationalism => "Milliyetçilik",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this Religion religion)
    {
        string displayText = religion switch
        {
            Religion.Christianity => "Hıristiyanlık",
            Religion.Islam => "İslâm",
            Religion.Judaism => "Yahudilik",
            Religion.Buddhism => "Budizm",
            Religion.Hinduism => "Hinduizm",
            Religion.Atheism => "Ateizm",
            Religion.Deism => "Deizm",
            Religion.Agnosticism => "Agnostisizm",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this PositiveTrait[] traits)
    {
        string displayText = "";
        foreach (var trait in traits)
        {
            displayText += $"-> {trait.GetDisplay()}\n";
        }
        return displayText.TrimEnd('\n');
    }

    public static string GetDisplay(this NegativeTrait[] traits)
    {
        string displayText = "";
        foreach (var trait in traits)
        {
            displayText += $"-> {trait.GetDisplay()}\n";
        }
        return displayText.TrimEnd('\n');
    }
}