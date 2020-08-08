using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace barChart
{
    public class groupValues
    {
        public Dictionary<string, int> dataPoss;
        /*iterates trow each peace of data
         * crates a key by combining the two cat values
         * if there is a value whit the key already it add one
         * if not then i creates a new keyvalue pair
         * */
         public int highestValue =0;
        public groupValues(string[,] data)
        {
            dataPoss = new Dictionary<string, int>();
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
                    if (dataPoss[test] > highestValue)
                    {
                        highestValue = dataPoss[test];//updates if new higest value is gotten
                    }
                }
                else
                {
                    dataPoss.Add(test, 1);
                }
            }
        }

        public override string ToString()
        {
            string output = "";
            foreach(KeyValuePair<string,int> i in dataPoss)
            {
                output += i.Key +" : " +i.Value + "\n";
            }
            return output;
        }
    }
}
