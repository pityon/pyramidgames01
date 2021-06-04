using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    GameState gameState;


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                // Debug.Log(hit.distance);
                if (hit.distance < 0.6f) {
                    if (hit.transform.name == "TreasureChest" && !gameState.player1.GetComponent<ChestInteraction>().opened) {
                        gameState.panel.set(1);
                    }
                    else if (hit.transform.name == "Key") {
                        gameState.panel.set(2);
                    }
                    else if (hit.transform.name == "Doors") {
                        if (gameState.victoryCondition) {
                            gameState.finishGame();
                        }
                        else {
                            gameState.panel.set(3);
                        }
                    }
                }
            }
        }        
    }
}
