using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyRequestManager : SingletonMB<CompanyRequestManager>
{
    public CompanyRequest CurrentCompanyRequest { get; private set; }

    // TODO: Prototip için geçici liste
    private List<CompanyRequest> _companyRequests = new List<CompanyRequest>();

    protected override void Awake()
    {
        base.Awake();
        GameController.OnDayChanged += UpdateCurrentCompanyRequest;
    }

    public void UpdateCurrentCompanyRequest()
    {
        print("update'ledim request'i");
        CurrentCompanyRequest = _companyRequests[GameController.Instance.Day - 1];
    }
}
