using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataMaterialHole
{
    public Material material;
    public JunkColor color;
}

[CreateAssetMenu(menuName ="MaterialHolder",fileName ="materialsHolder")]

public class MaterialHolder : ScriptableObject
{

    public List<DataMaterialHole> dataMaterialHoles = null;



    public Material FindMaterialByName(JunkColor type)
    {
        //if (materialDictionary == null)
        //{
        //    InitializeMaterialDictionary();
        //}

        foreach(var it in dataMaterialHoles)
        {
            if(it.color.Equals(type))
            {
                return it.material;
            }
        }

        return null;
        
    }

    public List<DataMaterialHole> GetRandomMaterials(int count)
    {
        if (dataMaterialHoles == null || dataMaterialHoles.Count == 0)
        {
            Debug.Log("Material list is empty!");
            return null;
        }

        // Shuffle the materialsList
        List<DataMaterialHole> shuffledMaterials = new List<DataMaterialHole>(dataMaterialHoles);
        System.Random rng = new System.Random();
        int n = shuffledMaterials.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            DataMaterialHole value = shuffledMaterials[k];
            shuffledMaterials[k] = shuffledMaterials[n];
            shuffledMaterials[n] = value;
        }

        // Take the first 'count' materials from the shuffled list
        List<DataMaterialHole> randomMaterials = new List<DataMaterialHole>();
        for (int i = 0; i < Mathf.Min(count, shuffledMaterials.Count); i++)
        {
            randomMaterials.Add(shuffledMaterials[i]);
        }

        return randomMaterials;
    }
}
