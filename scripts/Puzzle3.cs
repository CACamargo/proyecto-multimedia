using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{

    public bool isActive;
    public GameObject door, light1, light2, sound;
    Animation anim;

    // Use this for initialization
    void Start()
    {
        isActive = false;
        door = GameObject.Find("Plane012p");
        sound = GameObject.Find("Trig_object_p3");
        light1 = GameObject.Find("Point light 55");
        light2 = GameObject.Find("Point light 56");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Begin()
    {
        isActive = true;
        anim = door.GetComponent<Animation>();
        anim.Play("Plane012p");
    }
    public void End()
    {
        isActive = false;
        StartCoroutine(Finish());
      }

    public bool IsActive()
    {
        return isActive;
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(3);
        sound.GetComponent<AudioSource>().Play();
        light1.SetActive(false);
        light2.SetActive(false);
    }
}
