using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace F4_WebService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        string connection = @"Data Source=DESKTOP-O41O67V\SQLEXPRESS;Initial Catalog=BeautySalon;Integrated Security=True";


        public DataTable GetAll()
        {
            string command = "select p.ID, p.Paket_ID, p.Paket_Name, p.Price, mu.Paket_ID, mu.User_Name from Pakets as p join Malatko_Users as mu on p.Paket_ID = mu.Paket_ID";
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
