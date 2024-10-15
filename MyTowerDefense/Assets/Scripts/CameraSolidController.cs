using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSolidController : MonoBehaviour
{
    private IZoomAndPanProvider zoomAndPanProvider;
    private ITransposer transposer;
    private IRayProvider rayProvider;
    private ISelector selector;
    

    private Transform currentSelection;
    private Transform previousSelection;
    private ISelectorResponse response;

    private void Awake()
    {
        zoomAndPanProvider = GetComponent<IZoomAndPanProvider>();
        transposer = GetComponent<ITransposer>();
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();
    }


    // Update is called once per frame
    void Update()
    {
        transposer.Pan(zoomAndPanProvider.GetPanDirection());
        transposer.Zoom(zoomAndPanProvider.GetZoom());
        selector.CheckRay(rayProvider.RayCast());
        currentSelection = selector.GetSelected();

        if (currentSelection != null)
        {
            if(previousSelection != currentSelection)
            {
                Deselect();
            }
            Select();            
        } else
        {
            Deselect();
        }
    }

    void Select()
    {
        response = currentSelection.GetComponent<ISelectorResponse>();
        if (response != null)
            response.OnSelect();
        BuildManager.instance.CurrentSpot = currentSelection;
    }

    void Deselect()
    {
        if (response != null)
            response.OnDeselect();
        response = null;
    }
}
