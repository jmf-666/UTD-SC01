using UnityEngine;

public class OutlineSelectionResponse : MonoBehaviour, ISelectorResponse
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color notSelectableColor;

    public void OnSelect()
    {
        if (!BuildManager.instance.CanBuild)
            return;
  
        var outline = this.GetComponent<Outline>();
        
        if (outline != null)
        {
            if (BuildManager.instance.HasMoney)
            {
                outline.OutlineColor = hoverColor;
            }
            else
            {
                outline.OutlineColor = notSelectableColor;
            }                         
            outline.OutlineWidth = 10;
        }
    }



    public void OnDeselect()
    {
        var outline = this.GetComponent<Outline>();
        if (outline != null)
        {
            outline.OutlineWidth = 0;
        }
    }
}