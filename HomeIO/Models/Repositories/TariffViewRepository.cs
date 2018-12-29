using HomeIO.Models.Entities;
using HomeIO.Models.Views;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HomeIO.Models.Repositories
{
    public class TariffViewRepository : SQLConnection
    {
        public TariffViewRepository()
        {
        }

        public IList<TariffView> GetAll()
        {
            using (SqlCommand command = CreateCommand("SELECT * FROM vwTariffs ORDER BY StartDate DESC")) {
                SqlDataReader reader = command.ExecuteReader();

                IList<TariffView> rows = new List<TariffView>();

                while (reader.Read())
                {
                    rows.Add(new TariffView
                    {
                        Id = reader.GetInt32(0),
                        TypeId = reader.GetInt32(1),
                        Unit = reader.GetString(2),
                        Cost = reader.GetString(3),
                        Date = reader.GetDateTime(4),
                        Source = reader.GetString(5),
                        TypeName = reader.GetString(6)
                    });
                }

                Close();

                return rows;
            }
        }

        public IList<TariffView> GetTopTwoById(int id) {
            using (SqlCommand command = CreateCommand("SELECT TOP (2) * FROM vwTariffs WHERE TypeId = @typeId ORDER BY StartDate DESC"))
            {
                command.Parameters.AddWithValue("typeId", id);
                SqlDataReader reader = command.ExecuteReader();

                IList<TariffView> rows = new List<TariffView>();

                if (reader.HasRows) {
                    while (reader.Read())
                    {
                        rows.Add(new TariffView
                        {
                            Id = reader.GetInt32(0),
                            TypeId = reader.GetInt32(1),
                            Unit = reader.GetString(2),
                            Cost = reader.GetString(3),
                            Date = reader.GetDateTime(4),
                            Source = reader.GetString(5),
                            TypeName = reader.GetString(6)
                        });
                    }
                }

                Close();

                return rows;
            }
        }

        public IList<TariffView> GetById(int id)
        {
            using (SqlCommand command = CreateCommand("SELECT * FROM vwTariffs WHERE TypeId = @typeId ORDER BY StartDate DESC"))
            {
                command.Parameters.AddWithValue("typeId", id);
                SqlDataReader reader = command.ExecuteReader();

                IList<TariffView> rows = new List<TariffView>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rows.Add(new TariffView
                        {
                            Id = reader.GetInt32(0),
                            TypeId = reader.GetInt32(1),
                            Unit = reader.GetString(2),
                            Cost = reader.GetString(3),
                            Date = reader.GetDateTime(4),
                            Source = reader.GetString(5),
                            TypeName = reader.GetString(6)
                        });
                    }
                }

                Close();

                return rows;
            }
        }
    }
}