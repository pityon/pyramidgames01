using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePanel : MonoBehaviour
{
     public Button m_ButtonOk;

    void Start()
    {
        m_ButtonOk.onClick.AddListener(TaskOnOk);
    }

    void TaskOnOk() {
        gameObject.SetActive(false);

    }

}
