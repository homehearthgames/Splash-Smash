using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonHandler : MonoBehaviour
{
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        // Add an event listener to the button's OnClick event
        backButton.onClick.AddListener(OnBackButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the user has pressed the escape key on the keyboard or the options button on the controller
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel"))
        {
            // Fire the button's OnClick event
            backButton.onClick.Invoke();
        }
    }

    void OnBackButtonClick()
    {
        // Handle the button click event here
        Debug.Log("Back button clicked!");
    }
}
