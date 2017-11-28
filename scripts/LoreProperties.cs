using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreProperties : MonoBehaviour {
    public string message;
    public bool isSolution = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetMessage()
    {
        return message;
    }

    public bool IsSolution()
    {
        return isSolution;
    }
}
