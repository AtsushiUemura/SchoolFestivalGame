using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private float restTime;
    private int currentScore;
    [SerializeField]
    private float timeLimit;
    [SerializeField]
    private GameObject witch;

    [SerializeField]
    private Text restTimeText;
    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private float gravityPower;
    [SerializeField]
    private GameObject[] item;
    public GameObject ScoreTextObj;
    [SerializeField]
    private AnimationCurve animationCurve;
    [SerializeField]
    private float speedRate;
    [SerializeField]
    private GameObject TimeTextObj;

    #region
    void Awake()
    {
        if (this != I)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    IEnumerator Start()
    {
        Physics.gravity = new Vector3(0, gravityPower, 0);
        StartCoroutine(ItemCreate());
        StartCoroutine(CallWitch());
        yield return new WaitForSeconds(0.5f);
        Coroutine coroutine = StartCoroutine(ScaleUp(TimeTextObj));
        yield return coroutine;
        coroutine = StartCoroutine(ScaleDown(TimeTextObj));
        yield return coroutine;

    }
    void Update()
    {
        UpdateText();
    }
    #endregion

    private void Init()
    {
        restTime = timeLimit;
        currentScore = 0;

    }
    public IEnumerator AddScore(int score)
    {
        currentScore += score;
        Coroutine coroutine = StartCoroutine(ScaleUp(ScoreTextObj));
        yield return coroutine;
        coroutine = StartCoroutine(ScaleDown(ScoreTextObj));
        yield return coroutine;
    }
    public void AddTime(float time)
    {
        restTime += time;
    }
    private void UpdateText()
    {
        restTimeText.text = restTime.ToString();
        currentScoreText.text = currentScore.ToString();
    }
    private IEnumerator ItemCreate()
    {
        while (true)
        {
            Instantiate(item[Random.Range(0, item.Length)], new Vector3(10, Random.Range(0, 3), 6), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
    private IEnumerator CallWitch()
    {
        while (true)
        {
            witch.SetActive(true);
            yield return new WaitForSeconds(10);
        }
    }
    private IEnumerator ScaleUp(GameObject item)
    {
        bool flag = false;
        while (!flag)
        {
            if (Vector3.Distance(item.transform.localScale, new Vector3(1.2f, 1.2f, 1)) < 0.01f)
            {
                flag = true;
            }
            float curvePos = animationCurve.Evaluate(speedRate);
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, new Vector3(1.2f, 1.2f, 1), curvePos);
            yield return null;
        }
    }
    private IEnumerator ScaleDown(GameObject item)
    {
        bool flag = false;
        while (!flag)
        {
            if (Vector3.Distance(item.transform.localScale, Vector3.one) < 0.01f)
            {
                flag = true;
            }
            float curvePos = animationCurve.Evaluate(speedRate);
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, Vector3.one, curvePos);
            yield return null;
        }
    }
}
