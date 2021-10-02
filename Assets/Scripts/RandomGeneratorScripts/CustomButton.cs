using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public Color col;
    public string number;

    public int i, j;

    public void virtualClick()
    {
        GridCreator.ButtonClicked(i, j);
    }
    public void PhysicalClick()
    {
       
        GetComponent<Image>().color = col;
        GetComponentInChildren < Text >().text = number;
    }

}
