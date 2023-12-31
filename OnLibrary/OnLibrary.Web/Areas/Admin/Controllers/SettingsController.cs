﻿using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLibrary.Web.Areas.Admin.Models.Roles;

namespace OnLibrary.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class SettingsController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILifetimeScope scope, ILogger<SettingsController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Roles()
        {
            var model = _scope.Resolve<ViewRoleModel>();

            return View(model);
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole()
        {
            var model = _scope.Resolve<CreateRoleModel>();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                await model.CreateRole();
            }

            return RedirectToAction(nameof(Roles));
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole()
        {
            var model = _scope.Resolve<AssignRoleModel>();

            await model.LoadData();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(AssignRoleModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                await model.AssignRole();
            }

            return RedirectToAction(nameof(Roles));
        }
    }
}
