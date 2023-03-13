using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    public GameObject firstButton;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Sel:" + EventSystem.current.currentSelectedGameObject);
    }

    private void OnMouseEnter()
    {
        Debug.Log("*******************");
    }


}
