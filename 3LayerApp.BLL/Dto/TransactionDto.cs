namespace _3LayerApp.BLL.Dto
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public int TransactionTypeId { get; set; }

        public string TransactionTypeName { get; set; }
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
