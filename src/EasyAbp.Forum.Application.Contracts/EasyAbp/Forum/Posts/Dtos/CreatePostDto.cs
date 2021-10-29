using System;
using System.ComponentModel;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace EasyAbp.Forum.Posts.Dtos
{
    [Serializable]
    public class CreatePostDto : ExtensibleObject
    {
        public Guid CommunityId { get; set; }

        [DynamicRange(
            typeof(ForumConsts),
            typeof(int),
            nameof(ForumConsts.Post.TitleMinLength),
            nameof(ForumConsts.Post.TitleMaxLength)
        )]
        public string Title { get; set; }

        public CreateUpdatePostContentDto Content { get; set; }
    }
}