using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace TJ.Scripts
{
    public class ParkingSlots : MonoBehaviour
    {
        public Transform enterPoint;
        public Transform stopPoint;

        public bool isOccupied;
        [SerializeField] private GameObject normal;
        [SerializeField] private GameObject locked;

        // Start is called before the first frame update
        void Start()
        {
            enterPoint = transform.GetChild(0).transform;
            stopPoint = transform.GetChild(1).transform;
        }

        /*private void OnTriggerStay(Collider other)
        {
            isOccupied = true;
        }*/
        private void OnMouseDown()
        {
          
        }

        public void OnMouseClick()
        {
            if (GameManager.instance.gameOver || EventSystem.current.IsPointerOverGameObject())
                return;
            var slots = ParkingManager.instance.slots;
            if (!slots.Contains(this))
            {
                slots.Add(this);
                locked.SetActive(false);
                normal.SetActive(true);
            }
            Debug.Log("Added Slot");
        }
    }
}