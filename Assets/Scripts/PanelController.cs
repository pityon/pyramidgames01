using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    private Dictionary <string, GameObject> panels = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        panels.Add("start", GameObject.Find("StartPanel"));
        panels.Add("action1", GameObject.Find("ActionPanel"));
        panels.Add("action2", GameObject.Find("Action2Panel"));
        panels.Add("doors1", GameObject.Find("DoorsPanel"));
        panels.Add("doors2", GameObject.Find("Doors2Panel"));
        panels.Add("gameover", GameObject.Find("GameOverPanel"));

        set("start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set(string key) {
        foreach(string i in panels.Keys) {
            panels[i].SetActive(i == key);
        }
    }

    //refactor in the future
    public void score(float time) {
        panels["gameover"].gameObject.GetComponent<GameOverPanel>().Score(time);
    }
}
