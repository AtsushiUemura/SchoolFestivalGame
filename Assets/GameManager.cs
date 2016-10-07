using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    [SerializeField]
    private AudioSource BGMAudioSource;
    [SerializeField]
    private AudioSource SEAudioSource;
    private int highScore;
    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = HighScore;
        }
    }

    #region
    private void Awake()
    {
        if (this != I)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    #endregion

    public void SEPlay(AudioClip audioClip)
    {
        SEAudioSource.PlayOneShot(audioClip);
    }
    public void BGMPlay(AudioClip audioClip)
    {
        BGMAudioSource.clip = audioClip;
        BGMAudioSource.Play();
    }
}
