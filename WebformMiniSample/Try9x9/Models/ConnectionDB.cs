using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Try9x9.Models
{
    public class ConnectionDB
    {
        public static void Create(int Base, int Multiplier)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=SampleProject; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"INSERT INTO Practice
                                        (BaseNumber, CoefficientNumber, CreateDate )
                                    VALUES
                                        (@BaseNumber, @CoefficientNumber, @CreateDate )";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@BaseNumber", Base);
                command.Parameters.AddWithValue("@CoefficientNumber", Multiplier);
                command.Parameters.AddWithValue("@CreateDate ", DateTime.Now);


                try
                {
                    //開始連線
                    connection.Open();

                    //受影響的資料筆數(沒有使用)
                    int totalChangRows = command.ExecuteNonQuery();
                    Console.WriteLine("Total chang" + totalChangRows + " Rows.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
    }
}