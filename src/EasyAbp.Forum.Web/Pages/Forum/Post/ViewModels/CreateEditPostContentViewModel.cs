using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Forum.Web.Pages.Forum.Post.ViewModels
{
    public class CreateEditPostContentViewModel
    {
        [Required]
        [Display(Name = "PostContentText")]
        public string Text { get; set; }
    }
}