﻿// Anita Martin
// amartin98@cnm.edu
// Title: DBDemo- In class assignment

// InventoryItemsServices.cs

using DBDemoInClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemo
{
    public class InventoryItemsService
    {
        public List<InventoryItem> GetAll()
        {

            List<InventoryItem> items = new List<InventoryItem>();

            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string select = "SELECT * FROM InventoryItem;";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InventoryItem item = new InventoryItem();
                    item.Id = reader.GetInt32(0);
                    item.Name = reader.GetString(1);
                    item.Location = reader.GetInt32(2);
                    item.Weight = reader.GetDouble(3);
                    item.Cost = reader.GetDecimal(4);
                    item.Remarks = reader.GetString(5);
                    items.Add(item);
                }
                conn.Close();
            }
            return items;
        }

        public InventoryItem GetItem(int id)
        {

            InventoryItem item = new InventoryItem();

            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string select = "SELECT * FROM InventoryItem WHERE Id = @Id);";
                SqlCommand cmd = new SqlCommand(select, conn);
                cmd.Parameters.AddWithValue("Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item.Id = reader.GetInt32(0);
                item.Name = reader.GetString(1);
                item.Location = reader.GetInt32(2);
                item.Weight = reader.GetDouble(3);
                item.Cost = reader.GetDecimal(4);
                item.Remarks = reader.GetString(5);
                conn.Close();
            }
            return item;
        }

        public void AddItem(InventoryItem item)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string cmdStr = @"INSERT INTO InventoryItem (Name, Location, Weight, Cost, Remarks) VALUES (@Name, @Location, @Weight, @Cost, @Remarks);";
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                cmd.Parameters.AddWithValue("Name", item.Name);
                cmd.Parameters.AddWithValue("Location", item.Location);
                cmd.Parameters.AddWithValue("Weight", item.Weight);
                cmd.Parameters.AddWithValue("Cost", item.Cost);
                cmd.Parameters.AddWithValue("Remarks", item.Remarks);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteItem(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string cmdStr = @"DELETE FROM InventoryItem WHERE Id = @Id;";
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateItem(InventoryItem item)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string cmdStr = @"UPDATE InventoryItem SET Name = @Name, Location = @Location, Weight = @Weight, Cost = @Cost, Remarks= @Remarks WHERE Id = @Id;";
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                cmd.Parameters.AddWithValue("Id", item.Id);
                cmd.Parameters.AddWithValue("Name", item.Name);
                cmd.Parameters.AddWithValue("Location", item.Location);
                cmd.Parameters.AddWithValue("Weight", item.Weight);
                cmd.Parameters.AddWithValue("Cost", item.Cost);
                cmd.Parameters.AddWithValue("Remarks", item.Remarks);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}