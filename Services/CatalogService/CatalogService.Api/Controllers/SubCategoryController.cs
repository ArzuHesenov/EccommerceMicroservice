﻿using CatalogService.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CatalogService.Entities.DTOs.SubCategoryDTO;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var subcategories = _subCategoryService.GetAllSubCategories();

            if (!subcategories.Success)
            {
                return BadRequest(subcategories.Message);
            }
            return Ok(subcategories);
        }

        [HttpPost("add")]
        public IActionResult Add(SubCategoryAddDTO subCategory)
        {
            var newSubcategory = _subCategoryService.Add(subCategory);
            if (!newSubcategory.Success)
            {
                return BadRequest(newSubcategory.Message);
            }
            return Ok(newSubcategory.Message);
        }
    }
}