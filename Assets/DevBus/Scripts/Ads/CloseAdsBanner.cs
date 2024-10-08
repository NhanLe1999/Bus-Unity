using DG.Tweening;
using MobileMonetizationPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseAdsBanner : MonoBehaviour
{
    [SerializeField] Transform _point1 = null;
    [SerializeField] Transform _point2 = null;

    [SerializeField] Canvas canvas;
    [SerializeField] RectTransform GameObjectClose = null;
    [SerializeField] RectTransform objSetPoin = null;

    public void OnCloseAdsBanner()
    {
        MobileMonetizationPro_LevelPlayInitializer.instance.DestroyBanner();
        transform.DOMoveY(transform.position.y - 200, 1.0f).OnComplete(() => {
            Destroy(transform.gameObject);
        });

    }

    private void Awake()
    {
        if(objSetPoin != null)
        {
            objSetPoin.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(OnSetSizeForObject());
    }
    

    IEnumerator OnSetSizeForObject()
    {
        yield return new WaitForSeconds(0.1f);
       /* var p1 = HelperManager.ConvertPointCanvas(Camera.main, canvas, _point1.position, Camera.main);
        var p2 = HelperManager.ConvertPointCanvas(Camera.main, canvas, _point2.position, Camera.main);
        var rectS = gameObject.GetComponent<RectTransform>();
        rectS.sizeDelta = new Vector2(rectS.sizeDelta.x, rectS.sizeDelta.y + Vector2.Distance(p1, p2));
        GameObjectClose.localPosition = new Vector2(GameObjectClose.localPosition.x, rectS.sizeDelta.y + 100 - 10);
        if(objSetPoin != null)
        {
            objSetPoin.anchoredPosition = new Vector2(objSetPoin.localPosition.x, rectS.sizeDelta.y);
            objSetPoin.gameObject.SetActive(true );
        }*/
    }
}
