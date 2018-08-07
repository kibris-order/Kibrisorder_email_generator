using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.Linq;
using Kibrisorder_Email_generator.Models;

namespace Kibrisorder_Email_generator.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index(String product_id)
        {
            String xmlDocPath = Server.MapPath("~/Content/recommended_products.xml");

            XDocument xdoc = XDocument.Load(xmlDocPath);
            productXMLinterface context = new productXMLinterface(xdoc, xmlDocPath);
            Product product = new Product();
            product = context.GetProduct(product_id);
            return View("Index", product);
        }

        public void UpdateProduct(Product mProduct)
        {
            String xmlDocPath = Server.MapPath("~/Content/recommended_products.xml");

            XDocument xdoc = XDocument.Load(xmlDocPath);
            productXMLinterface context = new productXMLinterface(xdoc, xmlDocPath);
            Product product = new Product();
            product = mProduct;

            context.updateAllFields(product);
        }
    }
}