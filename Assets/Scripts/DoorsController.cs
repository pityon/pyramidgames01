using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn() {
        GameObject doorsSpawn = GameObject.Find("Doors_spawn_locations");

        List<Vector3> doorsPositions = new List<Vector3>();
        List<Quaternion> doorsRotations = new List<Quaternion>();

        foreach (Transform child in doorsSpawn.transform) {
            child.gameObject.SetActive(false);
            doorsPositions.Add(child.position);
            doorsRotations.Add(child.rotation);
        }
        int rand = Random.Range(0, doorsPositions.Count);
        // rand = 0;   //debug

        gameObject.gameObject.transform.position = doorsPositions[rand];
        gameObject.gameObject.transform.rotation = doorsRotations[rand];
        close();
    }

    public void open() {
        GameObject.FindWithTag("SF_Door").GetComponent<Animation>().Play("open");
    }

    public void close() {
        GameObject.FindWithTag("SF_Door").GetComponent<Animation>().Play("close");
    }
}
