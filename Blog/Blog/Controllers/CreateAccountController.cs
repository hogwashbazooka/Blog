﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
  public class CreateAccountController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
