namespace TodoApi.Models
{
    public class TodoItem
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public bool IsComplete {get; set; }

        public string Secret { get; set; }

        public override string ToString()
        {
            return "[ID: " + ID + " Name: " + Name + " Owner: " + Owner + " IsComplete: " + IsComplete + " Secret: " + Secret + "]";
        }
    }
}