using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyRequestManager : SingletonMB<CompanyRequestManager>
{
    // TODO: Prototip için geçici liste
    private List<CompanyRequest> _companyRequests = new List<CompanyRequest>();
}
