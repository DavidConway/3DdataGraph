using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataParsing;
using barChart;

namespace DataGraph
{
    public class dataGraph : MonoBehaviour
    {
        private dataPars parser;
        private barChartMain barChart;
        public enum dataScorce { googleSheet }; //possible dataScorses
        public enum graphType { barchart };
        private graphType mode;
        private int[] startingPoint = new int[2]; // two ints to represent the data point 
        private int page;
        

        void Start()
        {
            mode = graphType.barchart;
            startingPoint[0] = 0;
            startingPoint[1] = 0;
            page = 2;

            //calls parser
            parser = new dataPars(dataScorce.googleSheet, "https://docs.google.com/spreadsheets/d/1DF15HgrXx9X-ntNgUI0RJhoUhc548RB855a-UvSj_kw/edit#gid=0",page-1,startingPoint);

            //sets mode
            switch (mode)
            {
                case graphType.barchart:
                    {
                        barChart = new barChartMain(parser.getParsedData(), parser.getCatagorys()); ;
                        break;
                    }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
