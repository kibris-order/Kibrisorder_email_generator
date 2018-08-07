using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Kibrisorder_Email_generator.Models
{
    public class productXMLinterface
    {
        public productXMLinterface(XDocument xdoc, String pathToXMLfile)
        {
            this.xdoc = xdoc;
            this.pathToXMLfile = pathToXMLfile;

        }
        public String pathToXMLfile { get; set; }
        public  XDocument xdoc { get; set; }


        public void removeAllProducts()
        {
            xdoc.Root.Elements().Remove();
            xdoc.Save(pathToXMLfile);
        }

        public void removeProduct(String id)
        {
            xdoc.Root.Elements().Where(x => x.Attribute("id").Value == id).FirstOrDefault().Remove();
            xdoc.Save(pathToXMLfile);
        }



        public void updatingPrice(String id, double price)
        {
            xdoc.Element("products")
                .Elements("product")
                .Where(x => x.Attribute("id").Value == id).FirstOrDefault().SetElementValue("price", price);
            xdoc.Save(pathToXMLfile);
        }

        public void updatingCurrency(String id, String currency)
        {
            xdoc.Element("products")
                .Elements("product")
                .Where(x => x.Attribute("id").Value == id).FirstOrDefault().Element("price").SetAttributeValue("currency", currency);
            xdoc.Save(pathToXMLfile);
        }


        public void updatingName(String id,String name)
        {
            xdoc.Element("products")
                .Elements("product")
                .Where(x => x.Attribute("id").Value == id).FirstOrDefault().SetElementValue("name", name);
            xdoc.Save(pathToXMLfile);
        }

        public void updatingImgUrl(String id, String img_url)
        {
            xdoc.Element("products")
                .Elements("product")
                .Where(x => x.Attribute("id").Value == id).FirstOrDefault().SetElementValue("img_url", img_url);
            xdoc.Save(pathToXMLfile);
        }

        public void updatingProductUrl(String id, String product_url)
        {
            xdoc.Element("products")
                .Elements("product")
                .Where(x => x.Attribute("id").Value == id).FirstOrDefault().SetElementValue("buy_now_url", product_url);
            xdoc.Save(pathToXMLfile);
        }

        public void AddNewProduct(Product product)
        {
            xdoc.Element("products").Add(
                new XElement("product", new XAttribute("id", product.id),
               new XElement("name", product.name),
               new XElement("img_url", product.img_url),
               new XElement("buy_now_url", product.product_url),

                new XElement("price", new XAttribute("currency", product.currency), product.price)
                ));
            xdoc.Save(pathToXMLfile);
        }



        public List<Product> GetAllProducts()
        {
            List<Product> Products = new List<Product>();
            Product product = new Product();
            xdoc.Descendants("product").Select(p => new
            {
                id = p.Attribute("id").Value,
                name = p.Element("name").Value,
                price = p.Element("price").Value,
                currency = p.Element("price").Attribute("currency").Value,
                img_url = p.Element("img_url").Value,
                product_url = p.Element("buy_now_url").Value
            }).ToList().ForEach(p =>
            {
                product = new Product();
                product.id =p.id;
                product.name=  p.name;
                product.price= p.price;
                product.currency= p.currency;
                product.img_url = p.img_url;
                product.product_url = p.product_url;

                Products.Add(product);
                
            });

            return Products;
        }

        public  Product GetProduct(String id)
        {
            Product product = new Product();
            xdoc.Descendants("product").Where(p=> p.Attribute("id").Value == id)
                .Select(p => new
                {
                    id = p.Attribute("id").Value,
                    name = p.Element("name").Value,
                    price = p.Element("price").Value,
                    currency = p.Element("price").Attribute("currency").Value,
                    img_url = p.Element("img_url").Value,
                    product_url = p.Element("buy_now_url").Value
                }).ToList().ForEach(p =>
                {
                  
                    product.id = p.id;
                    product.name = p.name;
                    product.price = p.price;
                    product.currency = p.currency;
                    product.img_url = p.img_url;
                    product.product_url = p.product_url;
                    

                });
            return product;

        }
    }


}