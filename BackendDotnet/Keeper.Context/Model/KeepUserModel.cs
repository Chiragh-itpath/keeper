using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Context.Model
{
    public class KeepUserModel
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(KeepModel))]
        public Guid? KeepId { get; set; }
        [ForeignKey(nameof(UserModel))]
        public Guid UserId { get; set; }
    }
}
