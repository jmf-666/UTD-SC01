using UnityEngine;
using UnityEngine.EventSystems;

public class Spot : MonoBehaviour {

    
    private ISelectorResponse selectorResponse;
    private IBuilder builder;
    private IInteractor interactor;

    private Transform currentSpot;

    private void Awake()
    {
        
        selectorResponse = GetComponent<ISelectorResponse>();
        builder = GetComponent<IBuilder>();
        interactor = GetComponent<IInteractor>();
        interactor.OnInteractEvent += () => SpotInteract();
    }


	[HideInInspector]
	public GameObject unitObject;
	[HideInInspector]
	public UnitData unit;
	[HideInInspector]
	public bool isUpgraded = false;

    private void Update()
    {
        if (BuildManager.instance.CurrentSpot != null)
        {
            if (this.transform == BuildManager.instance.CurrentSpot)
                interactor.GetInteractInput();
        }
    }

    void SpotInteract()
    {     
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (BuildManager.instance.CurrentSpot == null)
            return;
        if (unitObject != null)
        {
            //buildManager.SelectSpot(this);
            return;
        }


        unitObject = builder.Build(BuildManager.instance.GetUnitToBuild());
    }


}
