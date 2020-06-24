using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace barChart
{
    public class barChartMain
    {
        string[,] data;
        int arrayWidth;
        int arrayLenght;
        List<string> widthElemets = new List<string>();
        List<string> lenghtElemets = new List<string>();
        GameObject graphObj;
        public barChartMain(object[,] dataIn, string[] cats, GameObject graphObjIn)
        {
            graphObj = graphObjIn;
            data = dataConvert(dataIn);
            groupValues values = new groupValues(data, cats);
            int arrayWidth = getWidth();// generate width info and lenght
            int arrayLenght = getLenght();//get lenght info and lenght.... you know what i mean
            test();
        }

        private string[,] dataConvert(object[,] data)//changes all data to strings
        {
            string[,] output = new string[data.GetLength(0),data.GetLength(1)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for(int j = 0; j < data.GetLength(1); j++)
                {
                    output[i, j] = (string)data[i, j];
                }
            }

            return output;
        }

        private int getWidth() // gose trow all width elements if it hasent been counted yet its added to the list and the number of elements increses i.e (red,blue,green)
        {
            int outNum = 0;
            for(int i = 0; i < data.GetLength(0); i++)
            {
                if (!widthElemets.Contains(data[i, 0]))
                {
                    widthElemets.Add(data[i, 0]);
                    outNum++;
                }
            }
            return outNum;
        }

        private int getLenght() // gose trow all lenght elements if it hasent been counted yet its added to the list and the number of elements increses i.e (car,van,truck)
        {
            int outNum = 0;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (!lenghtElemets.Contains(data[i, 1]))
                {
                    lenghtElemets.Add(data[i, 1]);
                    outNum++;
                }
            }
            return outNum;
        }

        void test()
        {
            string width = "";
            foreach(string i in widthElemets)
            {
                width += i + " ";
            }
            string lenght = "\n";
            foreach(string i in lenghtElemets)
            {
                lenght += i + " ";
            }
            Debug.Log(width);
            Debug.Log(lenght);
        }
    }
}
