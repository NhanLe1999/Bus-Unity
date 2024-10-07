using System;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public static Helper instance;

    public Transform[] points;
    public BoxCollider[] vehicleColliders;

    public GameObject handIcon;
    public TextMeshPro info;
    public string carTXT;
    public string vanTXT;
    public string busTXT;

    public Vector3 pointAdd = Vector3.zero;

    private int count = 0;


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
            points[i] = vec.transform;
            vehicleColliders[i] = vec.GetComponent<BoxCollider>();
        }

        onInit();
    }


    private void onInit()
    {
        if (points.Length > 0)
            handIcon.transform.DOMove(points[0].position + pointAdd, 0.5f);
        if (vehicleColliders.Length > 0)
            vehicleColliders[0].enabled = true;
    }

    public void MoveHand()
    {
        count++;
        if (count < points.Length && count < vehicleColliders.Length)
        {
            handIcon.transform.DOMove(points[count].position + pointAdd, 0.5f);
            vehicleColliders[count].enabled = true;
        }
        else
        {
            handIcon.SetActive(false);
        }

        var vech = vehicleColliders[count].GetComponent<Vehicle>();
        var set = vech.SeatCount;

        info.text = set switch
        {
            4 => carTXT,
            10 => busTXT,
            6 => vanTXT,
            _ => info.text
        };
    }
}