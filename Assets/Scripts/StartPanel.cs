using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
     public Button m_ButtonStart;
    public Button m_ButtonQuit;
    private GameState gameState;

    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        m_ButtonStart.onClick.AddListener(StartGame);
        m_ButtonQuit.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        gameObject.SetActive(false);
        gameState.startGame();
    }

    void QuitGame() {
        gameState.quitGame();
    }

}
