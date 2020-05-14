using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace barChart
{
    public class highestBarValue
    {
        public highestBarValue(string[,] data, string[] cats)
        {
            Dictionary<string, int> dataPoss = new Dictionary<string, int>();
            for(int i = 0; i < data.GetLength(0); i++)
            {
                string test = "";
                for (int j =0; j < data.GetLength(1); j++)
                {
                    test += data[i, j];
                }

                if (dataPoss.TryGetValue(test, out int k) == true)
                {
                    dataPoss[test] = dataPoss[test]+1;
                }
                else
                {
                    dataPoss.Add(test, 1);
                }
            }
            int test2 = 0;
        }
    }
}
