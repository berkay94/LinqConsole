using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //****************************************//
            //var dizi = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 };

            //1.YÖNTEM
            //var tekler = from tek in dizi where tek % 2 == 1 select tek;


            ////2.YÖNTEM
            //var tekler = dizi.Where(I => I % 2 == 1);


            //foreach (var item in tekler)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //****************************************//


            //*****************************************///
            //List<Ogrenci> ogrenciler = new List<Ogrenci>();

            //Ogrenci o = new Ogrenci() { Adi = "Ali", Soyadi = "Yildirim", No = 1 };
            //ogrenciler.Add(o);

            //o = new Ogrenci() { Adi = "Veli", Soyadi = "Duran", No = 2 };
            //ogrenciler.Add(o);

            //o= new Ogrenci() { Adi = "Hale", Soyadi = "Yilmaz", No = 3 };
            //ogrenciler.Add(o);

            //var query = from og in ogrenciler select new { og.Adi, og.Soyadi };
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.Adi + " " + item.Soyadi);
            //}
            //****************************************///


            //***********************************//
            DataTable tbl = new DataTable();
            tbl = getCustomer();
            var query = from c in tbl.AsEnumerable() select c;
            foreach (var item in query)
            {
                Console.WriteLine(item.Field<string>("CompanyName"));
            }
            //**********************************//


            Console.ReadKey();


            
        }

        public static DataTable getCustomer()
        {
            DataTable tbl = new DataTable();
            string constr = "Data Source=10.10.22.199;Initial Catalog=NORTHWND2;User ID=test2;Password=test2";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select*from Customers", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            tbl.Load(rdr);
            con.Close();

            return tbl;
        }
        public class Ogrenci
        {
            public string Adi { get; set; }
            public string Soyadi { get; set; }
            public int No { get; set; }
        }
    }
   
    
}
