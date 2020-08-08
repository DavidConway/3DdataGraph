using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataParsing;
using barChart;

namespace DataGraph
{
    public class dataGraph : MonoBehaviour
    {
        //takes in google sheets crads
        [SerializeField]
        private string googleID;
        [SerializeField]
        private string googleSecret;

        private dataPars parser;
        private barChartMain barChart;
        public enum dataScorce { googleSheet }; //possible dataScorses
        public enum graphType { barchart };
        private graphType mode;
        private int[] startingPoint = new int[2]; // two ints to represent the data point 
        private int page;
        

        void Start()
        {
            // import/user settings
            mode = graphType.barchart;
            startingPoint[0] = 0;
            startingPoint[1] = 0;
            page = 2;

            //calls parser
            googleSheets primer = new googleSheets();
            primer.GoogleClientSet(googleID, googleSecret);// sets statics for google aheets
            parser = new dataPars(dataScorce.googleSheet, "https://docs.google.com/spreadsheets/d/1DF15HgrXx9X-ntNgUI0RJhoUhc548RB855a-UvSj_kw/edit#gid=0",page-1,startingPoint);


            //sets mode
            switch (mode)
            {
                case graphType.barchart:
                    {
                        barChart = new barChartMain(parser.getParsedData(), this.gameObject); ;
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
