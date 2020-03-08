using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<UnitImage> unitImageList;
    public int selectedUnitIndex = -1;

    public int levelIndex = 0;

    public enum State
    {
        none,
        title,
        gamePlay,
        levelComplete
    }

    public State currentGameState = State.none;

    public void SwapUnits(int indexA, int indexB)
    {
        UnitImage tmp = unitImageList[indexA];
        unitImageList[indexA] = unitImageList[indexB];
        unitImageList[indexB] = tmp;

        selectedUnitIndex = -1;
    }

    public void SelectUnit(int newIndex)
    {
        selectedUnitIndex = newIndex;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
