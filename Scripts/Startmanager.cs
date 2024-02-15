using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startmanager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad()
    {
        if (SceneManager.GetActiveScene().buildIndex.CompareTo(0) != 0)
            SceneManager.LoadScene(0);
    }


    public StartToken LastToken;
    public GameObject TokenPref;
    public Transform TokenPos;
    public List<StartToken> TokenPool;

    public GameObject particlePref;
    public Transform particlePos;
    public List<ParticleSystem> particlePool;

    public int poolSize;
    public int poolCursor;

    bool ismake;

    public GameObject Option;
    bool isOption;

    public Slider slider;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        ismake = true;
        isOption = false;

        TokenPool = new List<StartToken>();
        particlePool = new List<ParticleSystem>();
        for (int i = 0; i < poolSize; i++)
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
        if (Soundmanager.instance.GetComponent<AudioSource>().isPlaying)
            return;
        else
            Soundmanager.instance.AudioPlay();

        NextToken();
    }
    private void Update()
    {
        Soundmanager.SoundVolume = slider.value;
    }

    // Update is called once per frame
    StartToken MakeToken()
    {
        GameObject particleobj = Instantiate(particlePref, particlePos);
        particleobj.name = "Particle " + particlePool.Count;
        ParticleSystem ParticleObjs = particleobj.GetComponent<ParticleSystem>();
        particlePool.Add(ParticleObjs);

        GameObject obj = Instantiate(TokenPref, TokenPos);
        Vector3 Pos = new Vector3(Random.Range(-2.38f, 2.38f), 7, 0);
        obj.transform.position = Pos;
        float leftBorder = -2.38f + transform.localScale.x / 2f;
        float rightBorder = 2.38f - transform.localScale.x / 2f;

        if (Pos.x < leftBorder)
            Pos.x = leftBorder;
        else if (Pos.x > rightBorder)
            Pos.x = rightBorder;

        obj.name = "Token " + TokenPool.Count;
        StartToken TokenObjs = obj.GetComponent<StartToken>();
        TokenObjs.manager = this;
        TokenObjs.particle = ParticleObjs;
        TokenPool.Add(TokenObjs);

        return TokenObjs;
    }
    StartToken GetToken()
    {
        for (int i = 0; i < TokenPool.Count; i++)
        {
            poolCursor = (poolCursor + 1) % TokenPool.Count;
            if (!TokenPool[poolCursor].gameObject.activeSelf)
            {
                return TokenPool[poolCursor];
            }
        }
        return MakeToken();
    }
    void NextToken()
    {
        if (!ismake)
            return;

        LastToken = GetToken();

        LastToken.level = Random.Range(1, 8);
        LastToken.gameObject.SetActive(true);
        LastToken.GetComponent<StartToken>().Drop();
        LastToken = null;
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        while (LastToken != null)
            yield return null;

        yield return new WaitForSeconds(5f);
        NextToken();
    }
    IEnumerator PressPlay()
    {
        Soundmanager.instance.Playsecond(0);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(1);
    }
    IEnumerator PressRecord()
    {
        Soundmanager.instance.Playsecond(0);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(2);
    }
    public void Play()
    {
        StartCoroutine(PressPlay());
    }
    public void Record()
    {
        StartCoroutine(PressRecord());
    }
    public void Stop()
    {
        ismake = false;
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
    public void PressExit()
    {
        Application.Quit();
    }
}

