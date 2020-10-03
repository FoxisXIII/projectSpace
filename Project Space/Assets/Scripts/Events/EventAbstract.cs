
    public abstract class EventAbstract : IEvent
    {
        public virtual void Initializer()
        {
        }

        public virtual void Update()
        {
        }

        public virtual bool EndCondition()
        {
            return false;
        }

        public virtual void Destructor()
        {
        }

        public virtual string EventName()
        {
            return "";
        }
    }