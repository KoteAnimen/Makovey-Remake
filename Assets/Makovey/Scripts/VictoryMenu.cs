using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{
    public Transform cursor;
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        cursor.position = Input.mousePosition;
    }

    public void GoTomainMenu()
    {
        Application.LoadLevel(sceneName);
    }

}
