using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ParkingManager : MonoBehaviour
{
    public static ParkingManager instance;
    public List<ParkingSlots> slots;
    public List<ParkingSlots> slotsAll;
    public List<Vehicle> parkedVehicles;
    public Sprite sprVip = null;
    public Sprite sprSlotCurrent = null;


    public Transform exitPoint;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //slots = FindObjectsOfType<ParkingSlots>().ToList();
    }

    public ParkingSlots CheckForFreeSlot()
    {

        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].isOccupied)
            {
                return slots[i];
            }
        }
        return null;
    }

    public ParkingSlots GetItemAds()
    {
        for (int i = 0; i < slotsAll.Count; i++)
        {
            if (slotsAll[i].isItemAds)
            {
                return slotsAll[i];
            }
        }
        return null;
    }
    private void Update()
    {

    }
}