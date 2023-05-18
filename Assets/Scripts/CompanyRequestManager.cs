using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyRequestManager : SingletonMB<CompanyRequestManager>
{
    public CompanyRequest CurrentCompanyRequest { get; private set; }

    // TODO: Prototip için geçici liste
    private List<CompanyRequest> _companyRequests = new List<CompanyRequest>()
    {
        new CompanyRequest() {
            JobFields = new JobField[] { JobField.Education },
        },
        new CompanyRequest() {
            JobFields = new JobField[] { JobField.Health },
        },
        new CompanyRequest() {
            JobFields = new JobField[] { JobField.Education },
            Jobs = new Job[] {
                Job.HistoryTeacher,
                Job.MathTeacher,
                Job.BiologyTeacher,
            },
        },
        new CompanyRequest() {
            JobFields = new JobField[] { JobField.Engineering },
            Jobs = new Job[] {
                Job.ChemicalEngineeringBachelor,
                Job.CivilEngineeringBachelor,
                Job.MechanicalEngineeringBachelor,
            },
            PositiveTraits = new PositiveTrait[]
            {
                PositiveTrait.Punctual,
                PositiveTrait.Thorough,
            },
        },
        new CompanyRequest() {
            JobFields = new JobField[] { JobField.MarketingAndEconomics },
            Jobs = new Job[] {
                Job.ChemicalEngineeringBachelor,
                Job.CivilEngineeringBachelor,
                Job.MechanicalEngineeringBachelor,
            },
            PositiveTraits = new PositiveTrait[]
            {
                PositiveTrait.Professional,
            },
            NegativeTraits = new NegativeTrait[]
            {
                NegativeTrait.PoorHygiene,
                NegativeTrait.Procrastination,
            },
        },
    };

    protected override void Awake()
    {
        base.Awake();
        GameController.OnDayChanged += UpdateCurrentCompanyRequest;
    }

    public void UpdateCurrentCompanyRequest()
    {
        CurrentCompanyRequest = _companyRequests[GameController.Instance.Day - 1];
    }
}
