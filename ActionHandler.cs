using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour {
    Player playerScript;
    GameObject entityPrefabClient;
    bool isCreated = false;

    void Start() {
        playerScript = FindObjectOfType<Player>();
    }

    public void attachEntityToPlayer(GameObject entityPrefab) {
        entityPrefabClient = entityPrefab;
    }

    void Update() {
        if (entityPrefabClient != null) {
            if (isCreated) {
                Destroy(GameObject.FindWithTag("Watering Can Tag") ?? GameObject.FindWithTag("Basket Tag") ?? GameObject.FindWithTag("Seed Tag"));
                isCreated = false;
            }

            var entity = (GameObject)Instantiate(
                entityPrefabClient,
                transform.position,
                transform.rotation
            );

            isCreated = true;
        }
    }
}