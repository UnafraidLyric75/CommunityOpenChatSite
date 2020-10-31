using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityOpenChatSite.Models
{
    /// <summary>
    /// A genaric text forum
    /// </summary>
    public class TextForum
    {
        [Key]
        public int TextForumId { get; set; }

        public string ForumName { get; set; }

        public string ForumDescription { get; set; }
    }

    /// <summary>
    /// A picture forum
    /// </summary>
    public class PictureForum : TextForum
    {
        /// <summary>
        /// Embed code for photo
        /// </summary>
        public string EmbedCode { get; set; }
    }
}
