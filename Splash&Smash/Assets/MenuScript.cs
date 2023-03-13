using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    public EventSystem eSystem;
    private GameObject storeSelected;
    public GameObject levelSelectButton;
    public GameObject optionsButton;

    void Start()
    {
        storeSelected = eSystem.firstSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (eSystem.currentSelectedGameObject!= storeSelected)
        {
            if (eSystem.currentSelectedGameObject == null)
            {
                eSystem.SetSelectedGameObject(storeSelected);
            }
            else
                storeSelected = eSystem.currentSelectedGameObject;
            Debug.Log("Sel:" + eSystem.currentSelectedGameObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse was clicked over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {

                Debug.Log("Clicked on the UI");
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                pointerData.pointerId = -1;
                //pointerData.position = Mouse.current.position.ReadValue();
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, results);

                foreach (var result in results)
                {
                    Debug.Log("Clicked:" + result.gameObject);
                }

            }


        }



    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
    }

    private void OnMouseEnter()
    {
        Debug.Log("*******************");
    }


}
