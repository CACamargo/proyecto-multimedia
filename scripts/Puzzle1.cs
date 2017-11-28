using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour {

    public GameObject[] lights;
    public GameObject truck1, truck2;
    public GameObject sound1, sound2, sound3;
    public bool isActive;

    // Use this for initialization
    void Start () {
        isActive = false;
        lights = new GameObject[11];
        lights[0] = GameObject.Find("Point light 14");
        lights[1] = GameObject.Find("Point light 16");
        lights[2] = GameObject.Find("Point light 17");
        lights[3] = GameObject.Find("Point light 21");
        lights[4] = GameObject.Find("Point light 45");
        lights[5] = GameObject.Find("Point light 60");
        lights[6] = GameObject.Find("Point light 61");
        lights[7] = GameObject.Find("Point light 62");
        lights[8] = GameObject.Find("Point light 52");
        lights[9] = GameObject.Find("Point light 7");
        lights[10] = GameObject.Find("Point light 12");
        truck1 = GameObject.Find("truck");
        truck2 = GameObject.Find("truck 5");
        sound1 = GameObject.Find("Trig_object_p1_1");
        sound2 = GameObject.Find("Trig_object_p1_2");
        sound3 = GameObject.Find("Trig_object_p1_3");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Begin()
    {
        isActive = true;
        for (int i = 0; i < lights.Length; ++i)
        {
            lights[i].SetActive(false);
        }
        sound1.GetComponent<AudioSource>().Play();
        
    }
    public void End()
    {
        isActive = false;
        for (int i = 0; i < lights.Length; ++i)
        {
            lights[i].SetActive(true);
        }
        sound2.GetComponent<AudioSource>().Play();
        sound3.GetComponent<AudioSource>().Play();
        truck1.SetActive(false);
        truck2.SetActive(false);
    }

    public bool IsActive()
    {
        return isActive;
    }
}
