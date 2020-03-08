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

    void CollisionAction(UnitImage currentUnitImage)
    {
        // Guard against trying to move already moving units
        if(currentUnitImage.isMoving)
        {
            return;
        }

        // Unselect unit if you are retapping on the currently selected unit
        if(gameState.selectedUnitImage == null)
        {
            Debug.Log("Setting unit index to: " + currentUnitImage.unitIndex);
            gameState.SelectUnit(currentUnitImage);
        }
        else if (gameState.selectedUnitImage.unitIndex == currentUnitImage.unitIndex)
        {
            Debug.Log("Retapping... " + gameState.selectedUnitImage.unitIndex + " Setting index to: " + null);
            gameState.SelectUnit(null);
        }
        else
        {
            Debug.Log("unitIsAlreadySelected swapping unit: " + gameState.selectedUnitImage.unitIndex + " with " + currentUnitImage.unitIndex);
            gameState.SwapUnitsWith(currentUnitImage);
            //gameState.CheckForWinner();
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
                    UnitImage currentUnitImage = result.gameObject.GetComponent<UnitImage>();
                    CollisionAction(currentUnitImage);
                }
            }
        }
    }
}
