using _Game.Scripts.Bus;
using System.Collections;
using System.Collections.Generic;
using TJ.Scripts;
using UnityEngine;

public class LoadDataGame : MonoBehaviour
{
    [SerializeField] BusLevelSO levelSO = null;

    [SerializeField] GameObject prefabCar;
    [SerializeField] GameObject prefabVan;
    [SerializeField] GameObject prefabBus;

    [SerializeField] Transform parent;


    // Start is called before the first frame update
    void Start()
    {
        foreach(var da in levelSO.busPosDatas)
        {
            var obj = GetObjectIntanceBus(da.type);

            var objIn = Instantiate(obj, parent);
            //  var cpn = objIn.GetComponent<Vehicle>();

            //  cpn.StartCoroutine(cpn.SetPoint(da.position));

            objIn.transform.position = da.position;

            objIn.transform.rotation = da.rotation;
        }
    }

    private GameObject GetObjectIntanceBus(BusType type)
    {
       switch(type)
        { 
            case BusType.Car:
                return prefabCar;
            case BusType.Van:
                return prefabVan;
            case BusType.Bus:
                return prefabBus;
            default:
                return null;
        }
    }
    
}
