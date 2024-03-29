using System.Collections.Generic;
using System.Linq;

public class CompanyRequestManager : SingletonMB<CompanyRequestManager>
{
    public CompanyRequest CurrentCompanyRequest { get; private set; }

    private List<CompanyRequest> _companyRequests;

    private List<CompanyRequest> _companyRequestsDraft = new()
    {
        new CompanyRequest() {
            Jobs = JobCriterias.JobsOfJobFields[JobField.Education],
        },
        new CompanyRequest() {
            Jobs = JobCriterias.JobsOfJobFields[JobField.Health],
            FakeExperienceCheck = true,
        },
        new CompanyRequest() {
            Jobs = new Job[] {
                Job.HistoryTeacher,
                Job.MathTeacher,
                Job.BiologyTeacher,
            },
            FakeExperienceCheck = true,
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
            },
            FakeExperienceCheck = true,
        },
        new CompanyRequest() {
            Jobs = new Job[] {
                Job.ChemicalEngineeringBachelor,
                Job.CivilEngineeringBachelor,
                Job.MechanicalEngineeringBachelor,
            },
            PositiveTraits = new PositiveTrait[]
            {
                PositiveTrait.Organized,
            },
            NegativeTraits = new NegativeTrait[]
            {
                NegativeTrait.PoorHygiene,
            },
            FakeExperienceCheck = true,
        },
    };

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed)
            return;

        GenerateCompanyRequests();
        GameController.OnDayChanged += UpdateCurrentCompanyRequest;
    }

    private void GenerateCompanyRequests()
    {
        List<CompanyRequest> companyRequests = new()
        {
            null // Start from index 1
        };

        for (int i = 0; i < _companyRequestsDraft.Count; i++)
        {
            var requestDraft = _companyRequestsDraft[i];
            var request = new CompanyRequest(requestDraft);

            // Job
            JobField[] randomJobFields = EnumHelper.GetRandomRange<JobField>(requestDraft.JobFields.Length).ToArray();
            List<Job> newJobs = new();
            for (int j = 0; j < requestDraft.JobFields.Length; j++)
            {
                newJobs.AddRange(JobCriterias.JobsOfJobFields[randomJobFields[j]].GetRandomRange(requestDraft.JobFields[j].Jobs.Length));
            }
            request.Jobs = newJobs.ToArray();

            // PositiveTraits
            if (requestDraft.PositiveTraits is not null)
                request.PositiveTraits = EnumHelper.GetRandomRange<PositiveTrait>(requestDraft.PositiveTraits.Length).ToArray();

            // NegativeTraits
            if (requestDraft.NegativeTraits is not null)
                request.NegativeTraits = EnumHelper.GetRandomRange<NegativeTrait>(requestDraft.NegativeTraits.Length).ToArray();

            companyRequests.Add(request);
        }

        _companyRequests = companyRequests;
    }

    public void UpdateCurrentCompanyRequest(int day)
    {
        CurrentCompanyRequest = _companyRequests[day];
    }
}
