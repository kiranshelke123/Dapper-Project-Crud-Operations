using Dapper;
using Dapper_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dapper_Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        { 

            return View(DapperORM.ReturnList<ProductModel>("PeoductViewAll"));
        }
        //   ../Product/AddOrEdit  -insert
        //   ../Product/AddOrEdit/id
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0) {
                return View();
            }
            else {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@product_id", id);
               return View(DapperORM.ReturnList<ProductModel>("PeoductViewById",parameter).FirstOrDefault<ProductModel>());

            }
          
                 
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductModel pro)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@product_id",pro.Product_id);  
            param.Add("@product_name", pro.Product_Name);
            param.Add("@product_description", pro.Product_Description);
            param.Add("@created_at", pro.Create_dateTime);
            DapperORM.ExecuteWithoutReturn("ProductAddOrUpdate", param);
            

            // Redirect to Index or return a view with updated information
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) {
            DynamicParameters param = new DynamicParameters();
            param.Add("@product_id", id);
            DapperORM.ExecuteWithoutReturn("PeoductDeleteId", param);
            return RedirectToAction("Index");


        }

    }

}