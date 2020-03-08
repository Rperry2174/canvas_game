using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<UnitImage> unitImageList;
    //public int selectedUnitIndex = -1;
    //public Vector3 selectedUnitLocation;
    public UnitImage selectedUnitImage;
    public float tweenDuration = 0.5f;

    public int levelIndex = 0;

    public enum State
    {
        none,
        title,
        gamePlay,
        levelComplete
    }

    public State currentGameState = State.none;

    public void SwapUnitsWith(UnitImage newUnitImage)
    {
        Debug.Log("Swapping: " + selectedUnitImage.unitIndex + " with " + newUnitImage.unitIndex);

        UnitImage tmp = newUnitImage;

        unitImageList[newUnitImage.currentIndex] = selectedUnitImage;
        unitImageList[selectedUnitImage.currentIndex] = tmp;

        LeanTween.moveLocal(newUnitImage.gameObject, selectedUnitImage.GetComponent<UnitImage>().rectTransform.localPosition, tweenDuration);
        LeanTween.moveLocal(selectedUnitImage.gameObject, newUnitImage.GetComponent<UnitImage>().rectTransform.localPosition, tweenDuration);

        selectedUnitImage = null;
    }

    public void SelectUnit(UnitImage newUnitImage)
    {
        selectedUnitImage = newUnitImage;
    }

    public Vector3 GetLocationFromIndex(int index)
    {
        int yLoc;
        int xLoc;

        xLoc = index % 3;
        if (index < 3)
        {
            yLoc = 0;
        }
        else
        {
            yLoc = index / 3;
        }

        return new Vector3(-xLoc * 300, yLoc * 300, 0);
    }


    void Start()
    {
        
    }

    void Update()
    {
        //if(selectedUnitImage != null)
        //{
        //    selectedUnitLocation = selectedUnitImage.rectTransform.localPosition;
        //}
    }
}
