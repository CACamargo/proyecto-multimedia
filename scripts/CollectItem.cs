using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour {

	public float rayDistance;
	public RaycastHit hit;
	private GameObject item, player, gameCanvas;
    public AudioSource _AudioSource;
    public AudioClip clipCollected;
    public PuzzleManager puzzleManager;


    // Use this for initialization
    void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
        gameCanvas = GameObject.FindGameObjectWithTag("Journal");
        puzzleManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
			{
				if (hit.collider)
				{
					//Debug.Log (hit.collider.gameObject.name);
					if (hit.collider.gameObject.tag == "CollectibleItem")
					{
						item = hit.collider.gameObject;
						player.GetComponent<PlayerLogic> ().AddInventory (item.name);
                        _AudioSource.Stop();
                        _AudioSource.clip = clipCollected;
                        _AudioSource.Play();
                        Destroy (item);
					}
                    else if (hit.collider.gameObject.tag == "LoreItem")
                    {
                        item = hit.collider.gameObject;
                        LoreProperties props = item.GetComponent<LoreProperties>();
                        string message = props.GetMessage();

                        gameCanvas.GetComponent<Journal>().AddMessage(message);
                        if (item.name != "book4")
                        {
                            _AudioSource.Stop();
                            _AudioSource.clip = clipCollected;
                            _AudioSource.Play();                            
                        }
                        if (props.IsSolution())
                            puzzleManager.SolvePuzzle(item.name);
                        Destroy(item);
                    }

                }
			}
		}		
	}
}
