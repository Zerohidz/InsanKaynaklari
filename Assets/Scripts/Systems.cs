using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systems : PersistentSingletonMB<Systems>
{
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        Instantiate(Resources.Load("Systems"));
    }
}
