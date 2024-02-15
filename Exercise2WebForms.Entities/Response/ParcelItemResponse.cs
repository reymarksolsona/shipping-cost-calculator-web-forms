namespace Exercise2WebForms.Entities.Response
{
    public class ParcelItemResponse
    {
        public int ParcelItemID { get; set; }
        public string Title { get; set; }
        public decimal TotalWeight { get; set; }
        public ParcelCalculatorResponse Info { get; set; }
        public string CreatedDate { get; set; }
    }
}
