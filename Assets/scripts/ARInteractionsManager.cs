using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteractionsManager : MonoBehaviour
{
    [SerializeField] private Camera aRCamera;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject aRPointer;
    private GameObject item3DModel;
    private bool isInitialPosition;

    public GameObject Item3DModel
    {
        set
        {
            item3DModel = value;
            item3DModel.transform.position = aRPointer.transform.position;
            item3DModel.transform.parent = aRPointer.transform;
            isInitialPosition = true;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        GameManager.Instance.OnMainMenu += SetItemPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (isInitialPosition)
        {
            Vector2 middlePointScreen = new Vector2(Screen.width / 2, Screen.height / 2);

            // Realiza el Raycast en la dirección que está viendo la cámara
            aRRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes);

            if (hits.Count > 0)
            {
                // Coloca el ARPointer en la posición del plano detectado frente a la cámara
                aRPointer.transform.position = hits[0].pose.position;
                aRPointer.transform.rotation = hits[0].pose.rotation;
                aRPointer.SetActive(true);

                // Posiciona el item3DModel en la ubicación detectada y lo orienta
                if (item3DModel != null)
                {
                    item3DModel.transform.position = hits[0].pose.position;
                    item3DModel.transform.rotation = hits[0].pose.rotation;
                }

                isInitialPosition = false;
            }
        }
    }



    private void SetItemPosition()
    {
        if (item3DModel != null)
        {
            item3DModel.transform.parent = null;
            aRPointer.SetActive(false);
            item3DModel = null;
        }
    }
    public void DeleteItem()
    {
        Destroy(item3DModel);
        aRPointer.SetActive(false);
        GameManager.Instance.MainMenu();
    }

}
