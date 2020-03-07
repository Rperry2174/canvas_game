using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int unitIndex;
    
    public SpriteRenderer spriteRenderer;
    public Sprite inputSprite;
    public SpriteMask spriteMask;
    private SpriteMask mask;


    private string layerName;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = inputSprite;

        layerName = unitIndex.ToString();
        //AddMask();
    }

    public void AddMask(Vector3 maskPosition)
    {
        //transform.localScale = new Vector3(1, 1, 1);

        spriteRenderer.sortingOrder = 0;
        spriteRenderer.sortingLayerName = layerName;
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        mask = Instantiate(spriteMask, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, gameObject.transform);

        mask.frontSortingLayerID = SortingLayer.NameToID(layerName);
        mask.frontSortingOrder = 1;

        mask.backSortingLayerID = SortingLayer.NameToID(layerName);
        mask.backSortingOrder = -1;


        mask.transform.localPosition = maskPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
