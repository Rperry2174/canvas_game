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
            targetImage.GetComponent<UnitImage>().MoveChildImage(GetLocationFromIndex(i));
            //targetImage.GetComponent<UnitImage>().rectTransform.localPosition = new Vector3(0, 0, 0);
            //allUnits.Add(targetImage.GetComponent<Unit>());
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
