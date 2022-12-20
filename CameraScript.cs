using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    Player playerScript;

    void Start() {
        playerScript = FindObjectOfType<Player>();
    }

    void Update() {
        Vector3 playerPos = playerScript.transform.position;
        playerPos.z -= 34;
        playerPos.y += 35;

        transform.position = playerPos;
    }
}
/*
    Player playerScript;
    Vector3 eulerRotPlus;
    Vector3 eulerRotMinus;
    Vector3 eulerRot;

    void Start() {
        playerScript = FindObjectOfType<Player>();
        eulerRotPlus = new Vector3(1.0f, 0, 0);
        eulerRotMinus = new Vector3(-1.0f, 0, 0);
        eulerRot = eulerRotPlus;
    }

    void moveCamera() {
        if (playerScript.RotateUpDown != 0) {
            eulerRot = playerScript.RotateUpDown > 0 ? eulerRotPlus : eulerRotMinus;
            transform.Rotate(eulerRot);
        }
    }

    void Update() {
        moveCamera();
    }
}
*/