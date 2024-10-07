using System;
using DG.Tweening;
using UnityEngine;

public abstract class Dialog<T> : Dialog where T : Dialog<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        Instance = (T)this;
    }

    protected virtual void OnDestroy()
    {
        Instance = null;
    }

    protected static void Open()
    {
        if (Instance == null)
            MenuManager.Instance.CreateDialog<T>();
        else
            Instance.gameObject.SetActive(true);

        MenuManager.Instance.OpenDialog(Instance);
        Instance.Show();
    }

    protected static void Close()
    {
        if (Instance == null)
        {
#if UNITY_EDITOR
            Debug.LogErrorFormat("Trying to close dialog {0} but Instance is null", typeof(T));
#endif
            return;
        }

        Instance.Hide(() =>
        {
            MenuManager.Instance.CloseDialog(Instance);
        });
    }

    public override void OnBackPressed()
    {
        if (!Cancelable)
            return;
        Close();
    }

    public override void OnDialogBecameVisible()
    {
    }
}

public abstract class Dialog : MonoBehaviour
{
    [Tooltip("Destroy the Game Object when dialog is closed (reduces memory usage)")]
    public bool DestroyWhenClosed = true;

    [Tooltip("Cancelable dialog when press back key")]
    public bool Cancelable = true;

    public Transform ObjAnim = null;

    public abstract void OnDialogBecameVisible();
    public abstract void OnBackPressed();
}

public static class DialogExtension
{
    private static readonly float duration = 0.2f;

    public static void Show(this Dialog dialog, Action finish = null)
    {
        GetComponent(dialog, out var t, out var cg);

        var seq = DOTween.Sequence();
        cg.alpha = 1;

        if (dialog.ObjAnim != null)
        {
            dialog.ObjAnim.localScale = Vector3.zero;
            seq.Append(dialog.ObjAnim.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack))
                        .Append(dialog.ObjAnim.transform.DOScale(0.95f, 0.1f).SetEase(Ease.InOutSine))
                        .Append(dialog.ObjAnim.transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
                        .AppendCallback(() =>
                        {
                            finish?.Invoke();
                        })
                        .SetUpdate(true); ;
            seq.Play();
        }
        else
        {
            finish?.Invoke();
        }


    }

    public static void Hide(this Dialog dialog, Action finish = null)
    {
        GetComponent(dialog, out var t, out var cg);

        if (dialog.ObjAnim != null)
        {
            Sequence closeSequence = DOTween.Sequence();

            closeSequence.Append(dialog.ObjAnim.DOScale(1.05f, 0.1f).SetEase(Ease.InOutSine))
                         //   .Append(dialog.ObjAnim.DOScale(0.95f, 0.15f).SetEase(Ease.InOutSine))
                         .Append(dialog.ObjAnim.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack))
                         .OnComplete(() =>
                         {
                             finish?.Invoke();
                         }).SetUpdate(true);

            closeSequence.Play();
        }
        else
        {
            finish?.Invoke();
        }
    }

    private static void GetComponent(Dialog d, out Transform t, out CanvasGroup cg)
    {
        var go = d.gameObject;
        t = go.transform;
        cg = go.GetComponent<CanvasGroup>();
        if (!cg) cg = go.AddComponent<CanvasGroup>();
    }
}