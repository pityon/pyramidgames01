using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKeyController : MonoBehaviour
{
    private GameObject key;
    private GameObject chest;
    private Animator anim;
    public bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
        key = gameObject.transform.GetChild(0).gameObject;
        chest = gameObject.transform.GetChild(1).gameObject;
        anim = chest.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void spawn() {
        GameObject chestSpawn = GameObject.Find("Chest_spawn_locations");

        List<Vector3> chestPositions = new List<Vector3>();
        List<Quaternion> chestRotations = new List<Quaternion>();

        foreach (Transform child in chestSpawn.transform) {
            child.gameObject.SetActive(false);
            chestPositions.Add(child.position);
            chestRotations.Add(child.rotation);
        }
        int rand = Random.Range(0, chestPositions.Count);
        // rand = 0;   //debug

        gameObject.transform.position = chestPositions[rand];
        gameObject.transform.rotation = chestRotations[rand];
        key.gameObject.SetActive(true);
        
        CloseChest();
        opened = false;
    }

    public void OpenChest() {
        anim.SetTrigger("Activate");
        opened = true;
        ejectKey();
        // Invoke("ejectKey", .5f);
    }

    private void CloseChest() {
        key.transform.localPosition = new Vector3(0.01669312f, 0.005905151f, 0.07289886f);
        key.transform.localEulerAngles = new Vector3(-181.637f, 90.232f, -90.10001f);
        if (opened) {
            anim.SetTrigger("Activate");
        }
    }

    void ejectKey() {
        Vector3 keyVec = new Vector3(-50, -100, 0);     //50 forward, 100 up (calculated relative to key's rotation - key is upside down)
        key.GetComponent<Rigidbody>().AddRelativeForce(keyVec);
        key.GetComponent<KeyBehaviour>().audioHitGround = true;
    }

    public void hideKey() {
        key.gameObject.SetActive(false);
    }


}
