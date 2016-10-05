using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    void Start()
    {
        Physics.gravity = new Vector3(0, gravityPower, 0);
        StartCoroutine(ItemCreate());
        StartCoroutine(CallWitch());
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
    public void AddScore(int score)
    {
        currentScore += score;
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
}
