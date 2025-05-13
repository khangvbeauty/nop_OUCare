using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using Microsoft.VisualBasic.FileIO;


public class SymptomChecker
{
    public class SymptomEntry
    {
        public string TrieuChung { get; set; }
        public string Benh { get; set; }
        public List<string> Thuoc { get; set; }
        public string GoiY { get; set; }  

    }

    private List<SymptomEntry> symptomList;

    public SymptomChecker(string csvPath)
    {
        symptomList = new List<SymptomEntry>();

        using (TextFieldParser parser = new TextFieldParser(csvPath, new UTF8Encoding(true))) 
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;

            parser.ReadLine(); // bỏ dòng tiêu đề

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();

                if (fields.Length >= 5)
                {
                    var trieuChung = fields[0].Trim().Trim('\uFEFF'); // loại bỏ BOM nếu có
                    var benh = fields[1].Trim();
                    var thuoc1 = fields[2].Trim();
                    var thuoc2 = fields[3].Trim();
                    var goiY = fields[4].Trim();

                    var thuocList = new List<string>();
                    if (!string.IsNullOrEmpty(thuoc1)) thuocList.Add(thuoc1);
                    if (!string.IsNullOrEmpty(thuoc2)) thuocList.Add(thuoc2);

                    symptomList.Add(new SymptomEntry
                    {
                        TrieuChung = trieuChung,
                        Benh = benh,
                        Thuoc = thuocList,
                        GoiY = goiY
                    });

                }
            }
        }
    }

    public (string Benh, string Thuoc, string GoiY)? FindClosestMatch(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;

        string normalizedInput = input.Trim().ToLower();

        var exactMatch = symptomList.FirstOrDefault(s =>
            s.TrieuChung?.Trim().ToLower() == normalizedInput);

        if (exactMatch != null)
        {
            return (
                exactMatch.Benh,
                string.Join(", ", exactMatch.Thuoc),
                exactMatch.GoiY
            );
        }

        // Tìm khớp gần đúng nếu cần
        var bestMatch = symptomList
            .Select(s => new
            {
                Entry = s,
                Distance = LevenshteinDistance(s.TrieuChung.ToLower(), normalizedInput)
            })
            .OrderBy(x => x.Distance)
            .FirstOrDefault();

        if (bestMatch != null && bestMatch.Distance <= 2) // giảm ngưỡng nếu cần
        {
            var entry = bestMatch.Entry;
            return (entry.Benh, string.Join(", ", entry.Thuoc), entry.GoiY);
        }

        return null;
    }


    private int LevenshteinDistance(string s, string t)
    {
        var n = s.Length;
        var m = t.Length;
        var d = new int[n + 1, m + 1];

        for (int i = 0; i <= n; i++) d[i, 0] = i;
        for (int j = 0; j <= m; j++) d[0, j] = j;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                var cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                d[i, j] = new int[] {
                    d[i - 1, j] + 1,
                    d[i, j - 1] + 1,
                    d[i - 1, j - 1] + cost
                }.Min();
            }
        }

        return d[n, m];
    }

}
