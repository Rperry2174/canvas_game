using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int unitIndex;
    public SpriteRenderer sr;
    public Sprite inputSprite;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = inputSprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
