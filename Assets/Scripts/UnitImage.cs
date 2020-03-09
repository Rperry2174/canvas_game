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
    public GameObject selectedFrame;

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
        if(gameState.selectedUnitImage != null && !gameObject.transform.parent.GetComponent<ImageSpawner>().isAnswerKey)
        {
            selectedFrame.SetActive(gameState.selectedUnitImage.unitIndex == unitIndex);
        } else
        {
            selectedFrame.SetActive(false);
        }

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

    public void MoveTo(Vector3 endLocation, float time)
    {
        isMoving = true;
        LeanTween.moveLocal(gameObject, endLocation, time)
                    .setOnComplete(ToggleIsMovingCallback).setOnCompleteParam(this as object);
    }

    public void ToggleIsMovingCallback(object unitImageObj)
    {
        UnitImage unitImage = (UnitImage)unitImageObj;
        unitImage.isMoving = false;
    }
}
