using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

public static class JobCriterias
{
    public static readonly Range AgeRange = new(22, 36);
    public static readonly int MinimumJobYear = 22;

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

    public static JobField GetJobFieldOfJob(Job job)
    {
        return JobsOfJobFields.Where(kv => kv.Value.Contains(job)).First().Key;
    }

    public static NegativeTrait[] GetAvailableNegativeTraits(PositiveTrait[] positiveTraits)
    {
        List<NegativeTrait> allNegativeTraits = EnumHelper.GetValues<NegativeTrait>().ToList();
        foreach (var pair in IncompatibleTraits)
        {
            if (positiveTraits.Contains(pair.Item1))
                allNegativeTraits.Remove(pair.Item2);
        }

        return allNegativeTraits.ToArray();
    }

    public static PositiveTrait[] GetAvailablePositiveTraits(NegativeTrait[] negativeTraits)
    {
        List<PositiveTrait> allPositiveTraits = EnumHelper.GetValues<PositiveTrait>().ToList();
        foreach (var pair in IncompatibleTraits)
        {
            if (negativeTraits.Contains(pair.Item2))
                allPositiveTraits.Remove(pair.Item1);
        }

        return allPositiveTraits.ToArray();
    }

    public static readonly (PositiveTrait, NegativeTrait)[] IncompatibleTraits = {
        (PositiveTrait.Punctual, NegativeTrait.Procrastination),
        (PositiveTrait.Organized, NegativeTrait.PoorHygiene),
        (PositiveTrait.Adaptable,NegativeTrait.PoorCooperation),
        (PositiveTrait.Responsible,NegativeTrait.NoncomplianceWithCompanyPolicy),
        (PositiveTrait.Responsible,NegativeTrait.Procrastination),
    };

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
        Job.OrthopedicMD,
        Job.OphthalmologistMD,
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
    OrthopedicMD,
    OphthalmologistMD,

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
    Punctual,
    Organized,
    Adaptable,
    Enterprising,
    Responsible,
}

public enum NegativeTrait
{
    DisrespectfulLanguage,
    PoorHygiene,
    NoncomplianceWithCompanyPolicy,
    Procrastination,
    PoorCooperation,
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