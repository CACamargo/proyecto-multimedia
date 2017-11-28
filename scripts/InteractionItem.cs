using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour {

    public float rayDistance;
    public RaycastHit hit;
    private GameObject item;
	private bool isCarrying;
	private float throwForce;
    public PuzzleManager puzzleManager;

    // Use this for initialization
    void Start () {
		isCarrying = false;
		throwForce = 10;
        puzzleManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.E)) {
			if (isCarrying) {
				item.transform.parent = null;
				item.GetComponent<Rigidbody> ().isKinematic = false; 
				isCarrying = false;

			} else if (Physics.Raycast (transform.position, transform.forward, out hit, rayDistance)) {
                if (hit.collider)
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.tag == "GenericItem")
                    {
                        item = hit.collider.gameObject;
                        item.transform.parent = gameObject.transform;
                        item.GetComponent<Rigidbody>().isKinematic = true;
                        isCarrying = true;
                    }
                    else if (hit.collider.gameObject.tag == "PuzzleItem")
                    {
                        item = hit.collider.gameObject;
                        puzzleManager.SolvePuzzle(item.name);
                    }
                }
			}

		} else if (isCarrying && Input.GetKey (KeyCode.Mouse0)) {
			item.transform.Rotate (Vector3.forward * Time.deltaTime * 30);
			/*item.transform.parent = null;
			item.GetComponent<Rigidbody> ().isKinematic = false; 
			item.GetComponent<Rigidbody> ().AddForce (transform.forward*throwForce);*/
		}
    }
}
