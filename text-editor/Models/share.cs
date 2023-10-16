using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace text_editor.Models
{
    [Keyless]
    public class share
    {
        [Required]
        [ForeignKey("UserId")]
        public string? Sender { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public string? Reciever { get; set; }
        [Required]
        [ForeignKey("Document")]
        public string? DocumentId { get; set; }
    }
}
