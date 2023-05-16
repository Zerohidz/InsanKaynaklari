using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyRequest : MonoBehaviour
{
    public Job[] Jobs { get; set; }
    public JobField[] JobFields { get; set; }
    public PositiveTrait[] PositiveTraits { get; set; }
    public NegativeTrait[] NegativeTraits { get; set; }
}
