using System.Linq;
using System.Web.Mvc;
using thu_project2_cnt1.Data; // Thay bằng namespace của dự án bạn
using thu_project2_cnt1.Models; // Thay bằng namespace của dự án bạn

namespace thu_project2_cnt1.Controllers
{
    [Authorize] // Đảm bảo rằng chỉ admin mới có thể truy cập
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // Danh sách sản phẩm
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Thêm sản phẩm mới
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Sửa sản phẩm
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return HttpNotFound();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Xóa sản phẩm
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return HttpNotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
