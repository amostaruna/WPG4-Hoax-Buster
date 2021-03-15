using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Poster : MonoBehaviour
{
    //SerializedField Private GameObjects
    [Header("GameObjects")]
    [SerializeField] private GameObject posterFull;
    [SerializeField] private GameObject coin;

    //SerializedField Private Components
    [Header("Components")]
    [SerializeField]private Animator anim;
    [SerializeField] private Text textButton;

    //mengecek apakah koin sudah diambil. 0 untuk blom, 1 untuk sudah
    int coinAlreadyPicked;

    //CekButton digunakan untuk mengecek apakah Text("Open Poster") sudah tampil apa belum
    bool cekButton;
    //CekPoster digunakan untuk mengecek apakah Poster sudah tampil apa belum
    bool cekPoster;

    private void Awake()
    {
        if(posterFull == null)
        {
            Debug.LogError("Poster Pada GameObject Dengan Nama" + gameObject.name + " Belum di tambahkan");
        }
    }

    void Start()
    {
        cekPoster = false;
        cekButton = false;
        HiddenText();
        HiddenPoster();
       
        coin.SetActive(false);
        //PlayerPrefs.SetInt(gameObject.name, 0); //reset coin data, hapus "//", run game kemudian exit// tambahkan kem
        //Data.coin = 0;
        coinAlreadyPicked =  PlayerPrefs.GetInt(gameObject.name, 0);
    }

    private void Update()
    {
        Debug.Log(gameObject.name +" key "+coinAlreadyPicked);
        if (Input.GetKey(KeyCode.E) && cekButton)
        {
            PlayerPrefs.SetInt("GetCoin", 1);
            ShowPoster();
        }

        if(Input.GetKey(KeyCode.P) && cekPoster)
        {
            StartCoroutine(AnimHiddenPoster());
        }

        if (Input.GetKey(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Jika player menyentuh poster
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Muncul Pop Up Button 
            ShowText();
            cekButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Jika player keluar dari trigger poster
        if (collision.gameObject.tag.Equals("Player"))
        {
            cekButton = false;
            //Hapus Pop Up Button
            HiddenText();
        }
    }
     
    //Fungsi untuk menampilkan poster
    private void ShowPoster()
    {
        Time.timeScale = 0;
        cekPoster = true;
        posterFull.SetActive(true);
        anim.SetBool("FadeIn", true);
    }

    //fungsi untuk menutup poster
    private void HiddenPoster()
    {
        cekPoster = false;
        Time.timeScale = 1;
        anim.SetBool("FadeIn", false);
    }

    //Fungsi untuk mengaktifkan component Text("Open Poster")
    private void ShowText()
    {
        textButton.enabled = true;
    }


    //Fungsi untuk menonaktifkan component Text("Open Poster")
    private void HiddenText()
    {
        textButton.enabled = false;
    }

    //Fungsi untuk menutup poster dg animasi
    IEnumerator AnimHiddenPoster()
    {
        anim.SetBool("FadeIn", false);
        HiddenPoster();
        yield return new WaitForSeconds(1);
        posterFull.SetActive(false);
        if(coinAlreadyPicked==0)
        {
            ShowCoin();
        }
    }

    public void ClosePoster()
    {
        StartCoroutine(AnimHiddenPoster());
    }

    public void ShowCoin()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);
        if (coin != null)
            coin.SetActive(true);   
    }
}
