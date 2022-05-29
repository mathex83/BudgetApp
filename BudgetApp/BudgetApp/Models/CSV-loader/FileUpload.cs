using System;
using System.Collections.Generic;
using System.IO;

namespace BudgetApp.Models.CSV_loader
{
    public class FileUpload
    {
        public string FileUrl { get; set; } = @"wwwroot/csv/Budget 2021-01-01t2022-05-02.csv";
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
                        SendingAccount = lineSplit[2],
                        ReceivingAccount = lineSplit[3],
                        NameOfTransaction = lineSplit[4],
                        Description = lineSplit[5],
                        Saldo = Convert.ToDecimal(lineSplit[6]),
                        Currency = lineSplit[7],
                        TransactionApproved = lineSplit[8]
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
        }
    }
}
