using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Resultmanager : MonoBehaviour
{
    int score =0;
    int[] record = { 0, 0, 0 };

    public Text scoretxt;
    public Text firsttxt;
    public Text secondtxt;
    public Text thirdtxt;

    public GameObject Option;
    bool isOption;

    public Slider slider;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        CheckScore();
        if (PlayerPrefs.HasKey("volume"))
            slider.value = PlayerPrefs.GetFloat("volume");
        else
            slider.value = 0.5f;
    }
    void Start()
    {
        isOption = false;
        ChangeRecord();
        ViewRecord();
        SaveRecord();
    }
    private void Update()
    {
        Soundmanager.SoundVolume = slider.value;
    }
    void CheckScore()
    {
        score = PlayerPrefs.HasKey("score") ? score = PlayerPrefs.GetInt("score") : score = -3;       
        record[0] = PlayerPrefs.HasKey("first")? record[0] = PlayerPrefs.GetInt("first"): record[0] = 0;      
        record[1] = PlayerPrefs.HasKey("second")? record[1] = PlayerPrefs.GetInt("second"): record[1] = -1;
        record[2] = PlayerPrefs.HasKey("third") ? record[2] = PlayerPrefs.GetInt("third") : record[2] = -2;
    }
    void ChangeRecord()
    {
        for(int i = 2; i>=0;i--)
        {
            if(score>record[i])
            {
                int temp;
                temp = record[i];
                record[i] = score;
                if(i<record.Length-1)               
                    record[i + 1] = temp;              
            }
        }
    }
    void ViewRecord()
    {
        scoretxt.text = (score == -3) ? "----":score.ToString();
        firsttxt.text = (record[0] <= 0) ? "----" : record[0].ToString();
        secondtxt.text = (record[1] <= 0) ? "----" : record[1].ToString();
        thirdtxt.text = (record[2] <= 0) ? "----" : record[2].ToString();
    }
    void SaveRecord()
    {
        score = -3;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("first", record[0]);
        PlayerPrefs.SetInt("second", record[1]);
        PlayerPrefs.SetInt("third", record[2]);
    }
    IEnumerator PrevScene()
    {
        Soundmanager.instance.Playsecond(0);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(0);
    }
    public void PressHome()
    {
        StartCoroutine(PrevScene());
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
