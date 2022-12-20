using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour {
    Player playerScript;
    ActionHandler actionScript;
    public GameObject seedPrefab;
    public GameObject plantSeedPrefab;
    public GameObject wateringPrefab;
    public GameObject harvestPrefab;
    //int seedsPlanted = 0;
    int[] seedsPlanted = {0, 0, 0, 0, 0, 0, 0, 0, 0};
    int[] seedsWatered = {0, 0, 0, 0, 0, 0, 0, 0, 0};
    // float plantTimer = 0; 
    Vector3[] seedPositions = {
        // first row
        new Vector3(-4.0f, 0.75f, -4.0f),
        new Vector3(-4.0f, 0.75f, -2.0f),
        new Vector3(-4.0f, 0.75f, 0f),
        new Vector3(-4.0f, 0.75f, 2.0f),
        new Vector3(-4.0f, 0.75f, 4.0f),
        // second row
        new Vector3(-2.0f, 0.75f, -4.0f),
        new Vector3(-2.0f, 0.75f, -2.0f),
        new Vector3(-2.0f, 0.75f, 0f),
        new Vector3(-2.0f, 0.75f, 2.0f),
        new Vector3(-2.0f, 0.75f, 4.0f),
        // third row
        new Vector3(0f, 0.75f, -4.0f),
        new Vector3(0f, 0.75f, -2.0f),
        new Vector3(0f, 0.75f, 0f),
        new Vector3(0f, 0.75f, 2.0f),
        new Vector3(0f, 0.75f, 4.0f),
        // fourth row
        new Vector3(2.0f, 0.75f, -4.0f),
        new Vector3(2.0f, 0.75f, -2.0f),
        new Vector3(2.0f, 0.75f, 0f),
        new Vector3(2.0f, 0.75f, 2.0f),
        new Vector3(2.0f, 0.75f, 4.0f),
        // fifth row
        new Vector3(4.0f, 0.75f, -4.0f),
        new Vector3(4.0f, 0.75f, -2.0f),
        new Vector3(4.0f, 0.75f, 0f),
        new Vector3(4.0f, 0.75f, 2.0f),
        new Vector3(4.0f, 0.75f, 4.0f),
    };

    void Start() {
        playerScript = FindObjectOfType<Player>();
        actionScript = FindObjectOfType<ActionHandler>();
    }

    public void Harvest() {
        actionScript.attachEntityToPlayer(harvestPrefab);
    }

    public void Watering() {
        actionScript.attachEntityToPlayer(wateringPrefab);
        GameObject[] Ploots;
        Ploots = GameObject.FindGameObjectsWithTag("Ploot");
        foreach (GameObject Ploot in Ploots) {
            float dist = Vector3.Distance(playerScript.transform.position, Ploot.transform.position);
            if (dist <= 6.0) {
                string plootName = Ploot.name;
                plootName = plootName.Replace("Ploot (", "");
                plootName = plootName.Replace(")", "");
                int plootNumber;
                int.TryParse(plootName, out plootNumber);

                if (seedsPlanted[plootNumber] > 0 && seedsWatered[plootNumber] < 1) {
                    print("Watering...");
                    seedsWatered[plootNumber] = 1;
                }
            }
        }
    }

    public void Sow() {
        actionScript.attachEntityToPlayer(seedPrefab);
        GameObject[] Ploots;
        Ploots = GameObject.FindGameObjectsWithTag("Ploot");
        foreach (GameObject Ploot in Ploots) {
            float dist = Vector3.Distance(playerScript.transform.position, Ploot.transform.position);
            if (dist <= 6.0) {
                string plootName = Ploot.name;
                plootName = plootName.Replace("Ploot (", "");
                plootName = plootName.Replace(")", "");
                int plootNumber;
                int.TryParse(plootName, out plootNumber);

                if (seedsPlanted[plootNumber] <= 24) {
                    print("Planting...");
                    Vector3 seedPosition = Ploot.transform.position + seedPositions[seedsPlanted[plootNumber]];
                    var seed = (GameObject)Instantiate(
                        plantSeedPrefab,
                        seedPosition,
                        transform.rotation
                    );
                    seedsPlanted[plootNumber]++;
                }
            }
        }
    }

    void Update() {
       
    }
}