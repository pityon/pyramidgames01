using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour
{
    GameState gameState;
    public Button m_ButtonYes;
    public Button m_ButtonNo;

    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        m_ButtonYes.onClick.AddListener(TaskOnAccept);
        m_ButtonNo.onClick.AddListener(TaskOnCancel);
    }

    void TaskOnCancel()
    {
        gameObject.SetActive(false);
    }

    void TaskOnAccept() {
        GameObject.Find("Astronaut").GetComponent<ChestInteraction>().OpenChest();
        TaskOnCancel();
    }

}