namespace DomainModel.BussinessModel
{
    public class TestAcceptionListItem
    {
        public int TestAcceptionItemId { get; set; }
        public int TestAcceptionHeaderId { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int TestMethodId { get; set; }
        public string TestMethodName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public double? ResponseNumber { get; set; }
        public string ResponseNumberText { get; set; }
        public string ResponseDescription { get; set; }
        public bool? ResponseBoolean { get; set; }
        public string ResponseText { get; set; }
        public bool HasStar { get; set; }
        public bool IsEmergency { get; set; }
    }
}
