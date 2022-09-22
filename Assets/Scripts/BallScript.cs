using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            other.gameObject.GetComponent<BoxScript>().BoxNumberAzalt();
        }
        if (other.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject.transform.parent.gameObject);
            GameManager.instance.UpgradeMoney();
        }
    }
}
