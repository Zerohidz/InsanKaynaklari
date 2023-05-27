
// GetDisplay()'ler dictionary yerine switch kullanýyor çünkü language support gelebilir
public static class GenderExtensions
{
    public static string GetDisplay(this (JobField JobField, Job[] Jobs)[] jobFields)
    {
        string displayText = "";
        foreach (var (jobField, jobs) in jobFields)
        {
            displayText += $"• {jobField.GetDisplay()} sektöründen alým yapýlacak.\n";
        }
        return displayText.TrimEnd('\n');
    }

    public static string GetDisplay(this Gender gender)
    {
        string displayText = gender switch
        {
            Gender.Male => "Erkek",
            Gender.Female => "Kadýn",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplayAsYears(this int years)
    {
        return years.ToString() + " Yýl";
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
            JobField.Education => "Eðitim",
            JobField.Health => "Saðlýk",
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
            Job.MathTeacher => "Matematik Öðretmeni",
            Job.BiologyTeacher => "Biyoloji Öðretmeni",
            Job.ChemistryTeacher => "Kimya Öðretmeni",
            Job.LiteratureTeacher => "Edebiyat Öðretmeni",
            Job.GeographyTeacher => "Coðrafya Öðretmeni",
            Job.HistoryTeacher => "Tarih Öðretmeni",
            Job.PhysicalEducationTeacher => "Beden Eðitimi Öðretmeni",
            Job.PhysicsTeacher => "Fizik Öðretmeni",
            Job.ForeignLanguageTeacher => "Yabancý Dil Öðretmeni",
            Job.GeometryTeacher => "Geometri Öðretmeni",

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
            PositiveTrait.Enterprising => "Giriþkenlik",
            PositiveTrait.Responsible => "Sorumluluk Sahibi",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this NegativeTrait negativeTrait)
    {
        string displayText = negativeTrait switch
        {
            NegativeTrait.DisrespectfulLanguage => "Saygýsýz veya uygunsuz dil veya davranýþ",
            NegativeTrait.PoorHygiene => "Kötü kiþisel hijyen veya bakým",
            NegativeTrait.NoncomplianceWithCompanyPolicy => "Þirket politikalarýna veya prosedürlerine itaatsizlik veya meydan okuma",
            NegativeTrait.Procrastination => "Erteleme veya zayýf zaman yönetimi",
            NegativeTrait.PoorCooperation => "Ýþbirliði içinde çalýþamama veya etkili iletiþim kuramama",
            _ => "",
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
            _ => "",
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
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this Job[] jobs)
    {
        string displayText = "";
        foreach (var job in jobs)
        {
            displayText += $"• {job.GetDisplay()}\n";
        }
        return displayText.TrimEnd('\n');
    }

    public static string GetDisplay(this PositiveTrait[] traits)
    {
        string displayText = "";
        foreach (var trait in traits)
        {
            displayText += $"• {trait.GetDisplay()}\n";
        }
        return displayText.TrimEnd('\n');
    }

    public static string GetDisplay(this NegativeTrait[] traits)
    {
        string displayText = "";
        foreach (var trait in traits)
        {
            displayText += $"• {trait.GetDisplay()}\n";
        }
        return displayText.TrimEnd('\n');
    }
}