using Keeper.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper.Context.Model
{
    public class TagModel : IDisposable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = default!;
        public TagType Type { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
