
using UnityEngine;
using System.Collections;

public class EventTrig : MonoBehaviour {
	public GameObject gameCanvas;
    public PuzzleManager puzzleManager;

	// Use this for initialization
	void Start () {
		gameCanvas = GameObject.FindGameObjectWithTag ("Journal");
        puzzleManager = gameObject.GetComponent<PuzzleManager>();
    }
	
	// Update is called once per frame
	void Update () {
				
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Trigger") {	
			GameObject eventTrigger = other.gameObject;
			TriggerProperties triggerProps = eventTrigger.GetComponent<TriggerProperties> ();

			if (!triggerProps.IsDestroyed()) {
				triggerProps.ActivateTrigger();
				string message = triggerProps.GetMessage ();
				if (message != "")
					gameCanvas.GetComponent<Journal> ().AddMessage (message);
			}
            if (triggerProps.IsPuzzleTrigger())
            {
                triggerProps.isPuzzleTrigger = false;
                puzzleManager.StartPuzzle(triggerProps.GetPuzzle());
            }
		}
	}
	
	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Trigger") {	
			GameObject eventTrigger = other.gameObject;
			TriggerProperties triggerProps = eventTrigger.GetComponent<TriggerProperties> ();

			if (!triggerProps.IsDestroyed ()) {
				triggerProps.DestroyTrigger();
			}
		}
	}
}
