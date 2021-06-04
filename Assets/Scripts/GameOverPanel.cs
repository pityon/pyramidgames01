using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    GameState gameState;
    public Button m_ButtonMenu;

    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        m_ButtonMenu.onClick.AddListener(TaskOnMenu);
    }

    void TaskOnMenu() {
        gameState.panel.set(0);
    }

    public void Score(float time) {
        GameObject.Find("EndingText").GetComponent<Text>().text = "Good job!\r\nYou have finished the game.\r\nYour time is: " + time + "s";
    }

}
