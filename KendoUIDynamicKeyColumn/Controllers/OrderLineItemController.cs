using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoUIDynamicKeyColumn.Controllers;
using KendoUIDynamicKeyColumn.Models;


namespace KendoUIDynamicKeyColumn.Controllers
{
    public class OrderLineItemController : Controller
    {
        NorthwindEntities dataEntities = new NorthwindEntities();
        public ActionResult Index()
        {
            PopulateProducts();
            PopulateShippers();
            return View();
        }


        public ActionResult OrdersRead([DataSourceRequest] DataSourceRequest request)
        {
            var data = new List<OrderLineItem>();

            foreach (OrderLineItem orderLineItem in dataEntities.OrderLineItems)
            {
                data.Add(new OrderLineItem()
                {
                    OrderLineItemID = orderLineItem.OrderLineItemID,
                    ProductID = orderLineItem.ProductID,
                    ShipperID = orderLineItem.ShipperID
                });
            }

            return Json(data.ToDataSourceResult(request));
        }
        private void PopulateProducts()
        {
            ViewData["AllProducts"] = dataEntities.Products.ToList();
        }
        private void PopulateShippers()
        {
            ViewData["AllShippers"] = dataEntities.Shippers.ToList();
        }

        public ActionResult ValidShippersRead(int ProductID)
        {

            // Return the filtered list of shippers, based on the ProductID
           
            var productShippers = dataEntities.ProductShippers.ToList();
            var allshippers = dataEntities.Shippers.ToList();

            var shippers = (from ps in productShippers
                            join s in allshippers
                                on ps.ShipperID equals s.ShipperID
                            where ps.ProductID == ProductID
                            select new Shipper() { ShipperID = s.ShipperID, CompanyName = s.CompanyName})
                            .Distinct()
                            .ToList();

            return Json(shippers, JsonRequestBehavior.AllowGet);
        }

    }
}
