using System;
using TJ.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ParkingSlots : MonoBehaviour
{
    public Transform enterPoint;
    public Transform stopPoint;

    public bool isOccupied;
    [SerializeField] private GameObject normal;
    [SerializeField] private GameObject locked;

    [SerializeField] private SpriteRenderer sprRenderSlot;

    public Action callbackAds;

    // Start is called before the first frame update
    void Start()
    {
        enterPoint = transform.GetChild(0).transform;
        stopPoint = transform.GetChild(1).transform;
        sprRenderSlot = transform.Find("slot").GetComponent<SpriteRenderer>();
    }

    /*private void OnTriggerStay(Collider other)
    {
        isOccupied = true;
    }*/
    private void OnMouseDown()
    {

    }

    public void SetCallbackShowAds(Action callback)
    {
        callbackAds = callback;
    }

    public void ShowAds()
    {
        PowerUps.instance.ShowPoupRemoveSlot(this);
    }

    public void OnAdsSucess()
    {
        if (GameManager.instance.gameOver)
            return;
        var slots = ParkingManager.instance.slots;
        if (!slots.Contains(this))
        {
            slots.Add(this);
            locked?.SetActive(false);
            normal?.SetActive(true);
        }
        Debug.Log("Added Slot");
    }

    public void LoadSprSkillVip(bool isBegin)
    {
        sprRenderSlot.sprite = isBegin ? ParkingManager.instance.sprVip : ParkingManager.instance.sprSlotCurrent;
    }

    public void OnMouseClick()
    {
       
    }
}