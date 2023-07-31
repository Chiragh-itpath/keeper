using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper.Context.Model
{
    public class UserModel : IDisposable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(30), Required]
        public string UserName { get; set; } = default!;
        [StringLength(50), Required]
        public string Email { get; set; } = default!;
        [StringLength(10)]
        public string Contact { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
