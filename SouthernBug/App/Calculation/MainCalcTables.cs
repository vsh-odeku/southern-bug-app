using System.Collections.Generic;
using System.Linq;
using SouthernBug.App.Calculation.Table;
using SouthernBug.App.Entity.Dump;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.Repository;
using SouthernBug.App.Repository.TableContract.Contracts;
using SouthernBug.App.TableProcessing;
using SouthernBug.App.Window.Calculations;

namespace SouthernBug.App.Calculation
{
    public class MainCalcTables
    {
        private readonly DbTableLoader dbTableLoader;
        private readonly Dictionary<string, string> userInput;

        private readonly List<TableProcessing.Table> customTables = new List<TableProcessing.Table>();

        public MainCalcTables(DbTableLoader dbTableLoader, Dictionary<string, string> userInput)
        {
            this.dbTableLoader = dbTableLoader;
            this.userInput = userInput;
            LoadDbTables();
            CreateCalcsTables();
        }

        public TableProcessing.Table Result { get; set; }
        public TableProcessing.Table ResultEstimation { get; set; }

        public TableProcessing.Table CalcsHydro { get; private set; }
        public TableProcessing.Table CalcsMeteo { get; private set; }

        public TableProcessing.Table CoeffsTable { get; private set; }

        public Table.UserInputTable UserInputTable { get; private set; }

        public TableProcessing.Table BazaInfoHydro { get; private set; }
        public TableProcessing.Table BazaInfoMeteo { get; private set; }

        public TableProcessing.Table OperInfoHydro { get; private set; }
        public TableProcessing.Table OperInfoMeteo { get; private set; }

        public TableProcessing.Table BazaInfoCoeffs { get; private set; }
        public TableProcessing.Table OrdinKtgr { get; private set; }

        public TableProcessing.Table Posts { get; private set; }

        public TableProcessing.Table ConsultSp { get; private set; }

        private void CreateCalcsTables()
        {
            Result = CreateResultTable();
            ResultEstimation = CreateEstimationTable();

            CalcsHydro = new CalcsHydroTable("Розрахунки - Hydro", OperInfoHydro);
            CalcsMeteo = new CalcMeteoTable("Розрахунки - Meteo", OperInfoMeteo);
            CoeffsTable = new CoeffsTable("Коефіцієнти");

            UserInputTable = new Table.UserInputTable("Введені користувачем дані");
        }

        public void AddCustomTableIfNotExists(TableProcessing.Table newTable)
        {
            foreach (var table in customTables)
                if (table.DataTable.TableName == newTable.DataTable.TableName)
                    return;

            AddCustomTable(newTable);
        }

        public void AddCustomTable(TableProcessing.Table newTable)
        {
            customTables.Add(newTable);
        }

        public TablesDump GetAllOutputDataTables()
        {
            var tablesDump = new TablesDump();

            tablesDump.AddTable("Результат", Result.DataTable);
            tablesDump.AddTable("Результат", ResultEstimation.DataTable);

            var outputTables = new List<TableProcessing.Table>
            {
                CalcsHydro,
                CalcsMeteo,
                CoeffsTable,
                UserInputTable
            };

            outputTables.AddRange(customTables);

            outputTables
                .Select(t => t.DataTable)
                .ToList()
                .ForEach(t => tablesDump.AddTable("Розрахунки", t));

            return tablesDump;
        }

        private void LoadDbTables()
        {
            var userArgYear = userInput[CalculationsForm.Arg_Year];
            var operTableArgs = OperTableContract.CreateArgs(userArgYear);

            OperInfoHydro = dbTableLoader.LoadTable(Tables.Names.OperInfoHydro, operTableArgs);
            OperInfoMeteo = dbTableLoader.LoadTable(Tables.Names.OperInfoMeteo, operTableArgs);

            BazaInfoHydro = dbTableLoader.LoadTable(Tables.Names.BazaInfoHydro);
            BazaInfoMeteo = dbTableLoader.LoadTable(Tables.Names.BazaInfoMeteo);
            BazaInfoCoeffs = dbTableLoader.LoadTable(Tables.Names.BazaInfoCoeffs);

            OrdinKtgr = dbTableLoader.LoadTable(Tables.Names.OrdinKtgr);
            Posts = dbTableLoader.LoadTable(Tables.Names.Posts);
            ConsultSp = dbTableLoader.LoadTable(Tables.Names.ConsultSp);
        }

        public TableProcessing.Table CreateResultTable()
        {
            return new CalcsHydroTable(GetResultTableName(), OperInfoHydro);
        }

        public string GetResultTableName()
        {
            return "Прогноз";
        }

        public TableProcessing.Table CreateEstimationTable()
        {
            return new CalcsHydroTable(GetEstimationTableName(), OperInfoHydro);
        }

        public string GetEstimationTableName()
        {
            return "Оцінка прогнозу";
        }

        private string GetForecastName()
        {
            var name = userInput[CalculationsForm.Arg_ForecastType];

            if (name == ForecastTypes.D2)
            {
                var variant = userInput[CalculationsForm.Arg_D2Variant];

                if (variant == D2VariantItemsRepr.Var1DateSm)
                {
                    name += " " + D2VariantItemsRepr.Var1DateSm_Name;
                }
                else if(variant == D2VariantItemsRepr.Var2DateDb)
                {
                    name += " " + D2VariantItemsRepr.Var2DateDb_Name;
                }
            }

            return name;
        }
    }
}