using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompanyRequest
{
    // None of these are expected with 0 elements. They should be either null or full
    // TODO: Sadece jobfield verilirse Jobs'a hepsini koyuver
    public Job[] Jobs { get; set; }
    public PositiveTrait[] PositiveTraits { get; set; }
    public NegativeTrait[] NegativeTraits { get; set; }
    public JobField[] JobFields
    {
        get
        {
            return JobCriterias.JobsOfJobFields
                .Where(kv => kv.Value.Intersect(Jobs).Any())
                .Select(kv => kv.Key)
                .ToArray();
        }
    }

    public CompanyRequest(Job[] jobs = null, PositiveTrait[] positiveTraits = null, NegativeTrait[] negativeTraits = null)
    {
        Jobs = jobs;
        PositiveTraits = positiveTraits;
        NegativeTraits = negativeTraits;
    }
}
