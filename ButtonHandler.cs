using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ButtonHandler : MonoBehaviour {
    Farming farmingScript;

    void Start() {
        farmingScript = FindObjectOfType<Farming>();
    }

    public void Sowing() {
        farmingScript.Sow();
    }

    void Update() {

    }
}
