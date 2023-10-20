using Keeper.Common.Enums;

namespace Keeper.Common.OtherModels
{
    public class MailModel
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public MailCategory Category { get; set; }
    }
}
