
using System;
using System.Collections;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using UnityEngine;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;

namespace DataParsing
{

	public class googleSheets
	{
		private IList<IList<object>> sheetData;

		//api in needed info

		static string CLIENT_ID = null;
		static string CLIENT_SECRET = null;
		///static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };

		//app functionality vars
		private string spreadSheetKey = "";
		private string appTitel = "unity";
		private int sheetnumber = 1;

		//output data
		private object[,] outData;

		public googleSheets()
		{

		}
		public googleSheets(string url, int sheet)
		{
			//setUp
			sheetnumber = sheet;
			setSheetKey(url);

			//Authenticate
			var service = new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = GetCredential(),
				ApplicationName = appTitel,
			});

			try {
				Spreadsheet spreadSheetData = service.Spreadsheets.Get(spreadSheetKey).Execute();
				IList<Sheet> sheets = spreadSheetData.Sheets;

				if ((sheets == null) || (sheets.Count <= 0))
				{
					Debug.LogError("Not found any data!");
					return;
				}

				//For each sheet in received data, add it to the .
				List<string> ranges = new List<string>();
				ranges.Add(sheets[sheetnumber].Properties.Title);

				//returns sheet data
				SpreadsheetsResource.ValuesResource.BatchGetRequest request = service.Spreadsheets.Values.BatchGet(spreadSheetKey);
				request.Ranges = ranges;
				BatchGetValuesResponse response = request.Execute();
				sheetData = response.ValueRanges[0].Values;
				genOutData();

			}
			catch (Exception e)
			{
				Debug.Log("error on getting data, possible bad URL" + "\n" + "error log: " + e);
			}

		}

		UserCredential GetCredential()
		{

			UserCredential credential = null;
			ClientSecrets clientSecrets = new ClientSecrets();
			clientSecrets.ClientId = CLIENT_ID;
			clientSecrets.ClientSecret = CLIENT_SECRET;
			try
			{
				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					clientSecrets,
					Scopes,
					"user",
					CancellationToken.None).Result;
			}
			catch (Exception e)
			{
				Debug.LogError(e.ToString());
			}

			return credential;
		}

		//generate output data (row,col)
		public void genOutData()
		{
			int i = sheetData.Count;
			int j = 0;

			//get the max number of cols
			foreach (IList<object> k in sheetData)
			{
				if (k.Count > j)
				{
					j = k.Count;
				}
			}
			outData = new string[i, j];

			// fills outdata whit data from data sheet
			for (int k = 0; k < i; k++)
			{
				for (int l = 0; l < j; l++)
				{
					try
					{
						outData[k, l] = sheetData[k][l];
					}
					catch
					{
						outData[k, l] = "";
					}
				}
			}

		}

		// getters
		public object[,] getOutData()
		{
			return outData;
		}

		//setters
		private void setSheetKey(string url)
		{
			spreadSheetKey = url;
			spreadSheetKey = spreadSheetKey.Remove(0, 39);
			spreadSheetKey = spreadSheetKey.Remove(spreadSheetKey.IndexOf("/"));
		}

		//toString

		public override String ToString()
		{
			string Output = "";

			for (int i = 0; i < outData.GetLength(0); i++)
			{
				for (int j = 0; j < outData.GetLength(1); j++)
				{
					Output += outData[i, j] + " , ";
				}
				Output += "\n";
			}
			return Output;
		}

		public void GoogleClientSet(string ID, string secret)
		{
			CLIENT_ID = ID;
			CLIENT_SECRET = secret;
		}

	}
}
