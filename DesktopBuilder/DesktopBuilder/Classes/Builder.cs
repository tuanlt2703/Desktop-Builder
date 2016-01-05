using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DesktopBuilder.Classes
{
    class Builder
    {
        #region Constructor
        public Builder(int id, uint money)
        {
            dbCon = new SQLiteConnection("Data Source=Recipe.db;Version=3;"); // connect to database
            this.LoadRecipe(id, money);
            this.Money = money;
        }
        #endregion

        #region Properties
        private List<double> RatioList = new List<double>();
        private SQLiteConnection dbCon;
        private uint Money;
        #endregion

        #region Methods
        private void CreateTable()
        {
            dbCon.Open();
            string tmp = "CREATE TABLE Ratio (CPU DOUBLE NOT NULL , Mainboard DOUBLE NOT NULL , RAM DOUBLE NOT NULL , HDD DOUBLE NOT NULL , SSD DOUBLE NOT NULL , VGA DOUBLE NOT NULL , PSU DOUBLE NOT NULL , Cases DOUBLE NOT NULL , Fan DOUBLE NOT NULL , Cooler DOUBLE NOT NULL , ODD DOUBLE NOT NULL , SoundCard DOUBLE NOT NULL , Max INTEGER NOT NULL , Min INTEGER NOT NULL, Id INTERGER NOT NULL )";
            SQLiteCommand cmd = new SQLiteCommand(tmp, dbCon);
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }
        private void LoadRecipe(int id, uint money)
        {
            dbCon.Open();
            string query = "select * From Ratio Where (Ratio.Id = " + id + ") and (Ratio.Max >" + money + ") and (Ratio.Min <" + money + ")";
            //create query command & execute
            SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
            SQLiteDataReader myReader = cmd.ExecuteReader();

            myReader.Read();

            for (int i = 0; i <= 11; i++)
            {
                RatioList.Add(myReader.GetDouble(i));
            }
            
            dbCon.Close();
        }
        #endregion
    }
}
