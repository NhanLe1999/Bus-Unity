using _Game.Scripts.Bus;
using System.Collections;
using System.Collections.Generic;
using TJ.Scripts;
using UnityEngine;

public class LoadDataGame : Singleton<LoadDataGame>
{
    [SerializeField] BusLevelSO levelSO = null;

    [SerializeField] GameObject prefabCar;
    [SerializeField] GameObject prefabVan;
    [SerializeField] GameObject prefabBus;

    [SerializeField] Transform parent;
    [SerializeField] VehicleController vehicleController;

    [SerializeField] float scaleAdd = 0.0f;

    public bool IsPause = false;


    // Start is called before the first frame update
    void Start()
    {

        levelSO = GetLevel();

        foreach (var da in levelSO.busPosDatas)
        {
            var obj = GetObjectIntanceBus(da.type);

            var objIn = Instantiate(obj, parent);
            //  var cpn = objIn.GetComponent<Vehicle>();

            //  cpn.StartCoroutine(cpn.SetPoint(da.position));

            objIn.transform.position = da.position;

            objIn.transform.rotation = da.rotation;

            objIn.transform.localScale += Vector3.one * scaleAdd;
        }

        vehicleController.Init();
    }

    BusLevelSO GetLevel()
    {
        int num = HelperManager.DataPlayer.NumLevel;
        while (true)
        {
            var level = Resources.Load<BusLevelSO>("Level/Level_" + num.ToString());
            if(level != null)
            {
                return level;
            }
            else
            {
                num++;
            }
        }
        return null;
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

    private void OnDestroy()
    {
        HelperManager.Save();
    }
}
