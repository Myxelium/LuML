namespace Contract.Responses
{
    public class TrashDetectionResponse
    {
        public bool IsTrash { get; set; }
        public string TrashType { get; set; }
        public float Confidence { get; set; }
    }
}
