using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace text_editor.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int FileId { get; set; } // This should be the same data type as the primary key in the related table

        // Navigation property to establish the relationship
        [ForeignKey("FileId")]
        public UserFiles UserFile { get; set; }
        //[Required]
        //public string? UserId { get; set; }
        //[ForeignKey("UserId")]
        //public IdentityUser? User { get; set; }
    }
}
