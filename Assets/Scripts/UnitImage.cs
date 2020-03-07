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
        //rectTransform.localPosition = new Vector3(300, 0, 0);
        //AddMask();
    }

    public void MoveChildImage(Vector3 newPosition)
    {
        // Move the child image into proper position
        childImage.rectTransform.localPosition = newPosition;

        //Move the mask to the proper (inverted) position
        Vector3 inversionFactor = new Vector3(-1, -1, 1);
        //rectTransform.localPosition = new Vector3(300, 0, 0);

        Debug.Log("Moving to inverted position: " + Vector3.Scale(inversionFactor, newPosition));
        rectTransform.localPosition = Vector3.Scale(inversionFactor, newPosition);
        //Debug.Log("==============================================");
        //Debug.Log("NewPosition: " + newPosition);
        //Debug.Log("New Position Inverted: " + Vector3.Scale(inversionFactor, newPosition));
        //Debug.Log("==============================================");

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
