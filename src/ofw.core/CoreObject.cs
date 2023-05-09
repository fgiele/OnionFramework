namespace ofw.core
{
    public abstract class CoreObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public ObjectState State { get; internal set; } = ObjectState.New;

        public abstract string Title { get; }

        public string Version { get; set; } = string.Empty;

        internal void SetDirty()
        {
            if (State != ObjectState.New)
            {
                State = ObjectState.Changed;
            }
        }
    }
}