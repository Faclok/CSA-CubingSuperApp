using System;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;

public class ParseRecords : MonoBehaviour
{
    public Text _records;
    public static Text records;

    private void Awake()
    {
        records = _records;
        records.text = GetRecords();
    }

    public static string GetRecords()
    {
        string res = Parse();
        return res;
    }
    public static string Parse()
    {
        try 
        { 

            using (HttpClientHandler hdl = new HttpClientHandler() )
            {
                using (var clnt = new HttpClient(hdl))
                {
                    using (HttpResponseMessage resp = clnt.GetAsync("https://www.worldcubeassociation.org/results/records").Result)
                    {
                        if (resp.IsSuccessStatusCode)
                        {
                            var html = resp.Content.ReadAsStringAsync().Result;
                            if (!string.IsNullOrEmpty(html))
                            {
                                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                doc.LoadHtml(html);

                                var table3by3 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[3]/div[2]/div/div[1]/table");
                                var rows = table3by3.SelectNodes(".//tr");
                                List<List<string>> res = new List<List<string>>();
                                foreach ( var row in rows )
                                {
                                    var cells = row.SelectNodes(".//td");

                                    res.Add(new List<string>(cells.Select(c => c.InnerText)));
                                }
                                Debug.Log(res[0].ToString());
                                return res[1].ToString();
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex) {Debug.Log(ex.Message);}

        return "000";
    }

}
