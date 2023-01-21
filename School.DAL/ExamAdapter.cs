using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace School.DAL
{
	public class ExamAdapter : IExamAdapter
	{
		private string connectionString = @"Data Source=C:\Sqlite\School.db";
		public IEnumerable<Exam> GetAll()
		{
			string sql = "SELECT Exam.ExamId, Exam.StudentId, Student.FirstName, Student.LastName, Exam.Score " +
				"FROM Exam INNER JOIN Student ON Exam.StudentId=Student.StudentId";
			using(SqliteConnection connection = new SqliteConnection(connectionString))
			{
				return connection.Query<Exam>(sql);
			}
		}

		public Exam GetById(int id)
		{
			string sql = "SELECT ExamId, StudentId, Score FROM Exam WHERE ExamId = @ExamId";
			using(SqliteConnection connection = new SqliteConnection(connectionString))
			{
				return connection.QueryFirst<Exam>(sql, new { ExamId = id });
			}
		}

		public IEnumerable<Exam> GetByStudentId(int studentId)
		{
			string sql = "SELECT Exam.ExamId, Exam.StudentId, Student.FirstName, Student.LastName, Exam.Score" +
				" FROM Exam INNER JOIN Student ON Exam.StudentId=Student.StudentId WHERE Exam.StudentId = @StudentId";
			using(SqliteConnection connection = new SqliteConnection(connectionString))
			{
				return connection.Query<Exam>(sql, new { StudentId = studentId });
			}
		}

		public bool InsertExam(Exam Exam)
		{
			string sql = @"INSERT INTO Exam (StudentId, Score) 
            VALUES (@StudentId, @Score)";
			using(SqliteConnection connection = new SqliteConnection(connectionString))
			{
				int rowsAffected = connection.Execute(sql, Exam);
				if(rowsAffected > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public bool UpdateExam(Exam Exam)
		{
			string sql = @"UPDATE Exam SET StudentId = @StudentId, Score = @Score WHERE ExamId = @ExamId";
			using(SqliteConnection connection = new SqliteConnection(connectionString))
			{
				int rowsAffected = connection.Execute(sql, Exam);
				if(rowsAffected > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public bool DeleteExamById(int id)
		{
			string sql = "DELETE FROM Exam WHERE ExamId = @ExamId";
			using(SqliteConnection connection = new SqliteConnection(connectionString))
			{
				int rowsAffected = connection.Execute(sql, new { ExamId = id });
				if(rowsAffected > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
}