using MicroEngine.Framework.Commons;

namespace MicroEngine.Models.RequestModels
{
    public class AbsenceFormModel : BaseModel
    {
        public AbsenceFormModel() { }

        public string UserId { get; set; } = string.Empty;
        public DateTime AbsenceFromDate { get; set; }
        public DateTime AbsenceToDate { get; set; }
        public int TotalAbsenceDay { get; set; }
        public string ReasonAbsence { get; set; } = string.Empty;
        public string Status = string.Empty;
        public string AbsenceType { get; set; } = string.Empty;
        public string PersonApprove { get; set; } = string.Empty;
        public DateTime ApproveDate { get; set; }
    }
}
