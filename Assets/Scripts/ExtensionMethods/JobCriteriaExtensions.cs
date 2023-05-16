
// GetDisplay()'ler dictionary yerine switch kullan�yor ��nk� language support gelebilir
public static class GenderExtensions
{
    public static string GetDisplay(this Gender gender)
    {
        string displayText = gender switch
        {
            Gender.Male => "Erkek",
            Gender.Female => "Kad�n",
            _ => "Belirsiz hocam",
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
            EducationJob.Geography => "Co�rafya",
            EducationJob.History => "Tarih",
            EducationJob.PhysicalEducation => "Beden E�itimi",
            EducationJob.Physics => "Fizik",
            EducationJob.ForeignLanguage => "Yabanc� Dil",
            EducationJob.Geometry => "Geometri",
            _ => "Belirsiz i�",
        };
        return displayText;
    }

    public static string GetDisplay(this HealthJob healthJob)
    {
        string displayText = healthJob switch
        {
            HealthJob.CardiovascularMD => "Kardiyovask�ler t�bba odaklanan T�p Doktoru (MD)",
            HealthJob.InternalMedicineMD => "Dahiliye odakl� T�p Doktoru (MD)",
            HealthJob.EmergencyMedicineMD => "Acil t�p odakl� T�p Doktoru (MD)",
            HealthJob.PediatricsMD => "Pediatri odakl� T�p Doktoru (MD)",
            HealthJob.OncologyMD => "Onkoloji odakl� T�p Doktoru (MD)",
            HealthJob.PsychiatryMD => "Psikiyatri odakl� T�p Doktoru (MD)",
            HealthJob.DermatologyMD => "Dermatoloji odakl� T�p Doktoru (MD)",
            HealthJob.NeurologyMD => "N�rolojiye odaklanan T�p Doktoru (MD)",
            HealthJob.FamilyMedicineMD => "Aile hekimli�ine odaklanan T�p Doktoru (MD)",
            HealthJob.ObstetricsAndGynecologyMD => "Kad�n Hastal�klar� ve Do�um odakl� T�p Doktoru (MD)",
            _ => "Belirsiz i�",
        };
        return displayText;
    }

    public static string GetDisplay(this MarketingEconomyJob marketingEconomyJob)
    {
        string displayText = marketingEconomyJob switch
        {
            MarketingEconomyJob.EconomicsBachelor => "Ekonomi lisans derecesi",
            MarketingEconomyJob.FinanceBachelor => "Finans alan�nda lisans derecesi",
            MarketingEconomyJob.MarketingBachelor => "Pazarlama lisans derecesi",
            MarketingEconomyJob.BusinessBachelor => "��letme alan�nda lisans derecesi",
            MarketingEconomyJob.InternationalBusinessBachelor => "Uluslararas� i�letme lisans derecesi",
            MarketingEconomyJob.ManagementBachelor => "Y�netim alan�nda lisans derecesi",
            MarketingEconomyJob.SupplyChainManagementBachelor => "Tedarik zinciri y�netiminde lisans derecesi",
            MarketingEconomyJob.AdvertisingBachelor => "Reklamc�l�kta lisans derecesi",
            MarketingEconomyJob.PublicRelationsBachelor => "Halkla ili�kiler alan�nda lisans derecesi",
            MarketingEconomyJob.DigitalMarketingBachelor => "Dijital pazarlama alan�nda lisans derecesi",
            _ => "Belirsiz i�",
        };
        return displayText;
    }

    public static string GetDisplay(this EngineeringJob engineeringJob)
    {
        string displayText = engineeringJob switch
        {
            EngineeringJob.ChemicalEngineeringBachelor => "Kimya m�hendisli�i lisans derecesi",
            EngineeringJob.CivilEngineeringBachelor => "�n�aat m�hendisli�i lisans derecesi",
            EngineeringJob.ComputerEngineeringBachelor => "Bilgisayar m�hendisli�i lisans derecesi",
            EngineeringJob.ElectricalEngineeringBachelor => "Elektrik m�hendisli�i lisans derecesi",
            EngineeringJob.EnvironmentalEngineeringBachelor => "�evre m�hendisli�i lisans derecesi",
            EngineeringJob.IndustrialEngineeringBachelor => "End�stri m�hendisli�i lisans derecesi",
            EngineeringJob.MaterialEngineeringBachelor => "Malzeme m�hendisli�i lisans derecesi",
            EngineeringJob.MechanicalEngineeringBachelor => "Makine m�hendisli�i lisans derecesi",
            EngineeringJob.SoftwareEngineeringBachelor => "Yaz�l�m m�hendisli�i lisans derecesi",
            EngineeringJob.AerospaceEngineeringBachelor => "Havac�l�k ve uzay m�hendisli�i lisans derecesi",
            _ => "Belirsiz i�",
        };
        return displayText;
    }

    public static string GetDisplay(this PositiveTrait positiveTrait)
    {
        string displayText = positiveTrait switch
        {
            PositiveTrait.Thorough => "Titiz",
            PositiveTrait.Optimistic => "�yimser",
            PositiveTrait.Punctual => "Dakiklik",
            PositiveTrait.Enterprising => "Giri�kenlik",
            PositiveTrait.Organized => "D�zen, Tertip",
            PositiveTrait.Professional => "Profesyonellik",
            PositiveTrait.TeamPlayer => "Tak�m �al��mac�s�",
            PositiveTrait.Responsible => "Sorumluluk Sahibi",
            PositiveTrait.HighCommunicationSkill => "Y�ksek �leti�im Kabiliyeti",
            PositiveTrait.Adaptable => "Uyum Sa�layabilme, Esneklik",
            _ => "Belirsiz �zellik",
        };
        return displayText;
    }

    public static string GetDisplay(this NegativeTrait negativeTrait)
    {
        string displayText = negativeTrait switch
        {
            NegativeTrait.PoorHygiene => "K�t� ki�isel hijyen veya bak�m",
            NegativeTrait.Procrastination => "Erteleme veya zay�f zaman y�netimi",
            NegativeTrait.ChronicTardiness => "S�rekli ge� kalma veya devams�zl�k",
            NegativeTrait.DisrespectfulLanguage => "Sayg�s�z veya uygunsuz dil veya davran��",
            NegativeTrait.DishonestBehavior => "D�r�st olmayan veya etik olmayan davran��",
            NegativeTrait.PoorCooperation => "��birli�i i�inde �al��amama veya etkili ileti�im kuramama",
            NegativeTrait.LackOfAccountability => "Ki�inin i�i i�in hesap verebilirlik veya sorumluluk eksikli�i",
            NegativeTrait.NegativeAttitude => "Meslekta�lara veya m��terilere kar�� olumsuz tutum veya davran��",
            NegativeTrait.NoncomplianceWithCompanyPolicy => "�irket politikalar�na veya prosed�rlerine itaatsizlik veya meydan okuma",
            NegativeTrait.ExcessiveUseOfPersonalDevices => "�al��ma saatlerinde ki�isel cihazlar�n veya sosyal medyan�n a��r� kullan�m�.",
            _ => "Belirsiz �zellik",
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
            _ => "Belirsiz politik g�r��",
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
            _ => "Belirsiz din",
        };
        return displayText;
    }
}