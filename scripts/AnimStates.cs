using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStates : MonoBehaviour {

    private int currState = 0;
    public string[] states = new string[2];

    // Use this for initialization
    void Start () {
        Animation anim = this.GetComponent<Animation>();
        int i = 0;
                
        foreach (AnimationState state in anim)
        {
            states[i] = state.name;
            i++;
            //Debug.Log(state.name);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getState() { return currState; }

    public void incState()
    {
        if (currState == 1)
            currState = 0;
        else
            currState = 1;
    }
}
