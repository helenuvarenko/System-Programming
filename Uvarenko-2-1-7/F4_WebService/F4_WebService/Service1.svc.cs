using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Library_4;
using System.Data;
using System.Data.SqlClient;

namespace F4_WebService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        string connection = @"Data Source=DESKTOP-O41O67V\SQLEXPRESS;Initial Catalog=BeautySalon;Integrated Security=True";

        public double F4(double x)
        {
            return KI3_Class_4.F4(x, 3);
        }

        public DataTable GetAllRows()
        {
            string command = "SELECT * FROM beauty";
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(command, connection);
                ad.Fill(ds);
            }
            return ds.Tables[0];
        }
        public DataTable GetRowByID(int ID)
        {
            string command = "SELECT * FROM beauty where ID = '" + ID + "'";
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(command, connection);
                ad.Fill(ds);
            }
            return ds.Tables[0];
        }

    }
}
