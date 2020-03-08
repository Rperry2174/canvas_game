using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<UnitImage> unitImageList;
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


    void Start()
    {
        //ShuffleUnits();
    }

    void Update()
    {

    }

    public void SwapUnitsWith(UnitImage newUnitImage)
    {
        Debug.Log("Swapping: " + selectedUnitImage.unitIndex + " with " + newUnitImage.unitIndex);

        UnitImage tmp = newUnitImage;

        unitImageList[newUnitImage.currentIndex] = selectedUnitImage;
        unitImageList[selectedUnitImage.currentIndex] = tmp;

        // Tell the swapping UnitImage(s) where to go to
        newUnitImage.MoveTo(selectedUnitImage.GetComponent<UnitImage>().rectTransform.localPosition, tweenDuration);
        selectedUnitImage.MoveTo(newUnitImage.GetComponent<UnitImage>().rectTransform.localPosition, tweenDuration);

        // Reset selectedUnitImage to null
        selectedUnitImage = null;
    }

    //public void SwapUnitsWith(UnitImage firstUnitImage, UnitImage newUnitImage, float tweenDuration)
    //{
    //    Debug.Log("Swapping: " + firstUnitImage.unitIndex + " with " + newUnitImage.unitIndex);

    //    UnitImage tmp = newUnitImage;

    //    unitImageList[newUnitImage.currentIndex] = firstUnitImage;
    //    unitImageList[firstUnitImage.currentIndex] = tmp;

    //    // Tell the swapping UnitImage(s) where to go to
    //    newUnitImage.MoveTo(firstUnitImage.GetComponent<UnitImage>().rectTransform.localPosition, tweenDuration);
    //    firstUnitImage.MoveTo(newUnitImage.GetComponent<UnitImage>().rectTransform.localPosition, tweenDuration);
    //}

    public void PauseActions(object unitImageObj)
    {
        UnitImage unitImage = (UnitImage)unitImageObj;
        unitImage.isMoving = false;
    }

    public void ShuffleUnits()
    {
        var count = unitImageList.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = unitImageList[i];
            unitImageList[i] = unitImageList[r];
            unitImageList[r] = tmp;

            //SwapUnitsWith(unitImageList[i], unitImageList[r], 0.0f);
        }
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
}
