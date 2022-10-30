﻿using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(categoryDto);
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetByIdAsync(id);
            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(categoryDto);
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetByIdAsync(id);
            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _categoryService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetByIdAsync(id);
            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }
    }
}
