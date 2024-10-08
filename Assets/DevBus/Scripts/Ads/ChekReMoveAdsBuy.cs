using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekReMoveAdsBuy : MonoBehaviour
{
    void Start()
    {
        
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("AdsRemoved", 0) == 1)
        {
            gameObject.SetActive(false);
        }

    }

}
