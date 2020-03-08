using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitImage : MonoBehaviour
{
    public int unitIndex;
    public int currentIndex;
    public bool isMoving = false;

    public RectTransform rectTransform;
    public RawImage childImage;
    public GameState gameState;

    private string layerName;


    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        layerName = unitIndex.ToString();
        currentIndex = unitIndex;
    }

    void Update()
    {
        SetCurrentIndex();
        //SetIsMoving();

    }

    public void MoveChildImage(Vector3 newPosition)
    {
        // Move the child image into proper position
        childImage.rectTransform.localPosition = newPosition;

        //Move the mask to the proper (inverted) position
        Vector3 inversionFactor = new Vector3(-1, -1, 1);
        rectTransform.localPosition = Vector3.Scale(inversionFactor, newPosition);
    }

    public void SetCurrentIndex()
    {
        for (int i = 0; i < gameState.unitImageList.Count; i++)
        {
            if (gameState.unitImageList[i].unitIndex == unitIndex)
            {
                currentIndex = i;
            }
        }
    }

    public void SetIsMoving()
    {
        Vector3 currentLocation = rectTransform.localPosition;
        Vector3 expectedLocation = gameState.GetLocationFromIndex(currentIndex);

        float dis = Vector3.Distance(currentLocation, expectedLocation);
        if(currentIndex == 0)
        {
            Debug.Log("Current Location : " + currentLocation);
            Debug.Log("Expected Location: " + expectedLocation);
            Debug.Log("Distance         : " + dis);


        }

        //isMoving = currentLocation != expectedLocation;
    }

    public void moveTo(Vector3 endLocation, float time)
    {
        LeanTween.moveLocal(gameObject, endLocation, time);
    }


}
