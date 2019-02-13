using HomeIO.Models.Views;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HomeIO.Models.Repositories
{
    public class RecordViewRepository : SQLConnection
    {
        public RecordViewRepository()
        {
        }

        public IList<RecordView> GetAll()
        {
            using (SqlCommand command = CreateCommand("SELECT * FROM vwRecords ORDER BY Date DESC")) {
                SqlDataReader reader = command.ExecuteReader();

                IList<RecordView> rows = new List<RecordView>();

                while (reader.Read())
                {
                    rows.Add(new RecordView
                    {
                        Id = reader.GetInt32(0),
                        TypeId = reader.GetInt32(1),
                        TypeName = reader.GetString(4),
                        CurrentValue = reader.GetDouble(2),
                        Date = reader.GetDateTime(3),
                        Unit = reader.GetString(6),
						UserId = reader.GetString(7)
					});
                }

                Close();

                return rows;
            }
        }


        public IList<RecordView> GetUserTopTwoByTypeId(int id, string userId) {
            using (SqlCommand command = CreateCommand("SELECT TOP (2) * FROM vwRecords WHERE TypeId = @typeId AND UserId = @userId ORDER BY Date DESC"))
            {
                command.Parameters.AddWithValue("typeId", id);
				command.Parameters.AddWithValue("userId", userId);
				SqlDataReader reader = command.ExecuteReader();

                IList<RecordView> rows = new List<RecordView>();

                if (reader.HasRows) {
                    while (reader.Read())
                    {
                        rows.Add(new RecordView
                        {
                            Id = reader.GetInt32(0),
                            TypeId = reader.GetInt32(1),
                            CurrentValue = reader.GetDouble(2),
                            Date = reader.GetDateTime(3),
                            TypeName = reader.GetString(4),
                            Tariff = reader.GetString(5),
                            Unit = reader.GetString(6),
							UserId = reader.GetString(7)
						});
                    }
                }

                Close();

                return rows;
            }
        }

        public IList<RecordView> GetUserByTypeId(int id, string userId)
        {
            using (SqlCommand command = CreateCommand("SELECT * FROM vwRecords WHERE TypeId = @typeId AND UserId = @userId ORDER BY Date DESC"))
            {
                command.Parameters.AddWithValue("typeId", id);
				command.Parameters.AddWithValue("userId", userId);
				SqlDataReader reader = command.ExecuteReader();

                IList<RecordView> rows = new List<RecordView>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rows.Add(new RecordView
                        {
                            Id = reader.GetInt32(0),
                            TypeId = reader.GetInt32(1),
                            CurrentValue = reader.GetDouble(2),
                            Date = reader.GetDateTime(3),
                            TypeName = reader.GetString(4),
                            Tariff = reader.GetString(5),
                            Unit = reader.GetString(6),
							UserId = reader.GetString(7)
						});
                    }
                }

                Close();

                return rows;
            }
        }

		public RecordView GetById(int id)
		{
			using (SqlCommand command = CreateCommand("SELECT * FROM vwRecords WHERE Id = @id ORDER BY Date DESC"))
			{
				command.Parameters.AddWithValue("id", id);
				SqlDataReader reader = command.ExecuteReader();

				IList<RecordView> rows = new List<RecordView>();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						rows.Add(new RecordView
						{
							Id = reader.GetInt32(0),
							TypeId = reader.GetInt32(1),
							CurrentValue = reader.GetDouble(2),
							Date = reader.GetDateTime(3),
							TypeName = reader.GetString(4),
							Tariff = reader.GetString(5),
							Unit = reader.GetString(6),
							UserId = reader.GetString(7)
						});
					}
				}

				Close();

				return rows[0];
			}
		}

		public IList<RecordView> GetUserAll(string id)
		{
			using (SqlCommand command = CreateCommand("SELECT * FROM vwRecords WHERE UserId = @id ORDER BY Date DESC"))
			{
				command.Parameters.AddWithValue("id", id);
				SqlDataReader reader = command.ExecuteReader();

				IList<RecordView> rows = new List<RecordView>();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						rows.Add(new RecordView
						{
							Id = reader.GetInt32(0),
							TypeId = reader.GetInt32(1),
							CurrentValue = reader.GetDouble(2),
							Date = reader.GetDateTime(3),
							TypeName = reader.GetString(4),
							Tariff = reader.GetString(5),
							Unit = reader.GetString(6),
							UserId = reader.GetString(7)
						});
					}
				}

				Close();

				return rows;
			}
		}
	}
}