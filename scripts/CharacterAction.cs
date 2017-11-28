using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour {
	public GameObject SpotLight;
    public Camera _Camera;
    public CharacterController _CharacterController;
    private bool active;
    public float SpeedField;    

    // Use this for initialization
    void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			SpotLight.SetActive (active);
			if (active == true)
				active = false;
			else
				active = true;
		}
	}

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (_CharacterController.height > 1)
            {
                _CharacterController.height -= 2.0f * Time.deltaTime;
            }
        }
        else
        {
            _CharacterController.height = 1.8f;
        }
        
        if (Input.GetMouseButton(1))
        {
            if (_Camera.fieldOfView > 50)
            {
                _Camera.fieldOfView -= SpeedField * Time.deltaTime;
            }                
        }
        else
        {
            if (_Camera.fieldOfView < 60)
            {
                _Camera.fieldOfView += SpeedField * Time.deltaTime;
            }              
        }
    }
}
