﻿using System.Collections;
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
    public GameObject levelSelectPanel;
    public GameObject zigZagImage;



    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
    }

    public void SetBackgroundColorFromHex(string hex)
    {
        if (ColorUtility.TryParseHtmlString(hex, out Color newCol))
        {
            backgroundImage.GetComponent<Image>().color = newCol;
        }
        else
        {
            Debug.Log("invalid hex color for background. Setting it to white instead");
            backgroundImage.GetComponent<Image>().color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level " + (gameState.levelIndex + 1).ToString();

        levelSelectPanel.gameObject.SetActive(gameState.currentGameState == GameState.State.levelSelect);
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
