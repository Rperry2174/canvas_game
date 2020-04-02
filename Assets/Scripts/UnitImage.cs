using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UnitImage : MonoBehaviour
{
    public int unitIndex;
    public int currentIndex;
    public bool isMoving = false;

    public RectTransform rectTransform;
    public RawImage childImage;
    public GameState gameState;
    public GameObject selectedFrame;
    public Color greenColor = new Color(0.0f, 255.0f, 0.0f, 255.0f);
    public Color blankColor = new Color(255.0f, 255.0f, 255.0f, 255.0f);

    public VideoPlayer videoPlayer;
    public bool isAnswerKeyChild;
    private string layerName;


    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        layerName = unitIndex.ToString();
        currentIndex = unitIndex;
        videoPlayer.clip = gameState.targetVideoClipsArr[gameState.levelIndex];
        isAnswerKeyChild = gameObject.transform.parent.GetComponent<ImageSpawner>().isAnswerKey;
        if(isAnswerKeyChild)
        {
            selectedFrame.GetComponent<Image>().color = greenColor;
        }
    }

    void Update()
    {
        SetCurrentIndex();
        HighlightSelected();
        HighlightCorrect();
    }

    public void HighlightSelected()
    {
        if (gameState.selectedUnitImage != null && !isAnswerKeyChild)
        {
            selectedFrame.SetActive(gameState.selectedUnitImage.unitIndex == unitIndex);
        }
        else
        {
            selectedFrame.SetActive(false);
        }
    }

    public void HighlightCorrect()
    {
        if(isAnswerKeyChild && gameState.currentGameState == GameState.State.gamePlay)
        {
            if (gameState.unitImageList[unitIndex].unitIndex == unitIndex)
            {
                selectedFrame.SetActive(true);
                childImage.color = greenColor;
            }
        }
        else
        {
            childImage.color = blankColor;
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
