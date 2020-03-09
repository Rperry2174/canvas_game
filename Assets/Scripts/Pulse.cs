using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1f), 1.0f).setEase(LeanTweenType.easeInQuad).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
