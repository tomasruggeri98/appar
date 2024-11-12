using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    [SerializeField] private List<Item> Items = new List<Item>();
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private ItemButtonManager itemButtonManager;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnItemsMenu += CreateButton;
    }

    private void CreateButton()
    {
        foreach (var item in Items)
        {
            ItemButtonManager itemButton;
            itemButton = Instantiate(itemButtonManager, buttonContainer.transform);
            itemButton.ItemName = item.ItemName;
            itemButton.ItemDescription = item.ItemDescription;
            itemButton.ItemImage = item.ItemImage;
            itemButton.Item3DModel = item.Item3DModel;
            itemButton.name = item.ItemName;
        }

        GameManager.Instance.OnItemsMenu -= CreateButton;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
