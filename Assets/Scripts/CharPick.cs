using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPick : MonoBehaviour
{
    private GameObject CharPickWindow;
    public GameObject MainChar1;
    public GameObject MainChar2;
    public GameObject MainChar3;
    public GameObject MainChar4;

    private int CharNum;

    // Start is called before the first frame update
    void Start()
    {

        CharPickWindow = GameObject.Find("CharacterPicking");
        CharPickWindow.SetActive(false);
        if(Data.CharNum<=0)
        {
            CharPickWindow.SetActive(true);
            Time.timeScale = 0;
        }    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void ChooseChar1()
    {
        PlayerPrefs.SetInt("CharNum", 1);
        Data.CharNum = PlayerPrefs.GetInt("CharNum", 0);
        MainChar2.SetActive(false);
        MainChar3.SetActive(false);
        MainChar4.SetActive(false);
        CharPickWindow.SetActive(false);
        Time.timeScale = 1;
    }
    public void ChooseChar2()
    {
        PlayerPrefs.SetInt("CharNum", 2);
        Data.CharNum = PlayerPrefs.GetInt("CharNum", 0);
        MainChar1.SetActive(false);
        MainChar3.SetActive(false);
        MainChar4.SetActive(false);
        CharPickWindow.SetActive(false);
        Time.timeScale = 1;
    }
    public void ChooseChar3()
    {
        PlayerPrefs.SetInt("CharNum", 3);
        Data.CharNum = PlayerPrefs.GetInt("CharNum", 0);
        MainChar1.SetActive(false);
        MainChar2.SetActive(false);
        MainChar4.SetActive(false);
        CharPickWindow.SetActive(false);
        Time.timeScale = 1;
    }
    public void ChooseChar4()
    {
        PlayerPrefs.SetInt("CharNum", 4);
        Data.CharNum = PlayerPrefs.GetInt("CharNum", 0);
        MainChar1.SetActive(false);
        MainChar2.SetActive(false);
        MainChar3.SetActive(false);
        CharPickWindow.SetActive(false);
        Time.timeScale = 1;
    }
}
