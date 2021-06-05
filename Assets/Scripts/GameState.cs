using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player1;
    private PanelController panelController; 
    public DoorsController doorsController;
    public ChestKeyController chestController;

    private GameObject timer;
    private GameObject hscore;
    private float lifeSpan = 0;
    private float highscore = 0;
    public bool gameRunning = false;   //for pausing game
    public bool victoryCondition = false;

    void Start()
    {
        panelController = GameObject.Find("Canvas").gameObject.GetComponent<PanelController>();
        doorsController = GameObject.Find("Doors").GetComponent<DoorsController>();
        chestController = GameObject.Find("Chest_key").GetComponent<ChestKeyController>();

        player1 = GameObject.Find("Astronaut");
        hscore = GameObject.Find("Highscore");
        timer = GameObject.Find("Timer");
        timer.SetActive(false);
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
        player1.gameObject.transform.eulerAngles = Vector3.zero;
        timer.SetActive(true);
        hscore.SetActive(false);
        doorsController.spawn();
        chestController.spawn();
        player1.GetComponent<AudioSource>().Play(0);
    }

    public void finishGame(bool interrupted = false) {
        doorsController.open();
        gameRunning = false;
        if (interrupted) {
            panelController.set("start");
        }
        else {
            if (highscore == 0 || lifeSpan < highscore) {
                highscore = lifeSpan;
                hscore.GetComponent<Text>().text = "HIGHSCORE: " + highscore.ToString("F2") + "s";
            }
            panelController.set("gameover");
            panelController.score(lifeSpan);
        }
        timer.SetActive(false);
        hscore.SetActive(true);
        player1.GetComponent<AudioSource>().Stop();
    }

    public void quitGame() {
        Application.Quit();
    }

    /*********************/
    //EXPOSE ELEMENTS
    /*********************/

    public GameObject getPlayer1() {
        if (!player1) {
            player1 = GameObject.Find("Astronaut");     //hotfix for KeyBehaviour
        }
        return player1;
    }

    public void panelSet(string id) {
        panelController.set(id);
    }  
}
