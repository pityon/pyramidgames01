using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameState gameState;
    private Animator anim;
    float movementSpeed = .75f;
    float rotationSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            gameState.finishGame(true);
        }

        if (!gameState.gameRunning) return;
        float x = 0;
        float y = 0;            //not used :)
        float z = 0;
        float rotationX = 0;    //not used :)
        float rotationY = 0;
        float rotationZ = 0;    //not used :)

        if (Input.GetKey(KeyCode.W)) {
            z += movementSpeed;
        }
        if (Input.GetKey(KeyCode.S)) {
            z -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.A)) {
            x -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.D)) {
            x += movementSpeed;
        }
        if (Input.GetKey(KeyCode.Q)) {
            rotationY -= rotationSpeed;
        }
        if (Input.GetKey(KeyCode.E)) {
            rotationY += rotationSpeed;
        }


        if (x != 0 || z != 0 || rotationY != 0) {
            updatePlayerPosition(x, y, z);
            updatePlayerRotation(rotationX, rotationY, rotationZ);
            anim.SetInteger("AnimationPar", 1);
        }
        else {
            anim.SetInteger("AnimationPar", 0);
        }
    }

    void updatePlayerPosition(float offsetX, float offsetY, float offsetZ)
    {
        Vector3 n = new Vector3(offsetX, offsetY, offsetZ);
        Vector3 directional = transform.TransformDirection(n);
        gameObject.transform.position += directional.normalized * Time.deltaTime;
    }

    void updatePlayerRotation(float offsetX, float offsetY, float offsetZ)
    {
        Vector3 n = new Vector3(offsetX, offsetY, offsetZ) * Time.deltaTime;
        gameObject.transform.eulerAngles += n;
    }
}
