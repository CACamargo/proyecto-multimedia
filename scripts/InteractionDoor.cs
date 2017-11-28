using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoor : MonoBehaviour {

    public float rayDistance;
    public RaycastHit hit;
    private int state;
    private Animation anim;
    private Animator animT;
    private GameObject door;
    private AnimStates doorState;
    private GameObject player;
    public AudioSource _AudioSource;
    public AudioClip clipLocked;
    private int doorHit;

    // Use this for initialization
    void Start()
    {
        doorHit = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
            {
                if (hit.collider)
                {

                    if (hit.collider.gameObject.tag == "GenericDoor")
                    {
                        doorHit = 1;    // Normal door
                    }

                    else if (hit.collider.gameObject.tag == "LockedDoor")
                    {
                        doorHit = 2;    // Locked door
                    }

                    if (doorHit > 0)
                    {
                        bool locked = false;
                        PlayerLogic playerLogic = player.GetComponent<PlayerLogic>();
                        door = hit.collider.gameObject;

                        if (doorHit == 2)
                        {                           
                            LockState lockState = door.GetComponent<LockState>();
                            string key = lockState.getKeyName();

                            if (playerLogic.HasItem(key))
                                lockState.unlock();

                            locked = lockState.getState();
                        }

                        if (locked == false)
                        {
                            door.GetComponent<AudioSource>().Play();
                            doorState = door.GetComponent<AnimStates>();
                            Animation anim = door.GetComponent<Animation>();
                            anim.Play(doorState.states[doorState.getState()]);
                            doorState.incState();

                            if (doorHit == 2)
                            {

                                door.tag = "GenericDoor";
                            }
                        }
                        else
                        {
                            _AudioSource.Stop();
                            _AudioSource.clip = clipLocked;
                            _AudioSource.Play();
                        }                                                                
                  
                        doorHit = 0;
                    }
                }
            }
        }
    }
}
