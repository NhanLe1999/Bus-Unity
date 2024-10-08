using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimStar : MonoBehaviour
{

    [SerializeField] List<Sprite> sprites;
    [SerializeField] Image image;
    [SerializeField] float delayTime = 0.1f;

    [SerializeField] bool isDelay = true;


    int index = 0;

    void Start()
    {
        this.StartCoroutine(StarAnim());
       /* float scale = UnityEngine.Random.Range(1.0f, 2.5f);
        gameObject.GetComponent<RectTransform>().localScale = Vector3.one * scale;*/
    }

    IEnumerator StarAnim()
    {
        yield return new WaitForSeconds(isDelay ? UnityEngine.Random.Range(0.0f, 1.5f) : 0) ;
        this.StartCoroutine(PlayAnim());
    }

    IEnumerator PlayAnim()
    {
        yield return new WaitForSeconds(delayTime);
        yield return new WaitForEndOfFrame();

        if (index >= sprites.Count)
        {
            index = 0;
        }
        image.sprite = sprites[index];
        image.SetNativeSize();
        index++;
        this.StartCoroutine(PlayAnim());
    }
   
}
