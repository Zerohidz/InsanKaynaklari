using System;
using System.Collections.Generic;

public static class JobCriterias
{
    public static readonly Range AgeRange = new(25, 46);
    public static readonly Range ExperienceYearsRange = new(0, 21);

    public static readonly Dictionary<JobField, Job[]> JobsOfJobFields;

    static JobCriterias()
    {
        JobsOfJobFields = new() {
            {JobField.Education, EducationJobs},
            {JobField.Health, HealthJobs},
            {JobField.MarketingAndEconomics, MarketingEconomyJobs},
            {JobField.Engineering, EngineeringJobs},
        };
    }

    public static readonly Job[] EducationJobs = {
        Job.MathTeacher,
        Job.BiologyTeacher,
        Job.ChemistryTeacher,
        Job.LiteratureTeacher,
        Job.GeographyTeacher,
        Job.HistoryTeacher,
        Job.PhysicalEducationTeacher,
        Job.PhysicsTeacher,
        Job.ForeignLanguageTeacher,
        Job.GeometryTeacher,
    };

    public static readonly Job[] HealthJobs = {
        Job.CardiovascularMD,
        Job.InternalMedicineMD,
        Job.EmergencyMedicineMD,
        Job.PediatricsMD,
        Job.OncologyMD,
        Job.PsychiatryMD,
        Job.DermatologyMD,
        Job.NeurologyMD,
        Job.FamilyMedicineMD,
        Job.ObstetricsAndGynecologyMD,
    };


    public static readonly Job[] MarketingEconomyJobs =
    {
        Job.EconomicsBachelor,
        Job.FinanceBachelor,
        Job.MarketingBachelor,
        Job.BusinessBachelor,
        Job.InternationalBusinessBachelor,
        Job.ManagementBachelor,
        Job.SupplyChainManagementBachelor,
        Job.AdvertisingBachelor,
        Job.PublicRelationsBachelor,
        Job.DigitalMarketingBachelor,
    };

    public static readonly Job[] EngineeringJobs =
    {
        Job.ChemicalEngineeringBachelor,
        Job.CivilEngineeringBachelor,
        Job.ComputerEngineeringBachelor,
        Job.ElectricalEngineeringBachelor,
        Job.EnvironmentalEngineeringBachelor,
        Job.IndustrialEngineeringBachelor,
        Job.MaterialEngineeringBachelor,
        Job.MechanicalEngineeringBachelor,
        Job.SoftwareEngineeringBachelor,
        Job.AerospaceEngineeringBachelor,
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

public enum Job
{
    MathTeacher,
    BiologyTeacher,
    ChemistryTeacher,
    LiteratureTeacher,
    GeographyTeacher,
    HistoryTeacher,
    PhysicalEducationTeacher,
    PhysicsTeacher,
    ForeignLanguageTeacher,
    GeometryTeacher,

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