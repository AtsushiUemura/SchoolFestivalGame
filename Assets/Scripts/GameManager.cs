using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private float RestTime;
    public float restTime
    {
        get
        {
            return RestTime;
        }
        set
        {
            restTime = RestTime;
        }
    }
    private int currentScore;
    public int CurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = CurrentScore;
        }
    }
    [SerializeField]
    private float timeLimit;

    [SerializeField]
    private Text restTimeText;
    [SerializeField]
    private Text currentScoreText;

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
        Physics.gravity = new Vector3(0, -40, 0);
    }
    void Update()
    {
        UpdateText();
    }
    #endregion

    private void Init()
    {
        RestTime = timeLimit;
        CurrentScore = 0;

    }
    public void AddScore(int score)
    {
        CurrentScore += score;
    }
    public void AddTime(float time)
    {
        RestTime += time;
    }
    private void UpdateText()
    {
        restTimeText.text = RestTime.ToString();
        currentScoreText.text = CurrentScore.ToString();
    } 
}
