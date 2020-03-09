using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ImageSpawner : MonoBehaviour
{
    public List<Unit> allUnits;
    public int numPieces = 9;
    public GameObject targetImagePrefab;
    public int scaleFactor = 300;
    public GameState gameState;
    public bool isAnswerKey = false;
    public VideoClip inputClip;


    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        SpawnPieces();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Only called the first time pieces spawn
    public void SpawnPieces()
    {
        for (int i = 0; i < numPieces; i++)
        {
            var targetImage = Instantiate(targetImagePrefab,
                                          new Vector3(0, 0, 0),
                                          Quaternion.identity,
                                          gameObject.transform);

            targetImage.name = i.ToString();
            targetImage.GetComponent<UnitImage>().inputClip = inputClip;
            targetImage.GetComponent<UnitImage>().unitIndex = i;
            targetImage.GetComponent<UnitImage>().MoveChildImage(GetLocationFromIndex(i));
            if(!isAnswerKey)
            {
                gameState.unitImageList.Add(targetImage.GetComponent<UnitImage>());
            }
        }
    }

    public Vector3 GetLocationFromIndex(int index)
    {
        int yLoc;
        int xLoc;

        xLoc = index % 3;
        if (index < 3) {
            yLoc = 0;
        } else {
            yLoc = index / 3;
        }

        return new Vector3(-xLoc * 300, yLoc * 300, 0);
    }
}
