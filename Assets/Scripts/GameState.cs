using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameState : MonoBehaviour
{
    public List<UnitImage> unitImageList;
    public UnitImage selectedUnitImage;
    public VideoClip[] targetVideoClipsArr;

    public float tweenDuration = 0.5f;
    public int correctPiecesCount;

    public int _levelIndex = 0;
    public int levelIndex
    {
        get
        {
            //return this._levelIndex;
            return PlayerPrefs.GetInt("levelIndex");
        }
        set
        {
            Debug.Log("this is your level index");
            PlayerPrefs.SetInt("levelIndex", value);
            this._levelIndex = value;
        }
    }

    public enum State
    {
        none,
        levelTitle,
        gamePlay,
        levelComplete
    }

    public State currentGameState = State.none;


    void Start()
    {
        //ShuffleUnits();
        currentGameState = State.levelTitle;
    }

    void Update()
    {
        CheckForWinner();
    }



    void OnApplicationPause(bool pauseStatus)
    {
        Debug.Log("(OnApplicationPause) resetting board");
        ResetBoard();
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        Debug.Log("(OnApplicationQuit) resetting board");
        ResetBoard();
    }


    public void StartGame()
    {
        ShuffleUnits();
        RespawnPieces();
        currentGameState = State.gamePlay;
    }





    public void DestroyAllPieces()
    {
        unitImageList.Clear();

        var allImageSpawners = FindObjectsOfType<ImageSpawner>();
        foreach (ImageSpawner imageSpawner in allImageSpawners)
        {
            imageSpawner.DestroyPieces();
        };
        foreach (ImageSpawner imageSpawner in allImageSpawners)
        {
            imageSpawner.SpawnPieces();
        };
    }



    public void GoToNextLevel()
    {
        if(levelIndex == unitImageList.Count - 1)
        {
            levelIndex = 0;
        } else
        {
            levelIndex += 1;
        }

        DestroyAllPieces();
        //ShuffleUnits();
        //RespawnPieces();
        ResetBoard();
    }

    public void ResetBoard()
    {
        selectedUnitImage = null;
        currentGameState = State.levelTitle;

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

    public void RespawnPieces()
    {
        for (int i = 0; i < unitImageList.Count; i++)
        {
            UnitImage tmpUnit = unitImageList[i];
            Vector3 inversionFactor = new Vector3(-1, -1, 1);
            Vector3 newLocation = Vector3.Scale(inversionFactor, GetLocationFromIndex(i));

            tmpUnit.rectTransform.localPosition = newLocation;
        }
    }

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

    public void CheckForWinner()
    {
        correctPiecesCount = 0;

        for (int i = 0; i < unitImageList.Count; i++)
        {
            if (unitImageList[i].unitIndex == i)
            {
                correctPiecesCount += 1;
            }
        }

        if (correctPiecesCount == unitImageList.Count && currentGameState == State.gamePlay)
        {
            currentGameState = State.levelComplete;
        }
    }
}
