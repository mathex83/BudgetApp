using System;
using System.Collections.Generic;
using System.IO;

namespace BudgetApp.Models.CSV_loader
{
    public class FileUpload
    {
        public string FileUrl { get; set; } = @"wwwroot/csv/Budget 2021-01-01t2022-05-02.csv";
        public List<CSV_model> lines = new List<CSV_model>();
        public FileUpload()
        {
            string[] fromFile = File.ReadAllLines(FileUrl);
            for (int i = 1; i < fromFile.Length; i++)
            {
                string[] something = fromFile[i].Split(';');
                lines.Add(new CSV_model
                {
                    Bogføringsdato = something[0],
                    Beløb = Convert.ToDecimal(something[1]),
                    Afsender = something[2],
                    Modtager = something[3],
                    Navn = something[4],
                    Beskrivelse = something[5],
                    Saldo = Convert.ToDecimal(something[6]),
                    Valuta = something[7],
                    Afstemt = something[8],
                });
            }
        }
    }
}
