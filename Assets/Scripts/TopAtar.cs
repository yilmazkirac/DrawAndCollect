using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class TopAtar : MonoBehaviour
{
    public GameObject[] Toplar;
    public GameObject TopAtarMerkez;
    public GameObject Kova;
    public GameObject[] KovaNoktalari;
    int AktifTopIndex;
    bool Kilit;
    Vector2 Point;
    public AudioSource TopAtma;
    public GameObject TopAtisEfekt;
    public GameObject TopGirmeEfekt;

    private void Start()
    {

    }
    public void OyunBaslasin()
    {
        StartCoroutine(TopAtisSistemi());
    }
    IEnumerator TopAtisSistemi()
    {
        while (true)
        {
            if (!Kilit)
            {


                yield return new WaitForSeconds(.5f);

                Toplar[AktifTopIndex].transform.position = TopAtarMerkez.transform.position;
                Toplar[AktifTopIndex].SetActive(true);
                Toplar[AktifTopIndex].GetComponent<Rigidbody2D>().AddForce(PozisyonVer(AciVer(70f, 110f)) * 800);

                if (AktifTopIndex != Toplar.Length - 1)
                    AktifTopIndex++;
                else
                    AktifTopIndex = 0;
                TopAtisEfekt.SetActive(true);
                TopAtma.Play();
                yield return new WaitForSeconds(1f);

                int KovaPoint = Random.Range(0, KovaNoktalari.Length - 1);
                Kova.transform.position = KovaNoktalari[KovaPoint].transform.position;
                Kova.SetActive(true);
                Kilit = true;
                Invoke("TopuKontrolEt", 3f);
            }
            else
            {
                yield return null;
            }
        }
    }
    Vector3 PozisyonVer(float GelenAci)
    {
        return Quaternion.AngleAxis(GelenAci, Vector3.forward) * Vector3.right;
    }
    float AciVer(float Deger1, float Deger2)
    {
        return Random.Range(Deger1, Deger2);
    }
    public void DevamEt()
    {       
            TopGirmeEfekt.transform.position = Kova.transform.position;
            TopGirmeEfekt.SetActive(true);
            Kilit = false;
            Kova.SetActive(false);
            CancelInvoke();           
    }
    public void TopAtarDurdur()
    {
        StopAllCoroutines();
    }
    public void TopuKontrolEt()
    {
        if (Kilit)
            GetComponent<GameManager>().OyunBitti();
    }
}
