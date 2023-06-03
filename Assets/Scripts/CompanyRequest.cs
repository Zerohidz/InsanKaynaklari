using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompanyRequest
{
    // None of these are expected with 0 elements. They should be either null or full
    public Job[] Jobs { get; set; }
    public PositiveTrait[] PositiveTraits { get; set; }
    public NegativeTrait[] NegativeTraits { get; set; }
    public bool FakeExperienceCheck { get; set; }
    public (JobField JobField, Job[] Jobs)[] JobFields => JobCriterias.JobsOfJobFields
                .Where(kv => kv.Value.Intersect(Jobs).Any())
                .Select(kv => (kv.Key, kv.Value.Intersect(Jobs).ToArray()))
                .ToArray();

    public CompanyRequest(Job[] jobs = null, PositiveTrait[] positiveTraits = null, NegativeTrait[] negativeTraits = null)
    {
        Jobs = jobs;
        PositiveTraits = positiveTraits;
        NegativeTraits = negativeTraits;
    }

    public CompanyRequest(CompanyRequest dataSource)
    {
        Jobs = dataSource.Jobs;
        PositiveTraits = dataSource.PositiveTraits;
        NegativeTraits = dataSource.NegativeTraits;
        FakeExperienceCheck = dataSource.FakeExperienceCheck;
    }
}

