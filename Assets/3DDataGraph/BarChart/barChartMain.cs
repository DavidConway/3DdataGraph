using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace barChart
{
    public class barChartMain
    {
        string[,] data;
        public barChartMain(object[,] dataIn, string[] cats)
        {
            data = dataConvert(dataIn);
            highestBarValue test = new highestBarValue(data, cats);
        }

        private string[,] dataConvert(object[,] data)
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

    }
}
