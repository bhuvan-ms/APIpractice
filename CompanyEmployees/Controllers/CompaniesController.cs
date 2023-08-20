﻿using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public CompaniesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var comapnies = _repository.Company.GetAllCompanies(trackChanges: false);
                return Ok(comapnies);
            }
            catch (System.Exception ex)
            {

               _logger.LogError($"Something went wrong in the {nameof(GetCompanies)}action {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}