using System;
using System.Collections.Generic;
using System.IO;

namespace BudgetApp.Models.CSV_loader
{
    public class FileUpload
    {
        private string FileUrl { get; set; } = @"wwwroot/csv/Budget 2021-01-01t2022-05-02.csv";
        public List<CSV_model> fileLines = new();
        public FileUpload()
        {
            string unwantedSubstring = "bs betaling ";
            string[] fromFile = File.ReadAllLines(FileUrl);
            for (int i = 1; i < fromFile.Length; i++)
            {
                string[] lineSplit = fromFile[i].Split(';');
                if (lineSplit.Length == 9)
                {
                    CSV_model model = new()
                    {
                        TransactionDate = lineSplit[0],
                        Amount = Convert.ToDecimal(lineSplit[1]),
                        SendingAccount = lineSplit[3],
                        ReceivingAccount = lineSplit[2],
                        Description = lineSplit[5],
                        Saldo = Convert.ToDecimal(lineSplit[6]),
                        Currency = lineSplit[7],
                        TransactionApproved = lineSplit[8],
                        NameOfTransaction = ""
                    };
                    fileLines.Add(model);
                    if (model.Description.ToLower().StartsWith(unwantedSubstring))
                    {
                        model.Description = model.Description.Substring(
                            unwantedSubstring.Length,
                            model.Description.Length - unwantedSubstring.Length);
                    }
                }
            }
            foreach (CSV_model c in fileLines)
            {
                c.NameOfTransaction = SetTransactionName(c.Description);
            }
        }
        private string SetTransactionName(string model)
        {
            if (model.ToLower().Contains("ele")) return "El";
            if (model.ToLower().Contains("norlys")) return "El";
            if (model.ToLower().Contains("leje")) return "Husleje";
            if (model.ToLower().Contains("alka")) return "Bilforsikring";
            if (model.ToLower().Contains("moto")) return "Grøn afgift";
            if (model.ToLower().Contains("hiper")) return "Internet";
            if (model.ToLower().Contains("call")) return "Mobil";
            if (model.ToLower().Contains("cbb")) return "Mobil";
            if (model.ToLower().Contains("telia")) return "Mobil";
            if (model.ToLower().Contains("netflix")) return "Netflix";
            if (model.ToLower().Contains("viaplay")) return "Viaplay";
            if (model.ToLower().Contains("disney")) return "Disney+";
            if (model.ToLower().Contains("prosa")) return "Fagforening og A-kasse";
            if (model.ToLower().Contains("liv")) return "Forsikring gruppeliv";
            if (model.ToLower().Contains("lb")) return "Forsikring indbo og ulykke";
            if (model.ToLower().Contains("sygef")) return "Sygeforsikring Danmark";
            if (model.ToLower().Contains("budget")) return "Budget";
            if (model.ToLower().Contains("licens")) return "Licens";
            return "";
        }
    }
}
