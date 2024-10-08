using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public static Helper instance;

    public List<Transform> points;
    public List<Vehicle> vehicles;

    public GameObject handIcon;
    public TextMeshPro info;
    public string carTXT;
    public string vanTXT;
    public string busTXT;

    public Vector3 pointAdd = Vector3.zero;

    private int count = 0;

    int Seatcount = 0;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       
    }

    private void OnEnable()
    {
        for (int i = 0; i < LoadDataGame.Instance.vehicleController.vehicles.Length; i++)
        {
            var vec = LoadDataGame.Instance.vehicleController.vehicles[i];

            points.Add(vec.transform);
            vehicles.Add(vec.GetComponent<Vehicle>());
            vehicles[i].IsRun = false;
        }

        onInit();
    }


    private void onInit()
    {
        if (points.Count > 0)
            handIcon.transform.DOMove(points[0].position + pointAdd, 0.5f);
        if (vehicles.Count > 0)
        {
            Seatcount = vehicles[0].SeatCount;
            vehicles[0].IsRun = true;
        }
    }

    public void MoveHand()
    {
        count++;
        if (count < points.Count && count < vehicles.Count)
        {
            handIcon.transform.DOMove(points[count].position + pointAdd, 0.5f);
            vehicles[count].IsRun = true;
            Seatcount = vehicles[count].SeatCount;
        }
        else
        {
            handIcon.SetActive(false);
        }


        info.text = Seatcount switch
        {
            4 => carTXT,
            10 => busTXT,
            6 => vanTXT,
            _ => info.text
        };
    }
}