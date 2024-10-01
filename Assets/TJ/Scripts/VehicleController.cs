using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace TJ.Scripts
{
    public class VehicleController : MonoBehaviour
    {
        public static VehicleController instance;
        public Vehicle[] vehicles;
        public int totalPlayersCount;
        public int playerCount;
        public TextMeshPro totalPlayerDisplay;
        public Transform Road;
        public PlayerManager playerManager;
        public MaterialHolder VehiclesMaterialHolder;
        public MaterialHolder stickmanMaterialHolder;
        public Transform rightCollider;
        public Transform leftCollider;
        public int totalSeats;
        public int totalVehicles;
        public bool shuffle = true;

        private void Awake()
        {
            instance = this;

            if (shuffle == true)
                vehicles = GetComponentsInChildren<Vehicle>(true);

            if(vehicles.Length > 0)
            {
                totalVehicles = vehicles.Length;
                CalculatePlayersCount();
                CalculateTotalSeat();
            }
        }

        public void Init()
        {
            if (shuffle == true)
                vehicles = GetComponentsInChildren<Vehicle>(true);
            CalculatePlayersCount();
            CalculateTotalSeat();
            totalVehicles = vehicles.Length;
        }

        private void CalculateTotalSeat()
        {
            totalSeats = vehicles.Sum(v => v.SeatCount);
        }

        private void Start()
        {
            playerCount = totalPlayersCount;
         //   totalPlayerDisplay.text = playerCount.ToString();
            totalVehicles = vehicles.Length;
        }

        public void UpdatePlayerCount()
        {
            playerCount--;
           // totalPlayerDisplay.text = playerCount.ToString();
        }

        [ContextMenu("random")]
        public void RandomVehColor()
        {
            System.Random r = new System.Random();
            JunkColor[] values = (JunkColor[])Enum.GetValues(typeof(JunkColor));
            List<JunkColor> colors = new(values);
            colors = colors.OrderBy(x => r.Next()).ToList();
            int colorIndex = 0;
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (colorIndex >= colors.Count)
                {
                    colorIndex = 0;
                }

                JunkColor color = colors[0];
                vehicles[i].ChangeColor(colors[colorIndex]);
                colorIndex++;
            }
        }

        public void RandomVehicleColors()
        {
            var groupedVehicles = vehicles.GroupBy(v => v.SeatCount);

            foreach (var group in groupedVehicles)
            {
                List<JunkColor> existingColors = new List<JunkColor>();
                foreach (var vehicle in group)
                {
                    existingColors.Add(vehicle.vehicleColor);
                }

                System.Random r = new System.Random();
                existingColors = existingColors.OrderBy(x => r.Next()).ToList();
                int index = 0;
                foreach (var vehicle in group)
                {
                    vehicle.ChangeColor(existingColors[index]);
                    index++;
                }
            }
        }

        [ContextMenu("changecolor of vehicles")]
        public void ChangeParkingCarsColor()
        {
            List<Vehicle> parkingVehicles = new List<Vehicle>();

            for (int i = 0; i < vehicles.Length; i++)
            {
                parkingVehicles.Add(vehicles[i]);
            }

            parkingVehicles.RemoveAll(v => ParkingManager.instance.parkedVehicles.Contains(v));

            var groupedVehicles = parkingVehicles.GroupBy(v => v.SeatCount).ToList();

            System.Random r = new System.Random();

            foreach (var group in groupedVehicles)
            {
                var vehicleGroup = group.ToList();

                vehicleGroup = vehicleGroup.OrderBy(x => r.Next()).ToList();

                JunkColor firstVehicleColor = vehicleGroup[0].vehicleColor;

                for (int i = 0; i < vehicleGroup.Count - 1; i++)
                {
                    vehicleGroup[i].ChangeColor(vehicleGroup[i + 1].vehicleColor);
                }

                vehicleGroup[^1].ChangeColor(firstVehicleColor);
            }
        }

        public void RemoveVehicle(Vehicle vehicleToRemove)
        {
            List<Vehicle> vehicleList = vehicles.ToList();

            vehicleList.Remove(vehicleToRemove);

            vehicles = vehicleList.ToArray();
        }

        public void CalculatePlayersCount()
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                totalPlayersCount += vehicles[i].SeatCount;
            }

            playerManager.InstantiatePlayers(vehicles);
        }
    }
}