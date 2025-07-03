using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
	public class DBHelper
	{
		public static SqlConnection GetConnection()
		{
			return new SqlConnection("Data Source=DESKTOP-PI8V1CA\\SQLSERVER2022;Initial Catalog=management_system;Integrated Security=True;Trust Server Certificate=True");
		}
	}
}
