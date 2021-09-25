using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	GameObject aboutUsPanel;
	public string nameOfGameScene;
	public GameObject nameGame;
	public GameObject startButton;
	public GameObject aboutUsButton;
	public GameObject exitButton;
	public Transform cursor;
	
    // Start is called before the first frame update
    void Start()
    {
        aboutUsPanel = GameObject.Find("AboutUsPanel");
		aboutUsPanel.SetActive(false);
		Cursor.visible = false;
    }

	void Update()
    {
		cursor.position = Input.mousePosition;
    }
	
	public void StartGame()
	{
		Application.LoadLevel(nameOfGameScene);		
	}
	public void AboutUs(bool chose)
	{
		chose = !chose;
		nameGame.SetActive(chose);
		startButton.SetActive(chose);
		aboutUsButton.SetActive(chose);
		exitButton.SetActive(chose);
		aboutUsPanel.SetActive(!chose);
		
	}
	public void ExitGame()
	{
		Application.Quit();
	}

    
}
