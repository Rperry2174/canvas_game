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
            }
        }
    }
}
