using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //global değişkenler bu şekilde _
        public InMemoryProductDal()
        {     //veritabanlarından geliyormuş gibi simüle ediyor oracle,sql,mongoDb
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=15,UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=15,UnitsInStock=1},

            };

            ////AnyTest();
            ////FindAllTest();
            ////PriceFilter();
            ////ContainsK();
            ////ClassicLinqTest();

            //List<Category> categories = new List<Category>
            //{
            //    new Category{CategoryId=1, CategoryName="mutfak"},
            //    new Category{CategoryId=2, CategoryName="Telefon"},

            //};
            //var result = from p in _products
            //             join c in categories
            //             on p.CategoryId equals c.CategoryId
            //             where p.UnitPrice>50
            //             orderby p.UnitPrice
            //             select new ProductDto { ProductId = p.ProductId, CategoryName = c.CategoryName, UnitPrice = p.UnitPrice, ProductName = p.ProductName };
                         
            
            //foreach (var productDto in result)
            //{
            //    Console.WriteLine(productDto.ProductName+"--"+productDto.CategoryName);
            //}
                         

        }

        //private void ClassicLinqTest()
        //{
        //    var result = from p in _products
        //                 where p.UnitPrice > 50
        //                 orderby p.UnitPrice descending, p.ProductName ascending
        //                 select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice }; 
        //    foreach (var product in result)
        //    {
        //        Console.WriteLine(product.ProductName);

        //    }
        //}

        //private void ContainsK()
        //{
        //    var result2 = _products.Where(p => p.ProductName.Contains("K"));
        //    foreach (var product in result2)
        //    {

        //        Console.WriteLine("a" + product.ProductName);

        //    }
        //}

        //private void PriceFilter()
        //{
        //    var result = _products.Where(product => product.UnitPrice >= 500 && product.UnitsInStock > 1);
        //    foreach (var product in result)
        //    {
        //        Console.WriteLine(product.ProductName);

        //    }
        //}

        //private void FindAllTest()
        //{
        //    var result = _products.FindAll(p => p.ProductName.Contains("top"));
        //    Console.WriteLine(result);
        //}

        //private void AnyTest()
        //{
        //    var result = _products.Any(p => p.ProductName == "Bardak");
        //    Console.WriteLine(result);
        //}

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            // => lambda   SingleOrDefault(p=>) kodu foreach'in yaptığını yapar
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }

            //}
            //pnin oan dolaştığım ürünün id si benim parametreyle gönderdiğim ürünün idsine eşitse onun refaransını productToDelete e eşitle

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);//LINQ
            
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            Console.WriteLine("*********get all fonksiyonu*******");
            return _products;
            
        }



        public void Update(Product product) //Product product---> bu ekrandan gelen data.  
        {
            //  _products.Remove(product); referans tipi bööyle silemezsinNormalde bir listeden bir eleman byle silebiliyoruz.
           //gönderdiğim ürün id'sine sahip olan listedeki ürünü bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//LINQ
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;


        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            
            return _products.Where(p=>p.CategoryId==categoryId).ToList();

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
    //class ProductDto
    //{
    //    public int ProductId { get; set; }
    //    public string CategoryName { get; set; }
    //    public string ProductName { get; set; }
    //    public decimal UnitPrice { get; set; }
    //}
}
