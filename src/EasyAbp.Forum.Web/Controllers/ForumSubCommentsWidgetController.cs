﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Forum.Web.Controllers
{
    [Route("widgets")]
    public class ForumSubCommentsWidgetController : AbpController
    {
        [HttpGet]
        [Route("forum-sub-comments")]
        public virtual async Task<IActionResult> ForumSubCommentsAsync(Guid postId, Guid commentId, bool hasChildren)
        {
            return ViewComponent("ForumSubCommentsWidget", new
            {
                postId = postId,
                commentId = commentId,
                hasChildren = hasChildren
            });
        }
    }
}