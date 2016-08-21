namespace CurrencyApp.Helpers
{
    public class JsonData
    {
        public JsonData()
        {
            Success = true;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
    }
}