using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{

    private Animator anim;
    private GameObject key;
    public bool opened = false;

    void Start()
    {
        anim = GameObject.Find("TreasureChest").GetComponentInChildren<Animator>();
        key = GameObject.Find("Key");
    }

    void Update()
    {
        
    }

    public void OpenChest() {
        anim.SetTrigger("Activate");
        opened = true;
        Invoke("ejectKey", .5f);
    }

    void ejectKey() {
        Vector3 keyVec = new Vector3(100, 100, 0);
        key.GetComponent<Rigidbody>().AddForce(keyVec);
        key.GetComponent<KeyBehaviour>().audioHitGround = true;
    }

    public void hideKey() {
        key.gameObject.SetActive(false);
    }
}
