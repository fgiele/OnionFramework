namespace ofw.repository.dapper
{
    public class DataObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public byte[] RowVersion { get; set; } = new byte[8];
    }
}