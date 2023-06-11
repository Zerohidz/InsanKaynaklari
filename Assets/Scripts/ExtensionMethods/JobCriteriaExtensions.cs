
// GetDisplay()'ler dictionary yerine switch kullan�yor ��nk� language support gelebilir
public static class GenderExtensions
{
    public static string GetDisplay(this (JobField JobField, Job[] Jobs)[] jobFields)
    {
        string displayText = "";
        foreach (var (jobField, jobs) in jobFields)
        {
            displayText += $"� {jobField.GetDisplay()} sekt�r�nden al�m yap�lacak.\n";
        }
        return displayText.TrimEnd('\n');
    }

    public static string GetDisplay(this Gender gender)
    {
        string displayText = gender switch
        {
            Gender.Male => "Erkek",
            Gender.Female => "Kad�n",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplayAsYears(this int years)
    {
        return years.ToString() + " Y�l";
    }

    public static string GetDisplay(this Race race)
    {
        string displayText = race switch
        {
            Race.Russsian => "Rus",
            Race.Turkish => "T�rk",
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
            JobField.Education => "E�itim",
            JobField.Health => "Sa�l�k",
            JobField.MarketingAndEconomics => "Pazarlama ve Ekonomi",
            JobField.Engineering => "M�hendislik",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this Job job)
    {
        string displayText = job switch
        {
            Job.MathTeacher => "Matematik ��retmeni",
            Job.BiologyTeacher => "Biyoloji ��retmeni",
            Job.ChemistryTeacher => "Kimya ��retmeni",
            Job.LiteratureTeacher => "Edebiyat ��retmeni",
            Job.GeographyTeacher => "Co�rafya ��retmeni",
            Job.HistoryTeacher => "Tarih ��retmeni",
            Job.PhysicalEducationTeacher => "Beden E�itimi ��retmeni",
            Job.PhysicsTeacher => "Fizik ��retmeni",
            Job.ForeignLanguageTeacher => "Yabanc� Dil ��retmeni",
            Job.GeometryTeacher => "Geometri ��retmeni",

            Job.CardiovascularMD => "Kalp Doktoru",
            Job.InternalMedicineMD => "Dahiliye Doktoru",
            Job.EmergencyMedicineMD => "Acil Doktoru",
            Job.PediatricsMD => "�ocuk Doktoru",
            Job.NeurologyMD => "N�roloji Doktoru",
            Job.OncologyMD => "Onkoloji Doktoru",
            Job.PsychiatryMD => "Psikiyatri Doktoru",
            Job.OrthopedicMD => "Ortopedi Doktoru",
            Job.DermatologyMD => "Cildiye Doktoru",
            Job.OphthalmologistMD => "G�z Doktoru",

            Job.EconomicsBachelor => "Pazarlama Lisans�",
            Job.FinanceBachelor => "��letme Lisans�",
            Job.MarketingBachelor => "Ekonomi Lisans�",
            Job.BusinessBachelor => "Finans Lisans�",
            Job.InternationalBusinessBachelor => "Uluslararas� ��letme Lisans�",
            Job.ManagementBachelor => "Y�netim Lisans�",
            Job.SupplyChainManagementBachelor => "Lojistik Lisans�",
            Job.AdvertisingBachelor => "Reklamc�l�k Lisans�",
            Job.PublicRelationsBachelor => "Halkla �li�kiler Lisans�",
            Job.DigitalMarketingBachelor => "Dijital Pazarlama Lisans�",

            Job.ChemicalEngineeringBachelor => "Kimya M�hendisi",
            Job.CivilEngineeringBachelor => "�n�aat M�hendisi",
            Job.ComputerEngineeringBachelor => "Bilgisayar M�hendisi",
            Job.ElectricalEngineeringBachelor => "Elektrik M�hendisi",
            Job.EnvironmentalEngineeringBachelor => "�evre M�hendisi",
            Job.IndustrialEngineeringBachelor => "End�stri M�hendisi",
            Job.MaterialEngineeringBachelor => "Malzeme M�hendisi",
            Job.MechanicalEngineeringBachelor => "Makine M�hendisi",
            Job.SoftwareEngineeringBachelor => "Yaz�l�m M�hendisi",
            Job.AerospaceEngineeringBachelor => "U�ak M�hendisi",

            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this PositiveTrait positiveTrait)
    {
        string displayText = positiveTrait switch
        {
            PositiveTrait.Punctual => "Dakiklik",
            PositiveTrait.Organized => "D�zen, Tertip",
            PositiveTrait.Adaptable => "Esneklik",
            PositiveTrait.Enterprising => "Giri�kenlik",
            PositiveTrait.Responsible => "Sorumluluk Sahibi",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this NegativeTrait negativeTrait)
    {
        string displayText = negativeTrait switch
        {
            NegativeTrait.DisrespectfulLanguage => "Sayg�s�z veya uygunsuz dil veya davran��",
            NegativeTrait.PoorHygiene => "K�t� ki�isel hijyen veya bak�m",
            NegativeTrait.NoncomplianceWithCompanyPolicy => "�irket politikalar�na veya prosed�rlerine itaatsizlik veya meydan okuma",
            NegativeTrait.Procrastination => "Erteleme veya zay�f zaman y�netimi",
            NegativeTrait.PoorCooperation => "��birli�i i�inde �al��amama veya etkili ileti�im kuramama",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this PoliticView politicView)
    {
        string displayText = politicView switch
        {
            PoliticView.Liberalism => "Liberalizm",
            PoliticView.Conservatism => "Muhafazakarl�k",
            PoliticView.Socialism => "Sosyalizm",
            PoliticView.Capitalism => "Kapitalizm",
            PoliticView.Anarchism => "Anar�izm",
            PoliticView.Fascism => "Fa�izm",
            PoliticView.Communism => "Kom�nizm",
            PoliticView.Nationalism => "Milliyet�ilik",
            _ => "",
        };
        return displayText;
    }

    public static string GetDisplay(this Religion religion)
    {
        string displayText = religion switch
        {
            Religion.Christianity => "H�ristiyanl�k",
            Religion.Islam => "�sl�m",
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
            displayText += $"� {job.GetDisplay()}\n";
        }
        return displayText.TrimEnd('\n');
    }

    public static string GetDisplay(this PositiveTrait[] traits)
    {
        string displayText = "";
        foreach (var trait in traits)
        {
            displayText += $"� {trait.GetDisplay()}\n";
        }
        return displayText.TrimEnd('\n');
    }

    public static string GetDisplay(this NegativeTrait[] traits)
    {
        string displayText = "";
        foreach (var trait in traits)
        {
            displayText += $"� {trait.GetDisplay()}\n";
        }
        return displayText.TrimEnd('\n');
    }
}