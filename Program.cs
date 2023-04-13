using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConexionSQL01
{

    enum EstatusLectura
    {
        Exitoso = 1,
        UsuarioNoEncontrado = 2,
        ErrorDeSistema = 5
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consulto la tabla 0 del DS y hago filtrado por LatName\n");
            Consultas consultaPeople = new Consultas();
            DataSet ds1 = consultaPeople.RecuperaPeopleDS();

            Console.WriteLine("\t\t\t\tTABLA ORIGINAL: Table\n\n");
            foreach (DataColumn dc in ds1.Tables["Table"].Columns)
            {
                Console.Write("\t" +dc);
            }
            Console.WriteLine();

            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                Console.Write("\t" + row[0] + "\t" + row[1] + "\t\t" + row[2] + "\t\t" + row[3] + "\t" + row[4] + "\t");                 
                Console.WriteLine();
            }


            Console.WriteLine("\n\n\t\t\t\tTABLA FILTRADA: (por apellido 'cruz') \n\n");

            foreach (DataColumn dc in ds1.Tables["Table"].Columns)
            {
                Console.Write("\t" + dc);
            }

            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                while ((string)row["LastName"] == "Cruz")
                {
                    Console.Write("\t" + row[0] + "\t" + row[1] + "\t\t" + row[2] + "\t\t" + row[3] + "\t" + row[4] + "\t");                    
                    break;
                }
                Console.WriteLine();
            }


            
            Consultas consultaPeopleAndCity = new Consultas();
            // Cargo el DS con dos tablas, Table (People) y Table1 (City)
            DataSet ds2 = consultaPeopleAndCity.RecuperaPeopleAndCity();

            Console.WriteLine("\n\n\n\t\t\t\tNombre: Table \t Nota: Tabla original\n\n");

            foreach (DataColumn dc in ds2.Tables[0].Columns)
            {
                Console.Write("\t\t" + dc);
            }
            Console.WriteLine();
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                Console.WriteLine("\t\t" + dr["id"] + "\t\t" + dr["FirstName"] + "\t\t\t" + dr["LastName"] + "\t\t\t" + dr["EmailAddress"] + "\t" + dr["PhoneNumber"]);
            }

            Console.WriteLine("\n\n\n\t\t\t\tNombre: Table \t Nota: Tabla filtrada por id entre 500 y 545 *\n\n");

            foreach (DataColumn dc in ds2.Tables[0].Columns)
            {
                Console.Write("\t\t" + dc);
            }
            Console.WriteLine();
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                if ((int)dr["id"] >= 500 && (int)dr["id"] <= 545)
                {
                    Console.WriteLine("\t\t" + dr[0] + "\t\t" + dr[1] + "\t\t" + dr[2] + "\t\t" + dr[3] + "\t\t" + dr[4]);
                }
            }

            Console.WriteLine("\n\n\n");

            Console.WriteLine("Imprimo un registro específico: Registro 501\n");
            Console.WriteLine(ds2.Tables[0].Rows[500][0].ToString() + "\t" + ds2.Tables[0].Rows[500][1].ToString() + "\t" + 
                ds2.Tables[0].Rows[500]["LastName"].ToString() + "\t" + 
                ds2.Tables["Table"].Rows[500]["EmailAddress"].ToString() + "\t\t" + 
                ds2.Tables[0].Rows[500]["PhoneNumber"].ToString());


            Console.WriteLine("-----------------");

            Console.WriteLine("\n\n\n FILTRAR DATATABLE OBTENIENDO UN NUEVO DATATABLE \n\n\n");


            DataRow[] resDTFiltered = ds1.Tables[0].Select("LastName = 'Cruz'");
            DataTable newTable = resDTFiltered.CopyToDataTable();

            Console.ReadLine();
        }
    }
}
