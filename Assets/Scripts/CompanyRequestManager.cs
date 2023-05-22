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
            NegativeTraits = new NegativeTrait[]
            {
                NegativeTrait.Procrastination,
            },
        },
        new CompanyRequest() {
            Jobs = JobCriterias.JobsOfJobFields[JobField.Education],
        },
        new CompanyRequest() {
            Jobs = JobCriterias.JobsOfJobFields[JobField.Health],
        },
        new CompanyRequest() {
            Jobs = new Job[] {
                Job.HistoryTeacher,
                Job.MathTeacher,
                Job.BiologyTeacher,
            },
        },
        new CompanyRequest() {
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

    public void UpdateCurrentCompanyRequest(int day)
    {
        CurrentCompanyRequest = _companyRequests[day - 1];
    }
}
