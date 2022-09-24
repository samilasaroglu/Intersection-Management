using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallScript : MonoBehaviour
{
    public static  BallScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            other.transform.DOScale(new Vector3(.75f, .75f, .75f), .1f);
        }
        if (other.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject.transform.parent.gameObject);
            GameManager.instance.UpgradeMoney();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            other.gameObject.GetComponent<BoxScript>().BoxNumberAzalt();
            other.transform.DOScale(new Vector3(1, 1, 1), .1f);
        }
    }
}
