
// GetDisplay()'ler dictionary yerine switch kullan�yor ��nk� language support gelebilir
public static class GenderExtensions
{
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

            Job.CardiovascularMD => "Kardiyovask�ler t�bba odaklanan T�p Doktoru (MD)",
            Job.InternalMedicineMD => "Dahiliye odakl� T�p Doktoru (MD)",
            Job.EmergencyMedicineMD => "Acil t�p odakl� T�p Doktoru (MD)",
            Job.PediatricsMD => "Pediatri odakl� T�p Doktoru (MD)",
            Job.OncologyMD => "Onkoloji odakl� T�p Doktoru (MD)",
            Job.PsychiatryMD => "Psikiyatri odakl� T�p Doktoru (MD)",
            Job.DermatologyMD => "Dermatoloji odakl� T�p Doktoru (MD)",
            Job.NeurologyMD => "N�rolojiye odaklanan T�p Doktoru (MD)",
            Job.FamilyMedicineMD => "Aile hekimli�ine odaklanan T�p Doktoru (MD)",
            Job.ObstetricsAndGynecologyMD => "Kad�n Hastal�klar� ve Do�um odakl� T�p Doktoru (MD)",

            Job.EconomicsBachelor => "Ekonomi lisans derecesi",
            Job.FinanceBachelor => "Finans alan�nda lisans derecesi",
            Job.MarketingBachelor => "Pazarlama lisans derecesi",
            Job.BusinessBachelor => "��letme alan�nda lisans derecesi",
            Job.InternationalBusinessBachelor => "Uluslararas� i�letme lisans derecesi",
            Job.ManagementBachelor => "Y�netim alan�nda lisans derecesi",
            Job.SupplyChainManagementBachelor => "Tedarik zinciri y�netiminde lisans derecesi",
            Job.AdvertisingBachelor => "Reklamc�l�kta lisans derecesi",
            Job.PublicRelationsBachelor => "Halkla ili�kiler alan�nda lisans derecesi",
            Job.DigitalMarketingBachelor => "Dijital pazarlama alan�nda lisans derecesi",

            Job.ChemicalEngineeringBachelor => "Kimya m�hendisli�i lisans derecesi",
            Job.CivilEngineeringBachelor => "�n�aat m�hendisli�i lisans derecesi",
            Job.ComputerEngineeringBachelor => "Bilgisayar m�hendisli�i lisans derecesi",
            Job.ElectricalEngineeringBachelor => "Elektrik m�hendisli�i lisans derecesi",
            Job.EnvironmentalEngineeringBachelor => "�evre m�hendisli�i lisans derecesi",
            Job.IndustrialEngineeringBachelor => "End�stri m�hendisli�i lisans derecesi",
            Job.MaterialEngineeringBachelor => "Malzeme m�hendisli�i lisans derecesi",
            Job.MechanicalEngineeringBachelor => "Makine m�hendisli�i lisans derecesi",
            Job.SoftwareEngineeringBachelor => "Yaz�l�m m�hendisli�i lisans derecesi",
            Job.AerospaceEngineeringBachelor => "Havac�l�k ve uzay m�hendisli�i lisans derecesi",

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