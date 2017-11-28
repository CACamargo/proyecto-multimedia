using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour {
    
    public bool isActive;
    public GameObject door;
    public GameObject sound;
    AnimStates doorState;
    Animation anim;

    // Use this for initialization
    void Start()
    {
        isActive = false;
        door = GameObject.Find("door_04_dp");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Begin()
    {
        isActive = true;
        doorState = door.GetComponent<AnimStates>();
        anim = door.GetComponent<Animation>();
        anim.Play(doorState.states[doorState.getState()]);
        doorState.incState();
        door.tag = "LockedDoor";

    }
    public void End()
    {
        isActive = false;
        doorState = door.GetComponent<AnimStates>();
        anim = door.GetComponent<Animation>();
        anim.Play(doorState.states[doorState.getState()]);
        doorState.incState();
        door.tag = "Untagged";
    }

    public bool IsActive()
    {
        return isActive;
    }
}
