using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSpawner : MonoBehaviour
{
    public List<Unit> allUnits;
    public int numPieces = 9;
    public GameObject targetImagePrefab;
    public int scaleFactor = 300;

    // Start is called before the first frame update
    void Start()
    {
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

            //targetImage.GetComponent<Unit>().AddMask(GetLocationFromIndex(i));
            //targetImage.GetComponent<VideoPlayer>().clip = videoClip;
            targetImage.name = i.ToString();
            //allUnits.Add(targetImage.GetComponent<Unit>());
        }
    }


    public Vector3 GetLocationFromIndex(int index)
    {
        int row;
        int col;

        col = index % 3;
        if (index < 3) {
            row = 0;
        } else {
            row = index / 3;
        }

        return new Vector3(-row * 300, col * 300, 0);
    }
}
