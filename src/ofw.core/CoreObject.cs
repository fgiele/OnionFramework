namespace ofw.core
{
    public abstract class CoreObject
    {
        public Guid Id { get; set; }

        public abstract string Title { get; }

        public string Version { get; set; } = string.Empty;
    }
}