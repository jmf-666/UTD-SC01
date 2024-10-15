using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text moneyLabel;
    public Text livesLabel;

    // Update is called once per frame
    void Update()
    {
        moneyLabel.text = "$" + PlayerStatsManager.instance.Money.ToString();
        livesLabel.text = PlayerStatsManager.instance.Lives.ToString();
    }
}
