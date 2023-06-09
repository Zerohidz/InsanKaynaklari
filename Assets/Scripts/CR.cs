using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Used to visualize the information inside a Company Request Object
/// </summary>
public class CR : MonoBehaviour
{
    public TextMeshProUGUI JobFields;
    public TextMeshProUGUI Jobs;
    public TextMeshProUGUI PositiveTraits;
    public TextMeshProUGUI NegativeTraits;

    public TextMeshProUGUI JobsHeader;
    public TextMeshProUGUI PositiveTraitsHeader;
    public TextMeshProUGUI NegativeTraitsHeader;

    public void SetInfo(CompanyRequest companyRequest)
    {
        JobFields?.SetText(companyRequest.JobFields?.GetDisplay());
        Jobs?.SetText(companyRequest.Jobs?.GetDisplay());
        PositiveTraits?.SetText(companyRequest.PositiveTraits?.GetDisplay());
        NegativeTraits?.SetText(companyRequest.NegativeTraits?.GetDisplay());

        JobsHeader?.gameObject.SetActive(companyRequest.Jobs != null);
        PositiveTraitsHeader?.gameObject.SetActive(companyRequest.PositiveTraits != null);
        NegativeTraitsHeader?.gameObject.SetActive(companyRequest.NegativeTraits != null);
    }
}
