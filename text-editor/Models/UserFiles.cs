using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace text_editor.Models
{
    public class UserFiles
    {
        public int Id { get; set; }
        public string name { get; set; }
        [ForeignKey("AspNetUsers")]
        public String user_id { get; set; }
        public int sharedId { get; set; }
        public UserFiles() {}
    }
}