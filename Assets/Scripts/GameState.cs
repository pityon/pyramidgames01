using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject panel;
    private float lifeSpan;
    private GameObject timer;

    void Start()
    {
        lifeSpan = 0;
        panel = GameObject.Find("Panel");
        panel.SetActive(false);

        Vector3[] doorsPositions = {
            new Vector3(3.5f, 3.8f, 3.5f),
            new Vector3(3.5f, 3.8f, 5.5f),
            new Vector3(3.5f, 3.8f, 7.5f),
            new Vector3(3.5f, 3.8f, 9.5f),
            new Vector3(3.5f, 3.8f, 11.5f),
        };
        Quaternion[] doorRotations = {
            Quaternion.Euler(0f, 0f, 0f),
            Quaternion.Euler(0f, 180f, 0f),
            Quaternion.Euler(0f, 90f, 0f),
            Quaternion.Euler(0f, 270f, 0f),
            Quaternion.Euler(0f, 0f, 0f),
        };

        int wallNum = Random.Range(0, doorsPositions.Length + 1);

        GameObject doors = (GameObject)Resources.Load("Prefabs/Doors");
        // GameObject new_doors = Instantiate(doors, doorsPositions[wallNum], Quaternion.identity);
        GameObject new_doors = Instantiate(doors, doorsPositions[wallNum], doorRotations[wallNum]);

        timer = GameObject.Find("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan += Time.deltaTime;
        timer.GetComponent<Text>().text = lifeSpan + "s";
    }

    public GameObject getPanel() {
        return panel;
    }
}
