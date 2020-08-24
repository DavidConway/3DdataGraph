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
        [SerializeField]
        private int[] startingPoint = new int[2]; // two ints to represent the data point 

        [SerializeField]
        private int page;

        [SerializeField]
        private string link;


        void Start()
        {
            // import/user settings
            mode = graphType.barchart;

            //calls parser
            googleSheets primer = new googleSheets();
            primer.GoogleClientSet(googleID, googleSecret);// sets statics for google aheets
            parser = new dataPars(dataScorce.googleSheet,link,page-1,startingPoint);


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
