using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyRequest
{
    // None of these are expected with 0 elements. They should be either null or full
    public Job[] Jobs { get; set; }
    public JobField[] JobFields { get; set; }
    public PositiveTrait[] PositiveTraits { get; set; }
    public NegativeTrait[] NegativeTraits { get; set; }

    public CompanyRequest(Job[] jobs = null, JobField[] jobFields = null, PositiveTrait[] positiveTraits = null, NegativeTrait[] negativeTraits = null)
    {
        Jobs = jobs;
        JobFields = jobFields;
        PositiveTraits = positiveTraits;
        NegativeTraits = negativeTraits;
    }
}
