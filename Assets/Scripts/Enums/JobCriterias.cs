using System;
using System.Collections.Generic;

public static class JobCriterias
{
    public static readonly Range AgeRange = new(25, 45);
    public static readonly Range ExperienceYearsRange = new(0, 20);

    public static readonly Dictionary<JobField, Type> JobFields = new() {
        {JobField.Education, typeof(EducationJob)},
        {JobField.Health, typeof(HealthJob)},
        {JobField.MarketingAndEconomics, typeof(MarketingEconomyJob)},
        {JobField.Engineering, typeof(EngineeringJob)},
    };
}

public enum Race
{
    Russsian,
    Turkish,
    Arab,
    German,
    American,
}

public enum Gender
{
    Male,
    Female,
}

public enum JobField
{
    Education,
    Health,
    MarketingAndEconomics,
    Engineering,
}

public enum EducationJob
{
    Math,
    Biology,
    Chemistry,
    Literature,
    Geography,
    History,
    PhysicalEducation,
    Physics,
    ForeignLanguage,
    Geometry,
}

public enum HealthJob
{
    CardiovascularMD,
    InternalMedicineMD,
    EmergencyMedicineMD,
    PediatricsMD,
    OncologyMD,
    PsychiatryMD,
    DermatologyMD,
    NeurologyMD,
    FamilyMedicineMD,
    ObstetricsAndGynecologyMD,
}

public enum MarketingEconomyJob
{
    EconomicsBachelor,
    FinanceBachelor,
    MarketingBachelor,
    BusinessBachelor,
    InternationalBusinessBachelor,
    ManagementBachelor,
    SupplyChainManagementBachelor,
    AdvertisingBachelor,
    PublicRelationsBachelor,
    DigitalMarketingBachelor,
}

public enum EngineeringJob
{
    ChemicalEngineeringBachelor,
    CivilEngineeringBachelor,
    ComputerEngineeringBachelor,
    ElectricalEngineeringBachelor,
    EnvironmentalEngineeringBachelor,
    IndustrialEngineeringBachelor,
    MaterialEngineeringBachelor,
    MechanicalEngineeringBachelor,
    SoftwareEngineeringBachelor,
    AerospaceEngineeringBachelor,
}

public enum PositiveTrait
{
    Thorough,
    Optimistic,
    Punctual,
    Enterprising,
    Organized,
    Professional,
    TeamPlayer,
    Responsible,
    HighCommunicationSkill,
    Adaptable,
}

public enum NegativeTrait
{
    PoorHygiene,
    Procrastination,
    ChronicTardiness,
    DisrespectfulLanguage,
    DishonestBehavior,
    PoorCooperation,
    LackOfAccountability,
    NegativeAttitude,
    NoncomplianceWithCompanyPolicy,
    ExcessiveUseOfPersonalDevices,
}

public enum PoliticView
{
    Liberalism,
    Conservatism,
    Socialism,
    Capitalism,
    Anarchism,
    Fascism,
    Communism,
    Nationalism,
}

public enum Religion
{
    Christianity,
    Islam,
    Judaism,
    Buddhism,
    Hinduism,
    Atheism,
    Deism,
    Agnosticism,
}