using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour {

    public GameObject journal;
    public GameObject messagePrefab;
    public GameObject container;
    public bool showToast;
    public Transform toastContainer;
    private List<string> messageTextList;
    private bool isVisible, isFirstTime = true;

    void Start ()
    {
        messageTextList = new List<string>();
        isVisible = false;
        journal.SetActive(false);
        // In case we forget to add change the variable.
        if (toastContainer == null)
        {
            showToast = false;
        }
    }

    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleGUI();
        }
        if (isFirstTime)
        {
            this.AddMessage("[You] Huh? W-where am I?");
            isFirstTime = false;
        }
    }

    public void AddMessage (string message)
    {
        // Add to the message list for later use, persist.
        messageTextList.Add(message);
        // Add the message to the visual log of message with a prefab for layout.
        GameObject newMessage = Instantiate(messagePrefab) as GameObject;
        newMessage.transform.SetParent(container.transform, false);
        newMessage.GetComponentInChildren<Text>().text = message;
        // Show the message briefly in a toast like notification.
        if (showToast)
        {
            ShowToast(message);
        }
    }

    private void ShowToast(string message)
    {
        Text text = toastContainer.GetComponentInChildren<Text>();
        text.text = message;
        Animator textAnimator = toastContainer.GetComponent<Animator>();
		textAnimator.SetTime (0);
        textAnimator.Play("ShowToast");
    }

    private void ToggleGUI() 
    {
        isVisible = !isVisible;
        journal.SetActive(isVisible);
    }
}
