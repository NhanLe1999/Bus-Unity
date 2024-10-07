using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI spinItem = null;
    [SerializeField] Image imgItem = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDataBuy(DataBuy da, Sprite sp)
    {
        imgItem.sprite = sp;
        imgItem.SetNativeSize();
        spinItem.text = $"x{da.numItemReciver}";
    }    

    public void SetText(string txt)
    {
        spinItem.text = txt;
    }
}
