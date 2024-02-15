using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public Token LastToken;
    public GameObject TokenPref;
    public Transform TokenPos;
    public List<Token> TokenPool;

    public GameObject particlePref;
    public Transform particlePos;
    public List<ParticleSystem> particlePool;

    public int poolSize;
    public int poolCursor;

    public int MaxLevel = 2;
    int SpawnLevel;
    public int score;
    public Text ScoreTxt;
    public bool isGameOver;

    bool isCycle;
    public GameObject CycleImg;

    bool isOption;
    public GameObject Option;

    public Slider slider;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        TokenPool = new List<Token>();
        particlePool = new List<ParticleSystem>();
        for(int i=0; i<poolSize;i++)
        {
            MakeToken();
        }

        if (PlayerPrefs.HasKey("volume"))
            slider.value = PlayerPrefs.GetFloat("volume");
        else
            slider.value = 0.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        isCycle = false;
        isOption = false;
        score = 0;
        NextToken();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text = score.ToString();
        Soundmanager.SoundVolume = slider.value;
    }
    Token MakeToken()
    {
        GameObject particleobj = Instantiate(particlePref, particlePos);
        particleobj.name = "Particle " + particlePool.Count;
        ParticleSystem ParticleObjs = particleobj.GetComponent<ParticleSystem>();
        particlePool.Add(ParticleObjs);

        GameObject obj = Instantiate(TokenPref, TokenPos);
        obj.name = "Token " + TokenPool.Count;
        Token TokenObjs = obj.GetComponent<Token>();
        TokenObjs.manager = this;
        TokenObjs.particle = ParticleObjs;
        TokenPool.Add(TokenObjs);

        return TokenObjs;
    }
    Token GetToken()
    {
        for(int i =0; i<TokenPool.Count; i++)
        {
            poolCursor = (poolCursor + 1) % TokenPool.Count;
            if(!TokenPool[poolCursor].gameObject.activeSelf)
            {
                return TokenPool[poolCursor];
            }
        }
        return MakeToken();
    }
    void NextToken()
    {
        if (isGameOver)
            return;
        LastToken = GetToken();

        SpawnLevel = Mathf.Clamp(MaxLevel, 1, 6);
        LastToken.level = Random.Range(1, SpawnLevel);
        LastToken.gameObject.SetActive(true);
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        while (LastToken != null)
            yield return null;

        yield return new WaitForSeconds(2.5f);
        NextToken();
    }
    public void PointerDown()
    {
        if (LastToken == null)
            return;
        LastToken.Drag();
    }
    public void PointerUp()
    {
        if (LastToken == null)
            return;
        LastToken.Drop();
        LastToken = null;
    }
    public void GameOver()
    {
        if (isGameOver)
            return;
        isGameOver = true;
        Soundmanager.instance.AudioStop();
        StartCoroutine(GameOverRoutine());
    }
    public void PressCycle()
    {
        Soundmanager.instance.Playsecond(0);
        isCycle = !isCycle;
        if (isCycle)
            CycleImg.SetActive(true);
        else if (!isCycle)
            CycleImg.SetActive(false);      
    }
    public void PressOption()
    {
        Soundmanager.instance.Playsecond(0);
        isOption = !isOption;
        if (isOption)
            Option.SetActive(true);
        else if (!isOption)
        {
            Soundmanager.instance.SaveVolume();
            Option.SetActive(false);
        }

    }
    IEnumerator GameOverRoutine()
    {
        Token[] token = GameObject.FindObjectsOfType<Token>();

        for (int i = 0; i < token.Length; i++)
        {
            token[i].rigid.simulated = false;
        }

        for (int i = 0; i < token.Length; i++)
        {
            token[i].Hide(Vector3.up * 100);
            Soundmanager.instance.Playfirst(1);
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(NextScene());
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(0.5f);
        Soundmanager.instance.Playsecond(1);
        yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene(2);
    }
    IEnumerator PrevScene()
    {
        Soundmanager.instance.Playsecond(0);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(0);
    }
    public void PressStop()
    {
        StartCoroutine(PrevScene());
    }
    public void PressExit()
    {
        Application.Quit();
    }
}
