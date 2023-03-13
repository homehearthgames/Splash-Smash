using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuInput : MonoBehaviour
{
    public static MenuInput Instance { get; private set; }
    public GameObject firstButton;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SelectMenuItem()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
