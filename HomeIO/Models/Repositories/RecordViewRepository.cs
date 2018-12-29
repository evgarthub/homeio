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
                        Unit = reader.GetString(6)
                    });
                }

                Close();

                return rows;
            }
        }

        public IList<RecordView> GetTopTwoById(int id) {
            using (SqlCommand command = CreateCommand("SELECT TOP (2) * FROM vwRecords WHERE TypeId = @typeId ORDER BY Date DESC"))
            {
                command.Parameters.AddWithValue("typeId", id);
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
                            Unit = reader.GetString(6)
                        });
                    }
                }

                Close();

                return rows;
            }
        }

        public IList<RecordView> GetById(int id)
        {
            using (SqlCommand command = CreateCommand("SELECT * FROM vwRecords WHERE TypeId = @typeId ORDER BY Date DESC"))
            {
                command.Parameters.AddWithValue("typeId", id);
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
                            Unit = reader.GetString(6)
                        });
                    }
                }

                Close();

                return rows;
            }
        }
    }
}