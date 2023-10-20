using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keeper.Context.Model
{
    [Table("ItemFileLinker")]
    public class ItemFileLinkerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("ItemID")]
        public Guid ItemId { get; set; }
        public virtual ItemModel Item { get; set; }
        [ForeignKey("FileId")]
        public Guid FileId { get; set; }
        public virtual FileModel File { get; set; }
    }
}
