using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityOpenChatSite.Data;
using CommunityOpenChatSite.Models;
using eCommerceSite.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunityOpenChatSite.Controllers
{
    public class ForumController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays a view that lists a page of forums
        /// </summary>
        public async Task<IActionResult> Index(int? id)
        {
            int pageNum = id ?? 1;
            const int PageSize = 30;
            ViewData["CurrentPage"] = pageNum;

            int numForums = await ForumDB.GetTotalForumsAsync(_context);
            int totalPages = (int)Math.Ceiling((double)numForums / PageSize);
            ViewData["MaxPage"] = totalPages;

            List<TextForum> PhotoPosts = await ForumDB.GetForumsAsync(_context, PageSize, pageNum);

            return View(PhotoPosts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TextForum f)
        {
            if (ModelState.IsValid)
            {
                f = await ForumDB.AddForumAsync(_context, f);

                TempData["Message"] = $"{f.ForumName} was added successfully";

                // redirect back to catalog page
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Get product with corresponding id
            TextForum f = await ForumDB.AddForumAsync(_context, id);

            // pass product to view
            return View(f);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TextForum f)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(f).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                ViewData["Message"] = "Product updated successfully";
            }

            return View(f);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            TextForum f = await ForumDB.AddForumAsync(_context, id);

            return View(f);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TextForum f = await ForumDB.AddForumAsync(_context, id);

            _context.Entry(f).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            TempData["Message"] = $"{f.ForumName} was deleted";

            return RedirectToAction("Index");
        }
    }
}