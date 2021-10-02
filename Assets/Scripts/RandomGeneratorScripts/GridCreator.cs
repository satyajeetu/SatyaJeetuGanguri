using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCreator : MonoBehaviour
{
    [Header("User Changebale Variables")]
    public int paddingUP = 50;

    public int paddingBelow = 50;

    public int number = 100;

    int width, height;

    static  int coloums, rows;


    [Header("Add In Inspector")]
    public VerticalLayoutGroup vr;

    public GridLayoutGroup gridLayout;

    public GameObject Button;

    public GameObject Panel;

    static GameObject[ , ] buttonVector;

    private void Start()
    {
        createGrid(number);
        
    }

    public static void ButtonClicked( int i , int j)
    {
       
        try
        {
            if (i > 0 && j > 0)

                buttonVector[i - 1, j - 1].GetComponent<CustomButton>().PhysicalClick();

           if (i > 0)

                buttonVector[i - 1, j].GetComponent<CustomButton>().PhysicalClick();

           if (i > 0 && j != rows - 1)

                buttonVector[i - 1, j + 1].GetComponent<CustomButton>().PhysicalClick();

           if (j > 0)

                buttonVector[i, j - 1].GetComponent<CustomButton>().PhysicalClick();

           if (j != rows - 1)

                buttonVector[i, j + 1].GetComponent<CustomButton>().PhysicalClick();

            buttonVector[i, j].GetComponent<CustomButton>().PhysicalClick();

           if (i != coloums - 1 && j > 0)

                buttonVector[i + 1, j - 1].GetComponent<CustomButton>().PhysicalClick();

           if (i != coloums - 1)

                buttonVector[i + 1, j].GetComponent<CustomButton>().PhysicalClick();

            buttonVector[i + 1, j + 1].GetComponent<CustomButton>().PhysicalClick();
        }
        catch
        {
            
           // Debug.Log("Reached Out of Bounds");
        }
    }


    public void createGrid(int number)
    {
        width = Screen.width;

        height = Screen.height - (paddingUP + paddingBelow);

        vr.padding.top = paddingUP;

        vr.padding.bottom = paddingBelow;

        List<int> factor = Factor(number);

        var temp = CheckBestFitForGrid(factor);

        //  rows = factor[factor.Count - 1];
        //  coloums = factor[factor.Count - 2];

        rows = temp[0];

        coloums = temp[1];

        gridLayout.cellSize = new Vector2(width / rows, height / coloums);

        buttonVector = new GameObject[coloums, rows];

        int k = 0;

        for (int i = 0; i < coloums; i++)
        {
            for (int j = 0; j < rows; j++)
            {

                GameObject go = Instantiate(Button);

                go.transform.SetParent(Panel.transform);

                go.GetComponent<CustomButton>().col = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

                go.GetComponent<CustomButton>().number = (k + 1).ToString();

                go.GetComponent<CustomButton>().i = i;

                go.GetComponent<CustomButton>().j = j;

                k++;

                buttonVector[i,j] = go;
            }

        }
        
    }


    public List<int> Factor(int number)
    {
        var factors = new List<int>();

        int max = (int)Mathf.Sqrt(number);  

        for (int factor = 1; factor <= max; ++factor)
        {
            if (number % factor == 0)
            {
                factors.Add(factor);

                if (factor != number / factor)
                {
                    factors.Add(number / factor);
                }
            }
        }
        return factors;
    }

    public int[] CheckBestFitForGrid(List<int> factors)
    {
        int[] answerArray = new int[2]; 

        int leastvalueDifference = int.MaxValue;

        for(int i =0; i < factors.Count; i++)
        {
            for(int j = 0; j < factors.Count; j++)
            {
                if(factors[i] * factors[j] == number)
                {
                   if( Mathf.Abs(i - j) <= leastvalueDifference)
                    {
                        leastvalueDifference = Mathf.Abs(factors[i] - factors[j]);

                        if (factors[i] >= factors[j])
                        {
                            answerArray[0] = factors[i]; answerArray[1] = factors[j];
                        }
                        else
                        {
                            answerArray[0] = factors[j]; answerArray[1] = factors[i];
                        }
                     //   Debug.Log(answerArray[0]);
                     //   Debug.Log(answerArray[1]);

                    }
                }
            }
        }

     //   Debug.LogWarning(answerArray[0]);
     //   Debug.LogWarning(answerArray[1]);

        return answerArray;

    }


}
