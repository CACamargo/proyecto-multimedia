using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProperties : MonoBehaviour {
	public GameObject trigger;
	public float TimeDestroy;
	public string message, puzzle;
    public bool isPuzzleTrigger = false;
	private float time = 0;
	private bool isDestroyed, destroy = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (destroy == true) {
			time += Time.deltaTime;
			if(time > TimeDestroy){
				Destroy(trigger);
				destroy = false;
			}
		}
	}

	public bool IsDestroyed(){
		return isDestroyed;
	}

    public bool IsPuzzleTrigger()
    {
        return isPuzzleTrigger;
    }

    public string GetMessage(){
		return message;
	}

    public string GetPuzzle()
    {
        return puzzle;
    }

    public void DestroyTrigger() {
		destroy = true;
		isDestroyed = true;
	}

	public void ActivateTrigger(){
		trigger.SetActive (true);
	}
}
