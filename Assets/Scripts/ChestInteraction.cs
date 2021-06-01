using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{

    private Animator anim;
    private GameObject key;
    private bool opened = false;

    void Start()
    {
        anim = GameObject.Find("TreasureChest").GetComponentInChildren<Animator>();
        key = GameObject.Find("Key");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "TreasureChest" && !opened) {
                    GameObject panel = GameObject.Find("GameState").GetComponent<GameState>().getPanel();
                    panel.SetActive(true);
                }
                else if (hit.transform.name == "Key") {
                    key.GetComponent<AudioSource>().Play();
                    Invoke("hideKey", .5f);
                }
            }
        }
    }

    public void OpenChest() {
        anim.SetTrigger("Activate");
        opened = true;
        Invoke("ejectKey", .5f);
    }

    void ejectKey() {
        Vector3 keyVec = new Vector3(0, 100, 100);
        key.GetComponent<Rigidbody>().AddForce(keyVec);
        key.GetComponent<KeyBehaviour>().audioHitGround = true;
    }

    void hideKey() {
        key.gameObject.SetActive(false);
    }
}
