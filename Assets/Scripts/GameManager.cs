using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TopAtar _TopAtar;
    public CizgiCiz _CizgiCiz;
    public AudioSource OyunBitis;
    public AudioSource KovayaSokma;
    public GameObject[] Panellerim; 
    public TextMeshProUGUI[] Scoretextleri;
    int GirenTopSayisi;
    private void Start()   
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            Scoretextleri[0].text = PlayerPrefs.GetInt("BestScore").ToString();
            Scoretextleri[1].text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
            Scoretextleri[0].text ="0";
            Scoretextleri[1].text = "0";
        }
    }
    public void DevamEt()
    {
        GirenTopSayisi++;
       _TopAtar.DevamEt();
       _CizgiCiz.DevamEt();
        KovayaSokma.Play();
    
     
    }
    public void OyunBitti()
    {
        OyunBitis.Play();
        Scoretextleri[2].text = PlayerPrefs.GetInt("BestScore").ToString();
        Scoretextleri[1].text = GirenTopSayisi.ToString();
        if (GirenTopSayisi>PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore" , GirenTopSayisi);
           
        }
        _TopAtar.TopAtarDurdur();
        Panellerim[2].SetActive(false);
        _CizgiCiz.Kilit = false;
        Panellerim[1].SetActive(true);

    }
    public void OyunBaslasin()
    {
        _CizgiCiz.Kilit = true;
        Panellerim[0].SetActive(false);
        Panellerim[2].SetActive(true);
        _TopAtar.OyunBaslasin();
    }
    public void TekrarOyna()
    {
        Panellerim[1].SetActive(false);
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
