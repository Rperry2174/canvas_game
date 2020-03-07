using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoDirector : MonoBehaviour
{
    Texture2D videoTexture;

    //public RawImage rawImage;
    public VideoPlayer videoPlayer;
    //public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }


    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(2);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create((Texture2D)videoPlayer.texture, new Rect(0, 0, videoTexture.width, videoTexture.height), new Vector2(0, 0), 100.0f);

        //rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        //audioSource.Play();
    }
}