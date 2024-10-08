using System.Collections;
using System.Collections.Generic;
using TJ.Scripts;
using UnityEngine;

public class LoadDataGame : SingletonMono<LoadDataGame>
{
    [SerializeField] BusLevelSO levelSO = null;

    [SerializeField] GameObject prefabCar;
    [SerializeField] GameObject prefabVan;
    [SerializeField] GameObject prefabBus;

    [SerializeField] GameObject PefabGarageObstacle;
    [SerializeField] Transform parent;
    public VehicleController vehicleController;
    [SerializeField] float scaleAdd = 0.0f;

    [SerializeField] Transform objHelp = null;

    public bool IsPause = false;
    [SerializeField] Vector3 pointAdd = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {

        levelSO = GetLevel();

        List<Garage> garages = new();

        foreach (var turn in levelSO.tunnelDataPacks)
        {
            var obj = Instantiate(PefabGarageObstacle, parent);
            obj.transform.position = turn.position + pointAdd;
            obj.transform.rotation = turn.rotation * Quaternion.Euler(0, 180, 0);

            var ga = obj.GetComponent<Garage>();
            ga.tunnelDataPack = turn;
            garages.Add(ga);

            foreach(var bus in turn.datas)
            {
                var objBus = GetObjectIntanceBus(bus.busType);
                var objIn = Instantiate(objBus, parent);
                objIn.transform.parent = parent;
                objIn.SetActive(false);
                objIn.transform.position = obj.transform.position;
                objIn.transform.rotation = obj.transform.rotation * Quaternion.Euler(0, 180, 0);

                var cpn = objIn.GetComponent<Vehicle>();
                ga.vehicles.Add(cpn);
                cpn.ChangeColor(bus.color);
            }
        }

        for(int i = 0; i < levelSO.busPosDatas.Count; i++)
        {
            var da = levelSO.busPosDatas[i];
            Garage gara = null;
            foreach (var ga in garages)
            {
                if(i.Equals(ga.tunnelDataPack.lockBusIndex))
                {
                    gara = ga;
                    break;
                }
            }

            var obj = GetObjectIntanceBus(da.type);

            var objIn = Instantiate(obj, parent);
            objIn.name = i.ToString();

            objIn.transform.position = da.position + pointAdd;
            objIn.transform.rotation = da.rotation;
            objIn.transform.localScale += Vector3.one * scaleAdd;

            if(da.type.Equals(BusType.Bus))
            {
                objIn.transform.position += new Vector3(0, 0.091f, 0);
            }

            var cpn = objIn.GetComponent<Vehicle>();
            cpn.ChangeColor(da.color);
            cpn.busPosData = da;

            if(gara != null)
            {
                gara.obstacle.Add(cpn);
            }
        }

        foreach (var ga in garages)
        {
            ga.Init();
        }

        vehicleController.Init();

        if(HelperManager.DataPlayer.NumLevel == 1)
        {
            IsPause = true;
            objHelp.gameObject.SetActive(true);
        }

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

    public void ResetStateGame()
    {
        this.StartCoroutine(ResetPause());
    }    

    IEnumerator ResetPause()
    {
        yield return new WaitForSeconds(0.25f);
        IsPause = false;
    }

    private void OnDestroy()
    {
        HelperManager.Save();
    }
}
