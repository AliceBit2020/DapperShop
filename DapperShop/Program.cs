
using Dapper;
using Microsoft.Data.SqlClient;
using DapperShop.Model;
using Z.Dapper.Plus;



namespace DapperShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-O6DMGPJ\\SQLEXPRESS;Database=DapperShop;TrustServerCertificate=true;Trusted_Connection=True;";

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            //  Console.WriteLine(" Товари ");

            //  // 1. SELECT — отримати всі товари разом із категоріями


            //var sql1 = @"SELECT p.Id, p.Name, p.Price, c.Name AS CategoryName FROM Products p JOIN Categories c ON p.CategoryId = c.Id";

            //var products = connection.Query(sql1);///<dynamic> з полями Id, Name, Price, CategoryName 

            //foreach (var p in products)
            //{

            //    Console.WriteLine($"ProductId:{p.Id} Product: {p.Name} ProductPrice: {p.Price} CategoryName: ({p.CategoryName})");

            //}



            /////////////////////////////////////////////////
            ///Error!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //var sql1 = @"SELECT p.Id, p.Name, p.Price, c.Name AS Category FROM Products p JOIN Categories c ON p.CategoryId = c.Id";///<dynamic> з полями Id, Name, Price, CategoryName 

            //List<Product> products = connection.Query<Product>(sql1).ToList();

            //foreach (var p in products)
            //{
            //    Console.WriteLine($"{p.Id}: {p.Name} - {p.Price} ({p.Category.Name})");
            //}


            ////////////////////////////////////////////////
            ///

            //var sql1 = @"SELECT  p.Id, p.Name, p.CategoryId, c.Id,  FROM Products p JOIN Categories c ON p.CategoryId = c.Id";

            //var products = connection.Query<Product, Category, Product>(
            //    sql1,
            //    (product, category) =>
            //    {
            //        product.Category = category;
            //        return product;
            //    },
            //    splitOn: "id"
            //).ToList();

            //foreach (var pr in products)
            //{
            //    Console.WriteLine($"Product: {pr.Name,-20}, Category: {pr.Category.Name,-20} Price: {pr.Price,-10} CategoryId: {pr.CategoryId,-10} CategoryId2:{pr.Category.Id,-10}  ");
            //}



            //  Console.WriteLine("\nДодавання товару ");

            //  // 2. INSERT — додати новий товар


            //var insertSql = "INSERT INTO Products (Name, Price, CategoryId) VALUES (@Name, @Price, @CategoryId)";
            //connection.Execute(insertSql, new { @Name = "Mouse", @Price = 25.50, @CategoryId = 1 });





            //  // 3. UPDATE — оновити ціну товару
            //var updateSql = "UPDATE Products SET Price = @Price WHERE Name = @Name";
            //connection.Execute(updateSql, new { @Price = 27.99, @Name = "Mouse" });

            //  Console.WriteLine("Ціну оновлено");

            //  Console.WriteLine("\n Видалення товару ");

            //  // 4. DELETE — видалити товар
            //var deleteSql = "DELETE FROM Products WHERE Name = @Name";
            //connection.Execute(deleteSql, new { @Name = "Mouse" });

            //////dynamic type

            //  Console.WriteLine("\nЗамовлення з товарами ");

            //  // 5. JOIN: отримати всі замовлення з покупцями та товарами
            //var sqlOrders = @"SELECT o.Id AS OrderId, o.OrderDate, c.FullName, pr.Name AS Product, op.Quantity FROM Orders o JOIN Customers c ON o.CustomerId = c.Id JOIN OrderProducts op ON o.Id = op.OrderId JOIN Products pr ON op.ProductId = pr.Id ORDER BY o.Id";

            //var orders = connection.Query(sqlOrders);

            //foreach (var o in orders)
            //{
            //    Console.WriteLine($"Замовлення {o.OrderId} від {o.FullName} ({o.OrderDate}): {o.Product} x{o.Quantity}");
            //}

            ///6. 
            //var sql = "SELECT COUNT(*) FROM Products";
            //var count = connection.ExecuteScalar(sql);
            //Console.WriteLine($"Total products: {count}");

            //connection.Close();

            //7.
            // sql = "SELECT * FROM Products WHERE Id = @productID";
            //var product = connection.QuerySingle(sql, new { @productID = 1 });
            //Console.WriteLine($"ProductID: {product.Id}; Name: {product.Name}");

            //8.
            //var sql = "SELECT * FROM Products WHERE Id = @productID";
            //Product product_ = connection.QuerySingle<Product>(sql, new { @productID = 1 });
            //Console.WriteLine($"ProductID: {product_.Id}; Name: {product_.Name}");


            ///9.

            //var products = new List<Product>{
            //new Product { Name = "Tablet", Price = 299.99M, CategoryId = 1 },
            //new Product { Name = "E-Reader", Price = 129.99M, CategoryId = 2 },
            //new Product { Name = "Sneakers", Price = 89.99M, CategoryId = 3 }
            // };


            //object value = connection.BulkInsert(products);

            //10

        //    var productsToDelete = connection.Query<Product>(
        //"SELECT * FROM Products WHERE Price < 20").ToList();

        //    connection.BulkDelete(productsToDelete);

            //11  

            var produc = connection.Query<Product>("SELECT * FROM Products").ToList();
            produc.ForEach(p => p.Price *= 1.1M); // підвищення ціни на 10%
            connection.BulkUpdate(produc);

            ////1.ДЗ Підвищит ціну продукту який має найменшу кількість продажів
            ///
            /// 2.  1ДЗ  в процедурі
            /// 3. Тригери на видалення об'єктів таблиць: видалені об'єкти переносяться в таблицю видалених об'єктів

            connection.Close();



        }
    }
}
