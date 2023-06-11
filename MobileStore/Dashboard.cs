
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class Dashboard : DbConnection
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, int>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }

        public Dashboard()
        {

        }

        private void GetNumberItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select count(CustomerID) from sales.Customers";
                    NumCustomers = (int)command.ExecuteScalar();

                    command.CommandText = "select count(Supplierid) from stock.Suppliers";
                    NumSuppliers = (int)command.ExecuteScalar();

                    command.CommandText = "select count(Productid) from stock.Products";
                    NumProducts = (int)command.ExecuteScalar();

                    //command.CommandText = @"select count(Orderid) from [Orders]" +
                    //                      "where OrderDate between  @fromDate and @toDate";

                    command.CommandText = "sales.uspOrderCountWithinDates";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumOrders = (int)command.ExecuteScalar();
                }
            }
        }
        private void GetProductAnalisys()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //command.CommandText = "select top 5 brand, model, sum(od.Quantity) as total from products p inner join OrderDetails od on p.ProductID = od.ProductID where od.OrderID in (select OrderID from Orders o where o.OrderDate between @fromDate and @toDate ) group by od.ProductID, Brand, Model order by total desc";
                    command.CommandText = "stock.uspGetProductAnalysis";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader[0].ToString() + " " + reader[1].ToString();
                        TopProductsList.Add(
                            new KeyValuePair<string, int>(name, (int)reader[2]));
                    }
                    reader.Close();

                    command.CommandText = "select * from stock.LowStockProducts";
                    command.CommandType = CommandType.Text;
                    //command.CommandText = @"select brand, model, quantity
                      //                      from Productsv
                        //                    where quantity <= 5";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader[0].ToString() + " " + reader[1].ToString();
                        UnderstockList.Add(
                            new KeyValuePair<string, int>(name, (int)reader[2]));
                    }
                    reader.Close();
                }
            }
        }
        private void GetOrderAnalisys()
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalProfit = 0;
            TotalRevenue = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    //command.CommandText = @"select o.orderdate, sum((p.price-p.price*(od.discount/100))*od.quantity) from Orders o inner join OrderDetails od on o.OrderID = od.OrderID inner join Products p on od.ProductID = p.ProductID where o.OrderDate between @fromDate and @toDate group by o.OrderDate";
                    command.CommandText = "sales.uspGetOrderAnalysis";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)float.Parse(reader[1].ToString()))
                            );
                        TotalRevenue += (decimal)float.Parse(reader[1].ToString());
                    }
                    reader.Close();
                    //command.CommandText = @"select sum(temp.price) from(
                    //                      select ((p.price-p.price*(od.discount/100) - ISNULL((SELECT TOP 1 SD.UnitPrice FROM 
                    //                    stock.ShipmentDetails SD WHERE SD.ProductID = P.ProductID),0))*od.quantity) as price from sales.Orders o inner join sales.OrderDetails od on o.OrderID = od.OrderID
                    //                  inner join stock.Products p on od.ProductID = p.ProductID where o.OrderDate between @fromDate and @toDate)temp";
                    command.CommandText = "sales.uspGetProfit";
                    command.CommandType= CommandType.StoredProcedure;
                    TotalProfit =(decimal) float.Parse( command.ExecuteScalar().ToString());

                    //reader = command.ExecuteReader() ;
                    //if(reader.Read())
                    {
                        //TotalProfit = (decimal)float.Parse(reader[0].ToString());
                        //TotalProfit = decimal.Parse(reader[0].ToString());

                    }

                    if (numberDays <= 1)
                    {



                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("hh tt")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //Group by Days
                    else if (numberDays <= 30)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Weeks
                    else if (numberDays <= 92)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = "Week " + order.Key.ToString(),
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Months
                    else if (numberDays <= (365 * 2))
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Years
                    else
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                }
            }
        }

        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetNumberItems();
                GetProductAnalisys();
                GetOrderAnalisys();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
