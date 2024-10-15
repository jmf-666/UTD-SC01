using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUnitDataButton : Button
{
    [SerializeField] private UnitData data; //<-- ASSIGN SCRIPTABLE OBJECT HERE

    [SerializeField] private Text dataCost;
    [SerializeField] private Image dataImage;

    protected override void Awake()
    {
        dataCost.text = data.Cost.ToString();
        dataImage.sprite = data.Icon;
    }

    public override void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        BuildManager.instance.SelectUnitToBuild(data);
        base.OnPointerClick(eventData);
    }
}
