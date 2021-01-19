using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoGridSize", menuName = "SoGrid")]
public class SOFile : ScriptableObject
{
    public TextAsset puzzleData;
    int row;
    int col;
    public int[,] ConvertSize()
    {
        string fTxt;
        int[,] temp=new int[1, 2] { { 10, 10 } };
        if(!string.IsNullOrEmpty(puzzleData.text))
        {
            fTxt = puzzleData.text;
            //    fTxt = fTxt.Replace('\n', ',');
            string[] txtArray = fTxt.Split(',');

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int.TryParse(txtArray[j], out temp[i, j]);
                }

            }
            return temp;
        }
        return temp;


    }
}
