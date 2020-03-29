using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeltaDNA;

public class DeltaDnaTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DDNA.Instance.SetLoggingLevel(DeltaDNA.Logger.Level.DEBUG);
        DDNA.Instance.StartSDK();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
