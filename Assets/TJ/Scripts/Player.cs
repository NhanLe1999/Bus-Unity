using System.Collections;
using DG.Tweening;
using TJ.Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static readonly int Sit = Animator.StringToHash("Sit");
    public static readonly int Walk = Animator.StringToHash("Walk");
    public JunkColor color;
    public Renderer meshRenderer;
    public Animator anim;
    public GameObject animGo;

    private void Awake()
    {
        anim = animGo.GetComponent<Animator>();
    }

    public void ChangeColor(JunkColor colorEnum)
    {
        Material mats = VehicleController.instance.stickmanMaterialHolder.FindMaterialByName(colorEnum);
        meshRenderer.material = mats;
        //gameObject.name = gameObject.name.Replace("blue", "");
        gameObject.name += colorEnum.ToString();
        color = colorEnum;
    }

    public IEnumerator MoveToSlot1(Vector3 mid, Transform pickpoint, Vector3 point, float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.DOMove(mid, 0.3f).OnComplete(() =>
        {
            transform.rotation = pickpoint.rotation;
            transform.DOMove(point, 0.3f).OnComplete(() =>
            {
                anim.SetBool(Walk, false);
            });
        });
    }
    public IEnumerator MoveToSlot2(Vector3 point, float delay)
    {
        yield return new WaitForSeconds(delay);
        //DOVirtual.DelayedCall(0.2f, () =>
        //{          
        transform.DOMove(point, 0.3f).OnComplete(() =>
        {
            anim.SetBool(Walk, false);
        });
        //});
    }

    public IEnumerator MoveToTruck(Vehicle vehicle)
    {
        PlayerManager.instance.playersInScene.Remove(this);
        var seat = vehicle.GetFreeSeat();
        transform.parent = seat.transform;
        anim.SetBool(Walk, true);
        Vector3[] path = new Vector3[]
        {
                transform.position,
                transform.position - new Vector3(0,0,1),
                vehicle.transform.position,
                seat.transform.position
        };
        transform.DOPath(path, 0.8f, PathType.CatmullRom).OnComplete(() =>
        {
            Vibration.Vibrate(50);
            anim.SetBool(Walk, true);
            anim.SetBool(Sit, true);
            transform.localRotation = Quaternion.identity;
             transform.localPosition = new Vector3(0, -0.026f, 0.055f);
            transform.localScale = Vector3.one * 0.35f;
            vehicle.RunAnimScaleBus();
        });
        yield return new WaitForSeconds(0.1f);
        VehicleController.instance.UpdatePlayerCount();
        PlayerManager.instance.RepositionPlayers();
        SoundController.Instance.PlayOneShot(SoundController.Instance.sort);

    }

}