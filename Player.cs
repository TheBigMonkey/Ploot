using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    AudioSource walkSource;
    SceneInputs Handlings;
    public Vector2 Position;
    Vector3 eulerRotPlus;
    Vector3 eulerRotMinus;
    Vector3 eulerRot;
    public float isPlanting;
    //public Vector3 PlootPosition;
    private Rigidbody rb;
    public static int playerPos;
    bool soundPlays = false;
    int soundTimer = 0;

    void Awake() {
        Handlings = new SceneInputs();
        Handlings.Gameplay.Walk.performed += ctx => Position = ctx.ReadValue<Vector2>();
        Handlings.Gameplay.Walk.canceled += ctx => Position = Vector2.zero;

        Handlings.Gameplay.Plant.performed += ctx => isPlanting = 1;
        Handlings.Gameplay.Plant.canceled += ctx => isPlanting = 0;
    }           

    void Start() {
        rb = GetComponent<Rigidbody>();
        eulerRotPlus = new Vector3(0, 2.0f, 0);
        eulerRotMinus = new Vector3(0, -2.0f, 0);
        eulerRot = eulerRotPlus;

        walkSource = GetComponent<AudioSource>();
    }

   /* void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Ploot"){ 
            print("s");
            //plootPosition = transform.position;
            //print(transform.position);
            GameObject[] Ploots;
            Ploots = GameObject.FindGameObjectsWithTag("Ploot");
            foreach (GameObject Ploot in Ploots) {
                float dist = Vector3.Distance(transform.position, Ploot.transform.position);
                if (dist <= 6.0) {
                    PlootPosition = Ploot.transform.position;
                    print(Ploot);
                    print(Ploot.transform.position);
                }
            };
        }
    }*/

    void OnEnable() {
        Handlings.Gameplay.Enable();
    }

    void OnDisable() {
        Handlings.Gameplay.Disable();
    }

    void movePlayer() {
        soundTimer++;
        if (Position != Vector2.zero) {
            rb.velocity = transform.forward * Position.y * 10.0f + transform.right * Position.x * 10.0f;
            if (!soundPlays && soundTimer >= 75) {
                walkSource.Play();
                soundTimer = 0;
            }
        } else {
            rb.velocity = Vector3.zero;
        }
    }

    void Update() {
        movePlayer();

        if (Input.GetKeyDown(KeyCode.W)) {
            if (transform.rotation.eulerAngles.y != 0) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            if (transform.rotation.eulerAngles.y != 90) {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            if (transform.rotation.eulerAngles.y != 180) {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            if (transform.rotation.eulerAngles.y != 270) {
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
        }
    }
}
