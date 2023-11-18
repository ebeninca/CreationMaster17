using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CreationMaster
{
    class DatabaseCompare
    {
        /*static void Main()
        {
            // Connection strings for the two databases
            string connectionStringV1 = "YourConnectionStringForVersion1";
            string connectionStringV2 = "YourConnectionStringForVersion2";

            // Table to compare
            string tableName = "YourTableName";

            // Compare the data in the specified table
            CompareTableData(connectionStringV1, connectionStringV2, tableName);
        }*/

        static void CompareTableData(string connectionStringV1, string connectionStringV2, string tableName)
        {
            try
            {
                // Get data from both databases
                DataTable tableDataV1 = GetTableData(connectionStringV1, tableName);
                DataTable tableDataV2 = GetTableData(connectionStringV2, tableName);

                // Compare the data
                CompareData(tableDataV1, tableDataV2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static DataTable GetTableData(string connectionString, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Use a SELECT query to retrieve data from the specified table
                string query = $"SELECT * FROM {tableName}";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        static void CompareData(DataTable dataV1, DataTable dataV2)
        {
            // Compare the data based on your requirements
            // For simplicity, this example just compares row counts and data differences

            Console.WriteLine($"Total rows in Version 1: {dataV1.Rows.Count}");
            Console.WriteLine($"Total rows in Version 2: {dataV2.Rows.Count}");

            // Find added and removed rows
            /*var addedRows = dataV2.AsEnumerable().Except(dataV1.AsEnumerable(), DataRowComparer.Default);
            var removedRows = dataV1.AsEnumerable().Except(dataV2.AsEnumerable(), DataRowComparer.Default);

            Console.WriteLine("\nAdded Rows:");
            foreach (var row in addedRows)
            {
                Console.WriteLine(string.Join(", ", row.ItemArray));
            }

            Console.WriteLine("\nRemoved Rows:");
            foreach (var row in removedRows)
            {
                Console.WriteLine(string.Join(", ", row.ItemArray));
            }*/
        }
    }
}
