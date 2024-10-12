﻿using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "IT,Supervisor,Dietitian")]
    public class CustomerController : CRUDController<Customer>
    {
        public CustomerController(ICustomerLogic logic) : base(logic)
        {
        }
    }
}