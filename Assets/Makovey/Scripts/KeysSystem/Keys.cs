using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public Dictionary<string, bool> keys = new Dictionary<string, bool>();
    public string[] keyNames;

    private void Start()
    {
        foreach(string keyName in keyNames)
        {
            keys.Add(keyName, false);
        }
    }
}
