using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{

    public bool audioHitGround = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject chest = GameObject.Find("TreasureChest");
        Physics.IgnoreCollision(chest.GetComponent<Collider>(), GetComponent<Collider>());

        GameState gameState = GameObject.Find("GameState").GetComponent<GameState>();
        Physics.IgnoreCollision(gameState.getPlayer1().GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (audioHitGround && collision.gameObject.name == "Plane") {
            gameObject.GetComponent<AudioSource>().Play();
            audioHitGround = false;
        }
    }
}
