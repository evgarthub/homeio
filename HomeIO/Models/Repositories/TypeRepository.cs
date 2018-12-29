using DataLayer;
using HomeIO.Models.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HomeIO.Models.Repositories
{
    public class TypeRepository : SQLConnection, IRepository<RType>
    {
        public void Create(RType entity)
        {
            using (SqlCommand command = CreateCommand("INSERT INTO[Types]([Name],[Formula]) VALUES(@typeName, @typeFormula)"))
            {
                command.Parameters.AddWithValue("typeName", entity.Name);
                command.Parameters.AddWithValue("typeFormula", entity.Formula);
                command.ExecuteNonQuery();

                Close();
            }

        }

        public void Delete(RType entity)
        {
            using (SqlCommand command = CreateCommand("DELETE FROM [Types] WHERE Id = @typeId"))
            {
                command.Parameters.AddWithValue("typeId", entity.Id);
                command.ExecuteNonQuery();

                Close();
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand command = CreateCommand("DELETE FROM [Types] WHERE Id = @typeId"))
            {
                command.Parameters.AddWithValue("typeId", id);
                command.ExecuteNonQuery();

                Close();
            }
        }

        public IList<RType> GetAll()
        {
            using (SqlCommand command = CreateCommand("SELECT * FROM [Types]"))
            {
                SqlDataReader reader = command.ExecuteReader();

                IList<RType> rows = new List<RType>();

                while (reader.Read())
                {
                    rows.Add(new RType
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Formula = reader.GetString(2)
                    });
                }

                Close();

                return rows;
            };
        }

        public RType GetById(int id)
        {
            using (SqlCommand command = CreateCommand("SELECT * FROM [Types] WHERE Id = @typeId")) {
                command.Parameters.AddWithValue("typeId", id);
                SqlDataReader reader = command.ExecuteReader();

                IList<RType> rows = new List<RType>();

                while (reader.Read())
                {
                    rows.Add(new RType
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Formula = reader.GetString(2)
                    });
                }

                Close();

                return rows[0];
            }
        }

        public void Update(RType entity)
        {
            using (SqlCommand command = CreateCommand("UPDATE [Types] SET [Name] = @typeName, [Formula] = @typeFormula WHERE Id = @typeId")) {
                command.Parameters.AddWithValue("typeId", entity.Id);
                command.Parameters.AddWithValue("typeName", entity.Name);
                command.Parameters.AddWithValue("typeFormula", entity.Formula);
                command.ExecuteNonQuery();

                Close();
            }
        }
    }
}