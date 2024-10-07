using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDailyBonus : MonoBehaviour
{
    [SerializeField] Image imgBG = null;
    [SerializeField] List<TextMeshProUGUI> txtMesh;
    [SerializeField] GameObject objTick = null;

    [SerializeField] TextMeshProUGUI txtDay = null;

    public Image imgSpr = null;

    private DataDailyBonus dataDaily;

    [SerializeField] private Sprite spriteBg = default;
    private Sprite currentSprite = null;

    public DataDailyBonus DataDaily => dataDaily;

    private void Awake()
    {
        currentSprite = imgBG.sprite;
    }

    void Start()
    {
        
    }

    public void SetImgBg(Sprite sp)
    {
        if(currentSprite == null)
        {
            currentSprite = imgBG.sprite;
        }

        if(spriteBg == null)
        {
            spriteBg = sp;
        }
    }    

    public void SetData(DataDailyBonus da)
    {
        dataDaily = da;
    }

    public void UpdateUi()
    {
        for (int i = 0; i < txtMesh.Count; i++)
        {
            txtMesh[i].text = "x" + dataDaily.dataBuy[i].numItemReciver.ToString();
        }

        imgSpr.sprite = dataDaily.dataBuy[0].spr;
        imgSpr.SetNativeSize();
    }

    public void SetTypeClaim(TYPE_CLAIM type, Material ma = null, Color color = default)
    {
        switch(type)
        {
            case TYPE_CLAIM.CLAIM:
                {
                    imgBG.sprite = spriteBg;
                    if(ma != null && txtDay != null)
                    {
                        txtDay.fontMaterial = ma;
                    }

                    if(color != default)
                    {
                        txtDay.color = color;
                    }

                    break;
                }
            case TYPE_CLAIM.CLAIMED:
                {
                    imgBG.sprite = currentSprite;
                    objTick.SetActive(true);
                    imgSpr.gameObject.SetActive(false);
                    for (int i = 0; i < txtMesh.Count; i++)
                    {
                        txtMesh[i].gameObject.SetActive(false);
                    }
                    break;
                }
            case TYPE_CLAIM.CLAIMING:
                {
                    if (ma != null && txtDay != null)
                    {
                        txtDay.fontMaterial = ma;
                    }
                    imgBG.sprite = currentSprite;
                    break;
                }
        }
    }

}
