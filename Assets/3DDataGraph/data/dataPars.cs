using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataGraph;

namespace DataParsing
{
    public class dataPars
    {

        private googleSheets sheet; // google sheet ref
        private object[,] data; //contains the returned data
        string[] cat;
        object[,] parsedData;

        public dataPars(dataGraph.dataScorce scorce, string url, int page, int[] startingPoint) // scorce of data, the sheets url, the page number
        {
            //gets the data and puts it in a common var
            if (scorce == dataGraph.dataScorce.googleSheet)
            {
                sheet = new googleSheets(url, page);
                data = sheet.getOutData();
            }
            if(data == null)
            {
                Debug.Log("no data in page");
                return;
            }

            // finds the number of cats
            int numOfCats = 0;
            for(int i = 0; i < data.GetLength(1); i++)
            {
                if((startingPoint[1] + i) < data.GetLength(1) && data[startingPoint[0],(startingPoint[1]+i)] != (object)"")
                {
                    numOfCats++;
                }
                else
                {
                    break;
                }
            }

            //populates the list of cats
            cat = new string[numOfCats];
            for(int i = 0;  i < cat.Length; i++)
            {
                cat[i] = (string)data[startingPoint[0], startingPoint[1] + i];
            }

            //find the number of rows
            int numOfrows = 0;
            for (int i = 1; i < data.GetLength(0); i++)
            {
                if ((startingPoint[0] + i) < data.GetLength(0) && data[startingPoint[0]+i, startingPoint[1]] != (object)"")
                {
                    numOfrows++;
                }
                else
                {
                    break; ;
                }
            }

            //populates the parsData
            parsedData = new object[numOfrows,numOfCats];
            for (int i = 0; i < numOfrows; i++)
            {
                for (int j = 0; j < numOfCats; j++)
                {
                    parsedData[i, j] = data[(startingPoint[0] + 1) + i, startingPoint[1] + j];
                }
            }

            Debug.Log(ToString());
        }

        public override string ToString()
        {
            string result = "";

            foreach(string i in cat)
            {
                result += i;
            }
            result += "\n";

            for(int i = 0; i < parsedData.GetLength(0); i++)
            {
                result += i+1 + ":";
                for(int j = 0; j < parsedData.GetLength(1); j++)
                {
                    result +="," + parsedData[i, j]; 
                }
                result += "\n";
            }
            return result;
        }

        public string[] getCatagorys()
        {
            return cat;
        }

        public object[,] getParsedData()
        {
            return parsedData;
        }
    }
}

