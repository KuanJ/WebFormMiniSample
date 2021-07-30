using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccountingNote.SystemAdmin
{
    public class AccountingManager
    {
        //private static string GetConnecionString()
        //{
        //    string val = ConfigurationManager.ConnectionStrings["DafaultConnection"].ConnectionString;
        //    return val;
        //}


        public static DataTable GetAccountingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        ID,
                        Caption,
                        Amount,
                        ActType,
                        CreateDate
                    FROM Accounting
                    WHERE UserID = @userID
";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbCommand, list);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>查詢流水帳</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataRow GetAccounting(int id, string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        ID,
                        Caption,
                        Amount,
                        ActType,
                        CreateDate,
                        Body
                    FROM Accounting
                    WHERE id = @id AND UserID = @userID;";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userID", userID));


            try
            {
                return DBHelper.ReadDataRow(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>建立流水帳</summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreatAccounting(string userID, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 100000)
                throw new ArgumentException("Amount must between 0 and 1,000,000 .");

            if (actType < 0 || actType > 1)
                throw new ArgumentException("ActType must be 0 or 1.");

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" INSERT INTO  [dbo].[Accounting]
                    (
                        UserID,
                        Caption,
                        Amount,
                        ActType,
                        CreateDate,
                        Body
                    )
                    VALUES
                    (
                        @userID,
                        @caption,
                        @amount,
                        @actType,
                        @createDate,
                        @body
                    )
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userID", userID));
            paramList.Add(new SqlParameter("@caption", caption));
            paramList.Add(new SqlParameter("@amount", amount));
            paramList.Add(new SqlParameter("@createDate", DateTime.Now));
            paramList.Add(new SqlParameter("@actType", actType));
            paramList.Add(new SqlParameter("@body", body));

            try
            {
                DBHelper.ModifyData(connStr, dbCommand, paramList);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }

        }


        /// <summary>修改流水帳</summary>
        /// <param name="ID"></param>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool UpdateAccounting(int ID, string userID, string caption, int amount, int actType, string body)
        {

            // <<<< check input >>>>
            if (amount < 0 || amount > 100000)
                throw new ArgumentException("Amount must between 0 and 1,000,000 .");

            if (actType < 0 || actType > 1)
                throw new ArgumentException("ActType must be 0 or 1.");
            // <<<< check input >>>>

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [Accounting]
                    SET  UserID    = @userID
                       ,Caption   = @caption
                       ,Amount    = @amount
                       ,ActType   = @actType
                       ,CreateDate= @createDate
                       ,Body       = @body
                    WHERE
                        ID = @id";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userID", userID));
            paramList.Add(new SqlParameter("@caption", caption));
            paramList.Add(new SqlParameter("@amount", amount));
            paramList.Add(new SqlParameter("@actType", actType));
            paramList.Add(new SqlParameter("@createDate", DateTime.Now));
            paramList.Add(new SqlParameter("@body", body));
            paramList.Add(new SqlParameter("@id", ID));

            //connect db & execute
            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;

            }
        }


        public static void DeleteAccounting(int ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" DELETE [Accounting]
                    WHERE ID = @id";


            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", ID));
            //connect db & execute
            try
            {
                DBHelper.ModifyData(connStr, dbCommand, paramList);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }

        }


    }
}