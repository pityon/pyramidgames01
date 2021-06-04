using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    private GameObject[] panels = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        panels[0] = GameObject.Find("StartPanel");
        panels[1] = GameObject.Find("ActionPanel");
        panels[2] = GameObject.Find("Action2Panel");
        panels[3] = GameObject.Find("DoorsPanel");
        panels[4] = GameObject.Find("GameOverPanel");

        set(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set(int key) {
        for (int i = 0; i < panels.Length; i++) {
            panels[i].SetActive(i == key);
        }
    }

    //refactor in the future
    public void score(float time) {
        panels[4].gameObject.GetComponent<GameOverPanel>().Score(time);
    }
}
