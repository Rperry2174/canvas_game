using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckClicks : MonoBehaviour
{
    // Normal raycasts do not work on UI elements, they require a special kind
    private GraphicRaycaster raycaster;
    public GameState gameState;

    void Awake()
    {
        // Get both of the components we need to do this
        raycaster = GetComponent<GraphicRaycaster>();
        gameState = FindObjectOfType<GameState>();

    }

    void CollisionAction(int unitIndex)
    {
        // Unselect unit if you are retapping on the currently selected unit
        if (gameState.selectedUnitIndex == unitIndex)
        {
            Debug.Log("Retapping... Setting index to: " + unitIndex);
            gameState.SelectUnit(-1);
        }
        else
        {
            bool unitIsAlreadySelected = gameState.selectedUnitIndex >= 0;

            if (unitIsAlreadySelected)
            {
                Debug.Log("unitIsAlreadySelected swapping unit: " + gameState.selectedUnitIndex + " with " + unitIndex);

                gameState.SwapUnits(gameState.selectedUnitIndex, unitIndex);
                //gameState.CheckForWinner();
            }
            else
            {
                Debug.Log("Setting unit index to: " + unitIndex);
                gameState.SelectUnit(unitIndex);
            }
        }
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            pointerData.position = Input.mousePosition;
            raycaster.Raycast(pointerData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
                if (result.gameObject.GetComponent<UnitImage>() != null)
                {
                    CollisionAction(result.gameObject.GetComponent<UnitImage>().unitIndex);
                }
            }
        }
    }
}
