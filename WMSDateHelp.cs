using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace WMS
{
    public class WMSDateHelp
    {
        public static string FilePath = Path.Combine(Application.StartupPath, "Bank.db");
        public static string ConnectionStr= "Data Source=" + FilePath + ";Version=3;";

        public static int adddata(string sql)
        {
            int ok = 0;
            using(var connection=new SQLiteConnection(ConnectionStr))
            {
                connection.Open();
                using(var command=new SQLiteCommand(sql, connection))
                {
                    ok= command.ExecuteNonQuery();
                }
            }
            return ok;
        }
        /// <summary>
        /// 执行多条SQL语句，实现事务处理
        /// </summary>
        /// <param name="SqlStringList">泛型多条SQL语句列表</param>
        /// <returns>返回值为0则不成功回滚</returns>
        public static int ExecuteSqlTran(List<string> SqlStringList)
        {
            using (var connection = new SQLiteConnection(ConnectionStr))
            { 
                connection.Open();
                using(var command=new SQLiteCommand())
                {
                    command.Connection = connection;
                    SQLiteTransaction tx=connection.BeginTransaction();
                    command.Transaction = tx;
                    try
                    {
                        int count = 0;
                        foreach (string sql in SqlStringList)
                        {
                            command.CommandText = sql;
                            count += command.ExecuteNonQuery();
                        }
                        tx.Commit();
                        return count;
                    }
                    catch
                    {
                        tx.Rollback();
                        return 0;
                    }
                }
            }
        }

        public static DataSet Filldata(string sql)
        {
            DataSet ds = new DataSet();
            using(var connection=new SQLiteConnection(ConnectionStr))
            {
                connection.Open();
                using(var command=new SQLiteCommand(sql, connection))
                {
                    using(SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            return ds;
        }
        public static List<T> Query<T>(string query)
        {
            using (var connection = new SQLiteConnection(ConnectionStr))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        var properties = typeof(T).GetProperties();
                        var list = new List<T>();
                        while (reader.Read())
                        {
                            var obj = Activator.CreateInstance<T>();
                            foreach (var property in properties)
                            {
                                int ordinal = reader.GetOrdinal(property.Name);
                                if (reader.GetValue(ordinal) != DBNull.Value)
                                {
                                    property.SetValue(obj, Convert.ChangeType(reader.GetValue(ordinal), property.PropertyType), null);
                                }
                            }
                            list.Add(obj);
                        }
                        return list;
                    }
                }
            }
        }

        public static void ExportToExcel(DataGridView dataGridView,string filename,string Sheetname)
        {
            // 创建一个新的 Excel 工作簿
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(Sheetname);

            // 写入标题行
            IRow headerRow = sheet.CreateRow(0);
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(dataGridView.Columns[i].HeaderText);
            }

            // 写入数据行
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                IRow dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    ICell cell = dataRow.CreateCell(j);
                    var value = dataGridView.Rows[i].Cells[j].Value;
                    if (value != null)
                    {
                        cell.SetCellValue(value.ToString());
                    }
                }
            }

            // 自动调整列宽
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            // 保存 Excel 文件
            string filePath = Path.Combine(Application.StartupPath, filename + ".xlsx");
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
            MessageBox.Show($"导出成功！文件路径：{filePath}");
        }
    }
    public class SystemInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int Times { get; set; }
        public int Admin { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Inventory { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
    public class Bank
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string InOrOut { get; set; }
        public int Quantity { get; set; }
        public string DayDate { get; set; }
        public string DoDateTime { get; set; }
        public int WhoId { get; set; }
        public int Remaining { get; set; }
        public decimal RemainingMoney { get; set; }
    }
    public class BankInfo
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string InOrOut { get; set; }
        public int Quantity { get; set; }
        public string DayDate { get; set; }
        public string DoDateTime { get; set; }
        public int Inventory { get; set; }
        public string Who { get; set; }
        public int WhoId { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Remaining { get; set; }
        public decimal RemainingMoney { get; set; }
    }
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Inventory { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }

    public class DataFactory
    {
        public static IEnumerable<SystemInfo> SystemInfoRepository(string sql= "select * from SystemInfo order by Id")
        {
            return WMSDateHelp.Query<SystemInfo>(sql);
        }
        public static IEnumerable<Users> UsersRepository(string sql="select * from Users order by Id")
        {
            return WMSDateHelp.Query<Users>(sql);
        }
        public static IEnumerable<Category> CategoryRepository(string sql="select * from Category order by Id")
        {
            return WMSDateHelp.Query<Category>(sql);
        }
        public static IEnumerable<Product> ProductRepository(string sql="select * from Product order by Id")
        {
            return WMSDateHelp.Query<Product>(sql);
        }
        public static IEnumerable<ProductInfo> ProductInfoRepository(string sql="select * from ProductInfo order by Id")
        {
            return WMSDateHelp.Query<ProductInfo>(sql);
        }
        public static IEnumerable<BankInfo> BankInfoRepository(string sql="select * from BankInfo order by Id")
        {
            return WMSDateHelp.Query<BankInfo>(sql);
        }
    }
}
