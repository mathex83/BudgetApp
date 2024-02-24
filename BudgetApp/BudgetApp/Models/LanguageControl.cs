using BudgetApp.Data;

namespace BudgetApp.Models
{
    public class LanguageControl
    {
        public string HomeButton { get; set; }
        public string SettingsButton { get; set; }
        public string BackToList { get; set; }
        public string EditButton { get; set; }
        public string DetailsButton { get; set; }
        public string DeleteButton { get; set; }
        public string CategoryTypeName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string CreateButton { get; set; }
        public string CreateNewButton { get; set; }
        public string SaveButton { get; set; }
        public string SureToDelete { get; set; }
        public string BudgetButton { get; set; }
        public string BudgetCreateButton { get; set; }
        public string BudgetViewButton { get; set; }
        public string CurrencyText { get; set; }
        public string CSVButton { get; set; }
        public string BankButton { get; set; }
        public string Amount { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountBalance { get; set; }
        public string BudgetMonth { get; set; }
        public string BudgetYear { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Income { get; set; }
        public string Expense { get; set; }
        public string list { get; set; }


        public LanguageControl(string lang)
        {
            switch (lang)
            {
                case "DK":
                    HomeButton = "Hjem";
                    SettingsButton = "Indstillinger";
                    BackToList = "Tilbage til listen";
                    EditButton = "Redigér";
                    DetailsButton = "Detaljer";
                    DeleteButton = "Slet";
                    CategoryTypeName = "Kategoritype";
                    CategoryName = "Kategori";
                    SubCategoryName = "Underkategori";
                    CreateButton = "Opret";
                    CreateNewButton = "Opret ny";
                    SaveButton = "Ok";
                    SureToDelete = "Er du sikker på du vil slette?";
                    BudgetButton = "Budget";
                    BudgetCreateButton = "Opret nyt budget";
                    BudgetViewButton = "Budget-oversigt";
                    CurrencyText = "DKK";
                    BankButton = "Hent kontoudskrift";
                    CSVButton = ".csv-fil";
                    Amount = "Beløb";
                    BudgetMonth = "Måned";
                    BudgetYear = "År";
                    AccountId = "Kontoid";
                    AccountName = "Kontonavn";
                    AccountBalance = "Saldo";
                    Description = "Beskr.";
                    UserId = "Brugerid";
                    Income = "Indkomst";
                    Expense = "Udgift";
                    list = "-liste";
                    break;
                case "UK":
                    HomeButton = "Home";
                    SettingsButton = "Settings";
                    BackToList = "Back to list";
                    EditButton = "Edit";
                    DetailsButton = "Details";
                    DeleteButton = "Delete";
                    CategoryTypeName = "Category type";
                    CategoryName = "Category";
                    SubCategoryName = "Sub-category";
                    CreateButton = "Create";
                    CreateNewButton = "Create new";
                    SaveButton = "Submit";
                    SureToDelete = "Are you sure you want to delete this?";
                    BudgetButton = "Budget";
                    BudgetCreateButton = "Create new budget";
                    BudgetViewButton = "Budget view";
                    CurrencyText = "£";
                    BankButton = "Load transaction-file";
                    CSVButton = ".csv-file";
                    Amount = "Amount";
                    BudgetMonth = "Month";
                    BudgetYear = "Year";
                    AccountId = "Acc. id";
                    AccountName = "Acc. name";
                    AccountBalance = "Balance";
                    Description = "Descr.";
                    UserId = "Userid";
                    Income = "Income";
                    Expense = "Expense";
                    list = "-list";
                    break;
                default:
                    HomeButton = "Home";
                    SettingsButton = "Settings";
                    BackToList = "Back to list";
                    EditButton = "Edit";
                    DetailsButton = "Details";
                    DeleteButton = "Delete";
                    CategoryTypeName = "Category type";
                    CategoryName = "Category";
                    SubCategoryName = "Sub-category";
                    CreateButton = "Create";
                    CreateNewButton = "Create new";
                    SaveButton = "Submit";
                    SureToDelete = "Are you sure you want to delete this?";
                    BudgetButton = "Budget";
                    BudgetCreateButton = "Create new budget";
                    BudgetViewButton = "Budget view";
                    CurrencyText = "$";
                    BankButton = "Load transaction-file";
                    CSVButton = ".csv-file";
                    Amount = "Amount";
                    BudgetMonth = "Month";
                    BudgetYear = "Year";
                    AccountId = "Acc. id";
                    AccountName = "Acc. name";
                    AccountBalance = "Balance";
                    Description = "Descr.";
                    UserId = "Userid";
                    Income = "Income";
                    Expense = "Expense";
                    list = "-list";
                    break;
            }
        }
    }
}