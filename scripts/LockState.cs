using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockState : MonoBehaviour {

    private bool locked;
    public string keyName;
    
    // Use this for initialization
    void Start()
    {
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getState() { return locked; }

    public string getKeyName() { return keyName; }

    public void unlock()
    {
        locked = false;
    }
}
