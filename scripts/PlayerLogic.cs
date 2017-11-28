using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {
	private List<string> inventory;
    public GameObject gameCanvas;

	// Use this for initialization
	void Start () {
		inventory = new List<string>();
        gameCanvas = GameObject.FindGameObjectWithTag("Journal");
        //gameCanvas.GetComponent<Journal>().AddMessage("Huh? W-where am I?");
    }
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.I)) {
			GetInventory ();
		}*/
		
	}

	public void GetInventory (){
		//To be deleted once proper inventory UI is implemented
		string report = "Currently held items: ";
		foreach (string item in inventory) {
			report += item + (", ");
		}
		Debug.Log (report);
	}

    public bool HasItem(string item)
    {
        foreach (string i in inventory)
        {
            if (item == i)
            {
                return true;
            }
        }
        return false;
    }

	public void AddInventory(string itemName){
		inventory.Add (itemName);
	}
}
