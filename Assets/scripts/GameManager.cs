using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action OnMainMenu;
    public event Action OnItemsMenu;
    public event Action OnARPosition;

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional si deseas que GameManager persista entre escenas.
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
        
    }

    public void MainMenu()
    {
        OnMainMenu?.Invoke();
        Debug.Log("MainMenu Activo");

    }

    public void ItemMenu()
    {
        OnItemsMenu?.Invoke();
        Debug.Log("ItemMenu Activo");

    }

    public void ARPositionMenu()
    {
        OnARPosition?.Invoke();
        Debug.Log("ARPosition Activo");
    }

    public void CloseAPP()
    {
        Application.Quit();
    }
}