using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player1;
    public PanelController panel; 
    private GameObject doorsSpawn;
    private GameObject chestSpawn;

    private GameObject timer;
    private GameObject hscore;
    private float lifeSpan = 0;
    private float highscore = 0;
    public bool gameRunning = false;   //for pausing game
    public bool victoryCondition = false;

    void Start()
    {
        panel = GameObject.Find("Canvas").gameObject.GetComponent<PanelController>();
        player1 = GameObject.Find("Astronaut");
        hscore = GameObject.Find("Highscore");
        timer = GameObject.Find("Timer");
        timer.SetActive(false);
        doorsSpawn = GameObject.Find("Doors_spawn_locations");
        chestSpawn = GameObject.Find("Chest_spawn_locations");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning) {
            lifeSpan += Time.deltaTime;
            timer.GetComponent<Text>().text = lifeSpan.ToString("F2") + "s";
        }
    }

    public void startGame() {
        victoryCondition = false;
        gameRunning = true;
        lifeSpan = 0;
        // Debug.Log(player1.transform.position);
        player1.gameObject.transform.position = new Vector3(5.9f, 3.3f, 8.9f);      //????
        player1.gameObject.transform.Rotate(0, 0, 0);
        timer.SetActive(true);
        hscore.SetActive(false);
        spawnDoors();
        spawnChest();
    }

    public void finishGame() {
	    GameObject.FindWithTag("SF_Door").GetComponent<Animation>().Play("open");
        
        gameRunning = false;
        if (highscore == 0 || lifeSpan < highscore) {
            highscore = lifeSpan;
            hscore.GetComponent<Text>().text = "HIGHSCORE: " + highscore.ToString("F2") + "s";
        }
        timer.SetActive(false);
        hscore.SetActive(true);
        panel.set(4);
        panel.score(lifeSpan);
    }

    public void quitGame() {
        Application.Quit();
    }


    private void spawnDoors() {
        List<Vector3> doorsPositions = new List<Vector3>();
        List<Quaternion> doorsRotations = new List<Quaternion>();

        foreach (Transform child in doorsSpawn.transform) {
            child.gameObject.SetActive(false);
            doorsPositions.Add(child.position);
            doorsRotations.Add(child.rotation);
        }
        int rand = Random.Range(0, doorsPositions.Count);
        // rand = 0;   //debug

        GameObject.Find("Doors").gameObject.transform.position = doorsPositions[rand];
        GameObject.Find("Doors").gameObject.transform.rotation = doorsRotations[rand];
    }
    private void spawnChest() {
        List<Vector3> chestPositions = new List<Vector3>();
        List<Quaternion> chestRotations = new List<Quaternion>();

        foreach (Transform child in chestSpawn.transform) {
            child.gameObject.SetActive(false);
            chestPositions.Add(child.position);
            chestRotations.Add(child.rotation);
        }
        int rand = Random.Range(0, chestPositions.Count);
        // rand = 2;   //debug

        GameObject.Find("Chest_key").gameObject.transform.position = chestPositions[rand];
        GameObject.Find("Chest_key").gameObject.transform.rotation = chestRotations[rand];
        // GameObject.Find("Chest_key").gameObject.transform.Rotate(0, -chestRotations[rand].y, 0);
        // Debug.Log(chestPositions[rand]);
    }
}
