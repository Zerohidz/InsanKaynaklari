
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

            Job.CardiovascularMD => "Kalp Doktoru",
            Job.InternalMedicineMD => "Dahiliye Doktoru",
            Job.EmergencyMedicineMD => "Acil Doktoru",
            Job.PediatricsMD => "Çocuk Doktoru",
            Job.NeurologyMD => "Nöroloji Doktoru",
            Job.OncologyMD => "Onkoloji Doktoru",
            Job.PsychiatryMD => "Psikiyatri Doktoru",
            Job.OrthopedicMD => "Ortopedi Doktoru",
            Job.DermatologyMD => "Cildiye Doktoru",
            Job.OphthalmologistMD => "Göz Doktoru",

            Job.EconomicsBachelor => "Pazarlama Lisansý",
            Job.FinanceBachelor => "Ýþletme Lisansý",
            Job.MarketingBachelor => "Ekonomi Lisansý",
            Job.BusinessBachelor => "Finans Lisansý",
            Job.InternationalBusinessBachelor => "Uluslararasý Ýþletme Lisansý",
            Job.ManagementBachelor => "Yönetim Lisansý",
            Job.SupplyChainManagementBachelor => "Lojistik Lisansý",
            Job.AdvertisingBachelor => "Reklamcýlýk Lisansý",
            Job.PublicRelationsBachelor => "Halkla Ýliþkiler Lisansý",
            Job.DigitalMarketingBachelor => "Dijital Pazarlama Lisansý",

            Job.ChemicalEngineeringBachelor => "Kimya Mühendisi",
            Job.CivilEngineeringBachelor => "Ýnþaat Mühendisi",
            Job.ComputerEngineeringBachelor => "Bilgisayar Mühendisi",
            Job.ElectricalEngineeringBachelor => "Elektrik Mühendisi",
            Job.EnvironmentalEngineeringBachelor => "Çevre Mühendisi",
            Job.IndustrialEngineeringBachelor => "Endüstri Mühendisi",
            Job.MaterialEngineeringBachelor => "Malzeme Mühendisi",
            Job.MechanicalEngineeringBachelor => "Makine Mühendisi",
            Job.SoftwareEngineeringBachelor => "Yazýlým Mühendisi",
            Job.AerospaceEngineeringBachelor => "Uçak Mühendisi",

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