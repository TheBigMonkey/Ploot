using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  


public class MainMenuScript : MonoBehaviour
{
    public string menu;
    public string Gameplay;
    public string options;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Gameplay);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(options);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menu);
    }

    public void QuitGame()
    {
        print("Nu lukker spillet");
        Application.Quit();
    }
}
