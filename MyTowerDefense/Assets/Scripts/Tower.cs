using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance.LevelTarget = this.transform;     
    }


}
