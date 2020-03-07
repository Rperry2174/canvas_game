using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitImage : MonoBehaviour
{
    public int unitIndex;

    public RectTransform rectTransform;
    public Image childImage;


    private string layerName;

    void Start()
    {
        layerName = unitIndex.ToString();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        //AddMask();
    }

    public void MoveChildImage(Vector3 newPosition)
    {

    }

    //public void AddMask(Vector3 maskPosition)
    //{
    //    transform.localScale = new Vector3(1, 1, 1);

    //    spriteRenderer.sortingOrder = 0;
    //    spriteRenderer.sortingLayerName = layerName;
    //    spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

    //    mask = Instantiate(spriteMask, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, gameObject.transform);

    //    mask.frontSortingLayerID = SortingLayer.NameToID(layerName);
    //    mask.frontSortingOrder = 1;

    //    mask.backSortingLayerID = SortingLayer.NameToID(layerName);
    //    mask.backSortingOrder = -1;


    //    mask.transform.localPosition = maskPosition;
    //}

    void Update()
    {

    }
}
