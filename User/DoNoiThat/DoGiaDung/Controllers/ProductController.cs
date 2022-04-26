using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoGiaDung.Models;
using PagedList;
using PagedList.Mvc;

namespace DoGiaDung.Controllers
{
    public class ProductController : Controller
    {
        DBGiaDungEntities db = new DBGiaDungEntities();
        // GET: Product
       
        public ActionResult Index(string catalog, int? page,string searchstring)
        {

            int pageSize = 9;
            int pageNum = (page ?? 1);
            if (searchstring != null)
            {
                var z =db.PRODUCTs.Where(s => s.product_name.Contains(searchstring)).ToList();
                return View(z.ToPagedList(pageNum, pageSize));
            }
            if (catalog == null)
            {
                var list = db.PRODUCTs.Include("CATALOG").Where(s => s.quantity > 0).ToList();
                return View(list.ToPagedList(pageNum,pageSize));
            }
            else
            {
                var l = db.PRODUCTs.Include("CATALOG").Where(x => x.CATALOG.catalog_name == catalog).ToList();
                return View(l.ToPagedList(pageNum,pageSize));
            }
            
        }
        public ActionResult SearchGia(int? page, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 9;
            int pageNum = (page ?? 1);
            var s = db.PRODUCTs.Where(p => (double)p.price >= min && (double)p.price <= max).ToList();
            return View(s.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Product_Detail(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(db.PRODUCTs.Include("CATALOG").Where(x => x.product_id == id).FirstOrDefault());
        }
        public PartialViewResult CatalogPartial()
        {
            var catalist = db.CATALOGs.ToList();
            return PartialView(catalist);
        }
        public PartialViewResult TagPartial() 
        {
            var taglist = db.TAGs.ToList();
            return PartialView(taglist);
        }
    }
}