using DataLayer;
using HomeIO.Models.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HomeIO.Models.Repositories
{
    public class RecordRepository : SQLConnection, IRepository<Record>
    {
        public void Create(Record entity)
        {
            using (SqlCommand command = CreateCommand("INSERT INTO[Records]([TypeId],[CurrentValue],[Date]) VALUES(@recordTypeId, @recordCurrentValue, @recordDate)"))
            {             
                command.Parameters.AddWithValue("recordTypeId", entity.TypeId);
                command.Parameters.AddWithValue("recordCurrentValue", entity.CurrentValue);
                command.Parameters.AddWithValue("recordDate", entity.Date);
                command.ExecuteNonQuery();
                Close();
            }
        }

        public void Delete(Record entity)
        {
            using (SqlCommand command = CreateCommand("DELETE FROM [Records] WHERE Id = @recordId")) {
                command.Parameters.AddWithValue("recordId", entity.Id);
                command.ExecuteNonQuery();

                Close();
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand command = CreateCommand("DELETE FROM [Records] WHERE Id = @recordId"))
            {
                command.Parameters.AddWithValue("recordId", id);
                command.ExecuteNonQuery();

                Close();
            }
        }

        public IList<Record> GetAll()
        {
            using (SqlCommand command = CreateCommand("SELECT Records.*, Types.Name FROM Records JOIN Types ON Records.TypeId = Types.Id")) {
                SqlDataReader reader = command.ExecuteReader();

                IList<Record> rows = new List<Record>();

                while (reader.Read())
                {
                    rows.Add(new Record
                    {
                        Id = reader.GetInt32(0),
                        TypeId = reader.GetInt32(1),
                        CurrentValue = reader.GetDouble(2),
                        Date = reader.GetDateTime(3)
                    });
                }

                Close();

                return rows;
            }
        }

        public Record GetById(int id)
        {
            using (SqlCommand command = CreateCommand("SELECT * FROM [Records] WHERE [Id] = @recordId")) {
                command.Parameters.AddWithValue("recordId", id);
                SqlDataReader reader = command.ExecuteReader();

                IList<Record> rows = new List<Record>();

                while (reader.Read())
                {
                    rows.Add(new Record
                    {
                        Id = reader.GetInt32(0),
                        TypeId = reader.GetInt32(1),
                        CurrentValue = reader.GetDouble(2),
                        Date = reader.GetDateTime(3)
                    });
                }

                Close();

                return rows[0];
            }
        }

        public void Update(Record entity)
        {
            using (SqlCommand command = CreateCommand("UPDATE [Records] SET [TypeId] = @recordTypeId, [CurrentValue] = @recordCurrentValue, [Date] = @recordDate WHERE [Id] = @recordId"))
            {
                command.Parameters.AddWithValue("recordId", entity.Id);
                command.Parameters.AddWithValue("recordTypeId", entity.TypeId);
                command.Parameters.AddWithValue("recordCurrentValue", entity.CurrentValue);
                command.Parameters.AddWithValue("recordDate", entity.Date);
                command.ExecuteNonQuery();

                Close();
            }
        }
    }
}