using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.ApplicationCore.Interfaces.Services;
using TBCInsiders.Management.Web.Models;

namespace TBCInsiders.Management.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;
        public UsersController(IUnitOfWork uow, IUserService userService)
        {
            _uow = uow;
            _userService = userService;
        }
        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _userService.GetUserDetailsAsync(id);

            return View(result);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
