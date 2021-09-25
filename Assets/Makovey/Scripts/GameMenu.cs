using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private bool isActive = true;
    public Transform cursor;
    private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("MainMenu");
        menu.SetActive(false);
        Cursor.visible = false;
    }
    
    void Update()
    {
        cursor.position = Input.mousePosition;
        ActivateMenu();
    }

    void ActivateMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
        }
        menu.SetActive(!isActive);
        if (isActive)
        {
            Time.timeScale = 1;            
        }
        else
        {
            Time.timeScale = 0;            
        }             
    }

    public void GoToMainMenu()
    {        
        isActive = true;               
        Application.LoadLevel("Menu");
    }

    public void Continue()
    {
        isActive = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }    
}
