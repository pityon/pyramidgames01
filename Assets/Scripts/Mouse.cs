using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    GameState gameState;
    string hovering = "";


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool unhover = false;

        if (Physics.Raycast(ray, out hit, 0.6f)) {
            string target_name = hit.transform.name;

            //chest becomes inactive
            if (target_name == "TreasureChest" && gameState.chestController.opened) {
                unhover = true;
            }
            else {
                if (Input.GetMouseButtonDown(0)) {
                    if (target_name == "TreasureChest") {
                        gameState.panelSet("action1");
                    }
                    else if (target_name == "Key") {
                        gameState.panelSet("action2");
                    }
                    else if (target_name == "Doors") {
                        if (gameState.victoryCondition) {
                            gameState.panelSet("doors2");
                        }
                        else {
                            gameState.panelSet("doors1");
                        }
                    }
                }

                if (target_name == "TreasureChest" || target_name == "Key" || target_name == "Doors") {
                    if (hovering != target_name) {
                        highlight(hit.collider.gameObject, Color.red);
                        hovering = target_name;
                    }
                }
                else if (hovering != "") {
                    unhover = true;
                }
            }
        }
        else {
            unhover = true;
        }

        if (unhover && hovering != "") {
            highlight(GameObject.Find("TreasureChest"), Color.white);
            highlight(GameObject.Find("Key"), Color.white);
            highlight(GameObject.Find("Doors"), Color.white);
            hovering = "";
        }
    }

    private void highlight(GameObject target, Color highlight) {
        if (target) {
            Renderer parent = target.GetComponent<Renderer>();
            if (parent != null) {
                parent.material.color = highlight;
            }
            foreach(Transform child in target.transform) {
                Renderer _child = child.GetComponent<Renderer>();
                if (_child != null) {
                    _child.GetComponent<Renderer>().material.color = highlight;
                }
            }
        }
    }
}
