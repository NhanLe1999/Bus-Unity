using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TJ.Scripts
{
    public class ParkingManager : MonoBehaviour
    {
        public static ParkingManager instance;
        public List<ParkingSlots> slots;
        public List<Vehicle> parkedVehicles;
        

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

        private void Update()
        {
            
        }
    }
}