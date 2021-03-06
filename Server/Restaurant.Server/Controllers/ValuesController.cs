﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Server.Api.Abstractions.Providers;
using Restaurant.Server.Api.Models;

namespace Restaurant.Server.Api.Controllers
{
	[Route("api/[controller]")]
	[AllowAnonymous]
	public class ValuesController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IUserBootstrapper _userBootsrapper;

		public ValuesController(
			UserManager<User> userManager,
			RoleManager<IdentityRole> roleManager,
			IUserBootstrapper userBootsrapper)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_userBootsrapper = userBootsrapper;
		}
		// GET api/values
		[HttpGet]
		[Authorize(Roles = "Member")]
		public IEnumerable<string> Get()
		{
			//var user = _userManager.GetUserAsync(User).Result;

			//var result =_userManager.IsInRoleAsync(user, "Admin").Result;

			return new string[] { "value1", "value2" };
		}


		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		[HttpGet]
		[Route("CreateUsersAndRoles")]
		public async Task CreateUsersAndRoles()
		{
			await _userBootsrapper.CreateDefaultUsersAndRoles();
		}
	}
}
