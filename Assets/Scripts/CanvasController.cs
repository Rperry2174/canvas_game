using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Text numCorrectText;
    public Slider slider;
    public Text levelText;
    public GameState gameState;
    public GameObject levelTitlePanel;
    public GameObject levelCompletePanel;
    public GameObject gamePlayPanel;
    public GameObject backgroundImage;
    public GameObject zigZagImage;

    public Color backgroundColor = Color.white;
    public Color zigZagColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();

        Debug.Log("Currnet color: " + backgroundImage.GetComponent<Image>().color);
        backgroundImage.GetComponent<Image>().color = backgroundColor;
        zigZagImage.GetComponent<Image>().color = zigZagColor;

    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level " + (gameState.levelIndex + 1).ToString();

        levelTitlePanel.gameObject.SetActive(gameState.currentGameState == GameState.State.levelTitle);
        slider.gameObject.SetActive(gameState.currentGameState == GameState.State.gamePlay);
        levelCompletePanel.gameObject.SetActive(gameState.currentGameState == GameState.State.levelComplete);

        //levelCompletePanel.SetActive(gm.currentGameState == GameManager.GameState.levelComplete);
        //gamePlayPanel.SetActive(gm.currentGameState == GameManager.GameState.gamePlay || gm.currentGameState == GameManager.GameState.title);

        if (gameState.currentGameState == GameState.State.levelComplete)
        {
            numCorrectText.text = gameState.unitImageList.Count + " / " + gameState.unitImageList.Count;
            slider.value = 1.0f;
        }
        else
        {
            slider.value = Mathf.Max(gameState.correctPiecesCount / (float)gameState.unitImageList.Count, 0.10f);

            numCorrectText.text = gameState.correctPiecesCount.ToString() + " / " + gameState.unitImageList.Count.ToString();
        }
    }
}
