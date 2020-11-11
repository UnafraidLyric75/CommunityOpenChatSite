using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityOpenChatSite.Data;
using CommunityOpenChatSite.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Data
{
    public static class ForumDB
    {
        /// <summary>
        /// Reuturns the total count of products
        /// </summary>
        /// <param name="_context">Database context</param>
        public async static Task<int> GetTotalForumsAsync(ApplicationDbContext _context)
        {
            return await (from f in _context.PhotoPosts
                          select f).CountAsync();
        }

        /// <summary>
        /// Get page worth of products
        /// </summary>
        /// <param name="_context">Database context</param>
        /// <param name="pageSize">num of products per page</param>
        /// <param name="pageNum">Page of products to return</param>
        /// <returns></returns>
        public async static Task<List<PictureForum>> GetForumsAsync(ApplicationDbContext _context, int pageSize, int pageNum)
        {
            return await (from f in _context.PhotoPosts
                          orderby f.ForumName ascending
                          select f)
                       .Skip(pageSize * (pageNum - 1))
                       .Take(pageSize)
                       .ToListAsync();
        }

        /// <summary>
        /// Adds products to database
        /// </summary>
        /// <param name="_context">Database context</param>
        /// <param name="p">is the product being added</param>
        /// <returns></returns>
        public async static Task<PictureForum> AddForumAsync(ApplicationDbContext _context, PictureForum f)
        {
            _context.PhotoPosts.Add(f);
            await _context.SaveChangesAsync();
            return f;
        }

        public static async Task<PictureForum> GetForumAsync(ApplicationDbContext context, int prodid)
        {
            PictureForum f = await (from PhotoPosts in context.PhotoPosts
                               where PhotoPosts.TextForumId == prodid
                               select PhotoPosts).SingleAsync();

            return f;
        }
    }
}
