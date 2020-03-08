using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<UnitImage> unitImageList;
    //public int selectedUnitIndex = -1;
    //public Vector3 selectedUnitLocation;
    public UnitImage selectedUnitImage;
    public float tweenDuration = 10.9f;

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

        // Tell the swapping UnitImage(s) where to go to
        newUnitImage.MoveTo(selectedUnitImage.GetComponent<UnitImage>().rectTransform.localPosition, tweenDuration);
        selectedUnitImage.MoveTo(newUnitImage.GetComponent<UnitImage>().rectTransform.localPosition, tweenDuration);

        // Reset selectedUnitImage to null
        selectedUnitImage = null;
    }

    public void PauseActions(object unitImageObj)
    {
        UnitImage unitImage = (UnitImage)unitImageObj;
        unitImage.isMoving = false;
    }

    public void ShufflePieces()
    {
        var count = unitImageList.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = unitImageList[i];
            unitImageList[i] = unitImageList[r];
            unitImageList[r] = tmp;

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
