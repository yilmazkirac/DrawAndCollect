using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CizgiCiz : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Cizgi;
    public LineRenderer _LineRenderer;
    public EdgeCollider2D _EdgeCollider;
    public List<Vector2> ParmakPosList;
    public List<GameObject> Cizgiler;
   public bool Kilit;
   public int CizmeHakki;
    int CizmeSayisi=0;
    int Hesap;
    public TextMeshProUGUI CizgiText;


    private void Start()
    {
        Hesap = CizmeHakki - CizmeSayisi;
        CizgiText.text = Hesap.ToString();
    }
    void Update()
    {
        if (Kilit)
        {
            if (CizmeHakki >= CizmeSayisi)
            {       
                if (Input.GetMouseButtonDown(0))
                {
                    CizgiOlustur();
                    CizmeSayisi++;
                    Hesap = CizmeHakki - CizmeSayisi;
                    if (Hesap >= 0)
                    CizgiText.text = Hesap.ToString();
                    else 
                        CizgiText.text = "0".ToString();

                }
                if (Input.GetMouseButton(0))
                {
                    Vector2 ParmakPs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (Vector2.Distance(ParmakPs, ParmakPosList[^1]) > .1f)
                    {
                        CisgiGuncelle(ParmakPs);
                    }
                 
                }
              
            }
        }

        
      
    }

    void CizgiOlustur()
    {
        Cizgi=Instantiate(LinePrefab,Vector2.zero,Quaternion.identity);
        Cizgiler.Add(Cizgi);
        _LineRenderer =Cizgi.GetComponent<LineRenderer>();
        _EdgeCollider=Cizgi.GetComponent<EdgeCollider2D>();
        ParmakPosList.Clear();
        ParmakPosList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        ParmakPosList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        _LineRenderer.SetPosition(0, ParmakPosList[0]);
        _LineRenderer.SetPosition(1, ParmakPosList[1]);
        _EdgeCollider.points = ParmakPosList.ToArray();
      
    }

    void CisgiGuncelle(Vector2 GelenParmakPos)
    {
        ParmakPosList.Add(GelenParmakPos);
        _LineRenderer.positionCount++;
        _LineRenderer.SetPosition(_LineRenderer.positionCount - 1,GelenParmakPos);
        _EdgeCollider.points = ParmakPosList.ToArray();
    }

    public void DevamEt()
    {
        CizmeSayisi = 0;
        Hesap = CizmeHakki - CizmeSayisi;
        CizgiText.text = Hesap.ToString();
        foreach (var e in Cizgiler)
        {
            Destroy(e.gameObject);
        }
        Cizgiler.Clear();   
    }
}
