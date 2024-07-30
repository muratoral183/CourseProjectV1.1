using CourseProject.Areas.Identity.Pages.Account.Manage;
using CourseProject.DAL.Context;
using CourseProject.DAL.Entity;
using CourseProject.Models;
using CourseProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Razor;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _contex;
        private readonly UserManager<UserInfo> _userManager;
        private readonly IServiceProvider _serviceProvider;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<UserInfo> userManager, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _contex = context;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
        }



        public IActionResult Index()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            var viewModel = new HomePageViewModel
            {
                Carousel = _contex.Carousel.ToList(),
                Category = _contex.Category.OrderBy(row => row.Status).ToList(),

                CustomBanner = _contex.CustomBanner.ToList(),
                Feedback = _contex.Feedback.ToList(),
                Product = _contex.Product.ToList()
            };
            return View(viewModel);
        }

        public IActionResult CollectionList(int CategoryType)
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            int categoryType = CategoryType;
            List<int> categoryIds = new List<int>();
            if (CategoryType == 1)
            {
                categoryIds.Add(1);
            }

            if (CategoryType == 2)
            {
                categoryIds.Add(2);
                categoryIds.Add(3);
                categoryIds.Add(5);
                categoryIds.Add(6);


            }


            if (CategoryType == 3)
            {
                categoryIds.Add(1);
                categoryIds.Add(2);
                categoryIds.Add(3);
                categoryIds.Add(5);
                categoryIds.Add(6);


            }
            ViewBag.TxtCategoryType = CategoryType;
            IQueryable<Product> productQuery = _contex.Product.Where(row => categoryIds.Contains(row.IsProductType));


            var viewModel = new HomePageViewModel
            {
                Carousel = _contex.Carousel.ToList(),
                Category = _contex.Category.OrderBy(row => row.Status).ToList(),
                CategoryList = categoryIds.Count > 0
                        ? _contex.Category
                            .Where(c => categoryIds.Contains(c.IsProductType))
                            .Select(c => new Category
                            {
                                Id = c.Id,
                                CategoryName = c.CategoryName,
                                CategoryUrl = c.CategoryUrl,
                                IsProductType = c.IsProductType,
                                Status = c.Status,
                                AmbSayisi = _contex.Product.Count(p => categoryIds.Contains(p.IsProductType))
                            })
                            .OrderBy(c => c.Status)
                            .ToList()
                        : new List<Category>(),

                CustomBanner = _contex.CustomBanner.ToList(),
                Feedback = _contex.Feedback.ToList(),
                Product = (CategoryType == 3)
                ? _contex.Product.Where(row => categoryIds.Contains(row.IsProductType)).Where(row => row.IsStandOut == true).ToList()
                : _contex.Product.Where(row => categoryIds.Contains(row.IsProductType)).ToList(),
                ProductCount = categoryIds.Count > 0
                        ? _contex.Product.Count(row => categoryIds.Contains(row.IsProductType))
                        : 0
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CollectionList(int CategoryType, HomePageViewModel homePageViewModel)
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            int categoryType = CategoryType;

            ViewBag.TxtCategoryType = CategoryType;

            List<int> categoryIds = new List<int>();

            if (CategoryType == 1)
            {
                categoryIds.Add(1);
            }

            if (CategoryType == 2)
            {
                categoryIds.Add(2);
                categoryIds.Add(3);
                categoryIds.Add(5);
                categoryIds.Add(6);


            }


            if (CategoryType == 3)
            {
                categoryIds.Add(1);
                categoryIds.Add(2);
                categoryIds.Add(3);
                categoryIds.Add(5);
                categoryIds.Add(6);


            }





            IQueryable<Product> productQuery = _contex.Product.Where(row => categoryIds.Contains(row.IsProductType));

            if (homePageViewModel.MinPrice.HasValue)
            {
                productQuery = productQuery.Where(row => row.Price >= homePageViewModel.MinPrice.Value);
            }

            if (homePageViewModel.MaxPrice.HasValue)
            {
                productQuery = productQuery.Where(row => row.Price <= homePageViewModel.MaxPrice.Value);
            }


            if (CategoryType == 3)
            {
                productQuery = productQuery.Where(row => row.IsStandOut == true);
            }





            var viewModel = new HomePageViewModel
            {
                Carousel = _contex.Carousel.ToList(),
                Category = _contex.Category.OrderBy(row => row.Status).ToList(),
                CategoryList = categoryIds.Count > 0
        ? _contex.Category
            .Where(c => categoryIds.Contains(c.IsProductType))
            .Select(c => new Category
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                CategoryUrl = c.CategoryUrl,
                IsProductType = c.IsProductType,
                Status = c.Status,
                AmbSayisi = _contex.Product.Count(p => categoryIds.Contains(p.IsProductType))
            })
            .OrderBy(c => c.Status)
            .ToList()
        : new List<Category>(),
                CustomBanner = _contex.CustomBanner.ToList(),
                Feedback = _contex.Feedback.ToList(),
                Product = productQuery.ToList(),
                ProductCount = productQuery.Count()
            };
            return View(viewModel);
        }
        public IActionResult AddBasket()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            return View();
        }

        public IActionResult ProductCheck()
        {
            ViewBag.CountryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Select a country" },
                new SelectListItem { Value = "1", Text = "Türkiye" },

            };
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            return View();
        }

        [HttpPost]
        public IActionResult ProductCheck(OrdersViewModel ordersViewModel)
        {
            // Rastgele 11 haneli bir sayý üret
            //Random random = new Random();
            //string? randomNumber = Convert.ToString((long)(random.NextDouble() * 1_000_000_000_00L));
            string? resultRandomNumber = HttpContext.Session.GetString("OrderNum");

            // Oturumdan login durumunu al
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;

            // Sipariþ detaylarýna sipariþ numarasýný atama ve veritabanýna kaydetme
            ordersViewModel.ordersDetail.OrderNum = "1";
            _contex.OrdersDetail.Add(ordersViewModel.ordersDetail);
            _contex.SaveChanges();

            return RedirectToAction("OrderComplete", "Home", new { data = resultRandomNumber });
        }

        [HttpPost]
        public IActionResult SubmitOrder([FromBody] List<OrdersItems> ordersItems, [FromQuery] string data)
        {
            // Rastgele 11 haneli bir sayý üret
            Random random = new Random();
            string? randomNumber = Convert.ToString((long)(random.NextDouble() * 1_000_000_000_00L));
            double subTotal = 0.00;

            HttpContext.Session.SetString("OrderNum", randomNumber);
            TempData["randSayi"] = randomNumber;
            ViewBag.ReceivedData = data;

            // Oturumdan login durumunu al
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;

            foreach (var item in ordersItems)
            {
                item.OrderNum = randomNumber;
                item.TotalPrice = item.Price * item.Quantity;
                subTotal += item.TotalPrice;
            }

            _contex.OrdersItems.AddRange(ordersItems);
            _contex.SaveChanges();

            return Json(new { success = true });
        }



        public IActionResult DeleteBasket()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            return View();
        }


        public IActionResult OrderComplete()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;

            var lastOrdernum = _contex.OrdersItems
                              .OrderByDescending(row => row.OrdersItemsId)
                              .Select(row => row.OrderNum)
                              .FirstOrDefault();
            var ordList = _contex.OrdersDetail.OrderByDescending(row => row.OrdersDetailId).FirstOrDefault(); ;
            var ordersViewModel = new OrdersViewModel
            {
                lastOrdernum = lastOrdernum,
                OrdersItems = _contex.OrdersItems.Where(row => row.OrderNum == lastOrdernum).ToList(),
                ordersDetail = ordList
            };
            return View(ordersViewModel);
        }

        public IActionResult PackingInfo()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            return View();
        }
        public IActionResult Privacy()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            return View();
        }

        public IActionResult Profile()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            string? emailAddress = HttpContext.Session.GetString("inputEmail");
            ViewBag.loginFlag = loginStatus;
            UserInfo usersInfo = _contex.UserInfo.FirstOrDefault(row => row.Email == emailAddress);
            return View(usersInfo);
        }
        [HttpPost]
        public IActionResult Profile(int id, UserInfo userInfo)
        {

            var user = HttpContext.Session.GetString("inputEmail");
            var userInfoData = _contex.Users.FirstOrDefault(u => u.Email == user);
            userInfoData.FirstName = userInfo.FirstName;
            userInfoData.LastName = userInfo.LastName;
            userInfoData.PhoneNumber = userInfo.PhoneNumber;
            _contex.Update(userInfoData);
            _contex.SaveChanges();
            return View();
        }

        public IActionResult ProfileOrders()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            ViewBag.profileStatus = 1;

            var profileOrderList = _contex.OrdersItems
                .GroupBy(oi => oi.OrderNum)
                .Select(g => new OrdersViewModel
                {
                    OrderNum = g.Key,
                    Total =(decimal) g.Sum(oi => oi.Price * oi.Quantity)
                })
                .ToList();

            return View(profileOrderList);
        }

        public IActionResult ProfileInfo()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            ViewBag.profileStatus = 2;
            return View();
        }

        public IActionResult ProfileAddress()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            ViewBag.profileStatus = 3;
            return View();
        }
        public IActionResult ProfilePassword()
        {
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            ViewBag.profileStatus = 4;
            var user = HttpContext.Session.GetString("inputEmail");
            UserInfo userInfo = _contex.UserInfo.FirstOrDefault(row => row.Email == user);
            return View(userInfo);
        }


        public IActionResult Logout()
        {

            HttpContext.Session.SetInt32("logValue", 0);
            int? loginStatus = HttpContext.Session.GetInt32("logValue");
            ViewBag.loginFlag = loginStatus;
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
