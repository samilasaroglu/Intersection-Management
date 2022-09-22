using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxScript : MonoBehaviour
{
    [SerializeField] private int boxNumber;
    [SerializeField] private TextMeshPro tmpText;

    private void Awake()
    {
        setTmpText();
    }

    public void setTmpText()
    {
        if (boxNumber > 0)
        {
            tmpText.text = "" + boxNumber;
        }
        else
        {
            //kutu içindeki sayının patlamasi
        }
    }

    public void BoxNumberAzalt()
    {
        boxNumber--;
        setTmpText();
    }
}
