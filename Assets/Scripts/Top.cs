using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public GameManager _GameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OyunBitti"))
        {
            gameObject.SetActive(false);
                _GameManager.OyunBitti();

        }
       else if (collision.gameObject.CompareTag("TopGirdi"))
        {
            gameObject.SetActive(false);
            _GameManager.DevamEt();
        }
  
    }
}
