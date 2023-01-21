using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL
{
	public class ReportAdapter : IReportAdapter
	{
		private string connectionString = @"Data Source=C:\Sqlite\School.db";
		public IEnumerable<Report> GetExamsByScore()
		{
			string sql = @"SELECT COUNT(CASE WHEN Score >= 90 then 1 END) AS AGrade, " +
				"COUNT(CASE WHEN Score >= 80 AND Score < 90 then 1 END) AS BGrade, " +
				"COUNT(CASE WHEN Score >= 70 AND Score < 80 then 1 END) AS CGrade," +
				"COUNT(CASE WHEN Score >= 60 AND Score < 70 then 1 END) AS DGrade," +
				"COUNT(CASE WHEN Score < 60 then 1 END) AS FGrade FROM EXAM";

			using(SqliteConnection connection = new SqliteConnection(connectionString))
			{
				return connection.Query<Report>(sql);
			}
		}
	}
}
