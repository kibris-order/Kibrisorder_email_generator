using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.Linq;
using Kibrisorder_Email_generator.Models;

namespace Kibrisorder_Email_generator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            String xmlDocPath = Server.MapPath("~/Content/recommended_products.xml");

            XDocument xdoc = XDocument.Load(xmlDocPath);
            productXMLinterface context = new productXMLinterface(xdoc, xmlDocPath);
            List<Product> products = new List<Product>();

            products = context.GetAllProducts();
            return View("Index", products);
        }

        public void DeleteAll()
        {

            String xmlDocPath = Server.MapPath("~/Content/recommended_products.xml");

            XDocument xdoc = XDocument.Load(xmlDocPath);
            productXMLinterface context = new productXMLinterface(xdoc, xmlDocPath);
            context.removeAllProducts();
        }

        public void DeleteSpecificProduct(String id)
        {
            String xmlDocPath = Server.MapPath("~/Content/recommended_products.xml");

            XDocument xdoc = XDocument.Load(xmlDocPath);
            productXMLinterface context = new productXMLinterface(xdoc, xmlDocPath);
            context.removeProduct(id);

        }
    }
}