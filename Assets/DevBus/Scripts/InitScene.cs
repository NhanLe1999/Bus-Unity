using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    void Start()
    {
        HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
    }

}
