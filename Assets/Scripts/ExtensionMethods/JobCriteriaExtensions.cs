
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

    public static string GetDisplay(this Job job)
    {
        string displayText = job switch
        {
            Job.Math => "Matematik",
            Job.Biology => "Biyoloji",
            Job.Chemistry => "Kimya",
            Job.Literature => "Edebiyat",
            Job.Geography => "Co�rafya",
            Job.History => "Tarih",
            Job.PhysicalEducation => "Beden E�itimi",
            Job.Physics => "Fizik",
            Job.ForeignLanguage => "Yabanc� Dil",
            Job.Geometry => "Geometri",

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