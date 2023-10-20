using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Keeper.Context.Model
{
    [Table("Files")]
    public class FileModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string FilePath { get; set; } = default!;
        public string OriginalName { get; set; } = default!;
    }
}
