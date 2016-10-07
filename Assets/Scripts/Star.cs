using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Star : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve animationCurve;
    private Vector3 originalScale;
    [SerializeField]
    private Vector3 beScale;

    #region

    void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(ChangeScale());
    }
    #endregion

    private IEnumerator ChangeScale()
    {
        Coroutine coroutine = null;
        while (true)
        {
            coroutine = StartCoroutine(ScaleChange(this.gameObject, beScale, 0.3f));
            yield return coroutine;
            coroutine = StartCoroutine(ScaleChange(this.gameObject, originalScale, 0.4f));
            yield return coroutine;
        }
    }
    private IEnumerator ScaleChange(GameObject item, Vector3 destination, float speed)
    {
        bool flag = false;
        while (!flag)
        {
            if (Vector3.Distance(item.transform.localScale, destination) < 0.01f)
            {
                flag = true;
            }
            float curvePos = animationCurve.Evaluate(speed);
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, destination, curvePos);
            yield return null;
        }
    }
}
