using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Shops
{
    public class Connection
    {
        public DbConnection GetConnection
        {
            get
            {
                DbProviderFactory providerFactory = DbProviderFactories.GetFactory(ConfigurationManager
                                           .ConnectionStrings["Shops1"].ProviderName);

                DbConnection connection = providerFactory.CreateConnection();

                connection.ConnectionString = ConfigurationManager.ConnectionStrings["Shops1"].ConnectionString;
                return connection;
            }
        }

        public List<Orders> GetOrders()
        {
            List<Orders> orders = new List<Orders>();

            using (var connection = GetConnection)
            {
            connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = "select * from orders";

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new Orders
                    {
                        Id = (int)reader["id"],
                        CustomerId = (int)reader["idCustomer"],
                        SellerId = (int)reader["idSeller"],
                        Price = (decimal)reader["price"],
                        OrderDate = DateTime.Parse(reader["orderDate"].ToString())
                    });
                }
            }

            return orders;
        }

        public List<Customers> GetCustomers()
        {
            List<Customers> customers = new List<Customers>();
            using(var connection = GetConnection)
            {
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "select * from Customers";

                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customers
                    {
                        Id = (int)reader["id"],
                        Firstname = reader["firstname"].ToString(),
                        Surname = reader["surname"].ToString(),
                    });
                }
            }
            return customers;
        }

        public List<Seller> GetSellers()
        {
            List<Seller> sellers = new List<Seller>();

            using (var connection = GetConnection)
            {
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = "select * from sellers";

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    sellers.Add(new Seller
                    {
                        Id = (int)reader["id"],
                        Firstname = reader["firstname"].ToString(),
                        Surname = reader["surname"].ToString(),
                    });
                }
            }
            return sellers;
        }
    }
}
