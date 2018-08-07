using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Xml.Linq;
using System.Drawing;
using System.Resources;
using System.Web.Mvc;
using Kibrisorder_Email_generator.Models;
namespace Kibrisorder_Email_generator.Controllers
{
    public class EmailGeneratorController : Controller
    {
        // GET: EmailGenerator
        public ActionResult Index()
        {
           

                ViewBag.section_header_text = Resources.product_recommendation_data_supermarket. section_header_text;
            ViewBag.section_header_main_text = Resources.product_recommendation_data_supermarket. section_header_main_text;

            ViewBag.product_1_image_url = Resources.product_recommendation_data_supermarket. product_1_image_url;
            ViewBag.product_1_product_name = Resources.product_recommendation_data_supermarket. product_1_product_name;
            ViewBag.product_1_price = Resources.product_recommendation_data_supermarket. product_1_price;
            ViewBag.product_1_currency_symbol = Resources.product_recommendation_data_supermarket. product_1_currency_symbol;
            ViewBag.product_1_buy_now_link = Resources.product_recommendation_data_supermarket. product_1_buy_now_link;

            ViewBag.product_2_image_url = Resources.product_recommendation_data_supermarket. product_2_image_url;
            ViewBag.product_2_product_name = Resources.product_recommendation_data_supermarket. product_2_product_name;
            ViewBag.product_2_price = Resources.product_recommendation_data_supermarket. product_2_price;
            ViewBag.product_2_currency_symbol = Resources.product_recommendation_data_supermarket. product_2_currency_symbol;
            ViewBag.product_2_buy_now_link = Resources.product_recommendation_data_supermarket. product_2_buy_now_link;

            ViewBag.product_3_image_url = Resources.product_recommendation_data_supermarket. product_3_image_url;
            ViewBag.product_3_product_name = Resources.product_recommendation_data_supermarket. product_3_product_name;
            ViewBag.product_3_price = Resources.product_recommendation_data_supermarket. product_3_price;
            ViewBag.product_3_currency_symbol = Resources.product_recommendation_data_supermarket. product_3_currency_symbol;
            ViewBag.product_3_buy_now_link = Resources.product_recommendation_data_supermarket. product_3_buy_now_link;

            ViewBag.product_4_image_url = Resources.product_recommendation_data_supermarket. product_4_image_url;
            ViewBag.product_4_product_name = Resources.product_recommendation_data_supermarket. product_4_product_name;
            ViewBag.product_4_price = Resources.product_recommendation_data_supermarket. product_4_price;
            ViewBag.product_4_currency_symbol = Resources.product_recommendation_data_supermarket. product_4_currency_symbol;
            ViewBag.product_4_buy_now_link = Resources.product_recommendation_data_supermarket. product_4_buy_now_link;

            ViewBag.product_5_image_url = Resources.product_recommendation_data_supermarket. product_5_image_url;
            ViewBag.product_5_product_name = Resources.product_recommendation_data_supermarket. product_5_product_name;
            ViewBag.product_5_price = Resources.product_recommendation_data_supermarket. product_5_price;
            ViewBag.product_5_currency_symbol = Resources.product_recommendation_data_supermarket. product_5_currency_symbol;
            ViewBag.product_5_buy_now_link = Resources.product_recommendation_data_supermarket. product_5_buy_now_link;

            ViewBag.product_6_image_url = Resources.product_recommendation_data_supermarket. product_6_image_url;
            ViewBag.product_6_product_name = Resources.product_recommendation_data_supermarket. product_6_product_name;
            ViewBag.product_6_price = Resources.product_recommendation_data_supermarket. product_6_price;
            ViewBag.product_6_currency_symbol = Resources.product_recommendation_data_supermarket. product_6_currency_symbol;
            ViewBag.product_6_buy_now_link = Resources.product_recommendation_data_supermarket. product_6_buy_now_link;

            ViewBag.shared_buy_now_button = Resources.product_recommendation_data_supermarket.shared_buy_now_button;

            String xmlDocPath = Server.MapPath("~/Content/recommended_products.xml"); 

            XDocument xdoc = XDocument.Load(xmlDocPath);
            productXMLinterface context = new productXMLinterface(xdoc, xmlDocPath);


            List<Product> products = new List<Product>();
            products = context.GetAllProducts();

           
        
            return View("View", products);
        }
    }
}