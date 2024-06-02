namespace _CellPhoneService_.Controller
{
    public enum Errors
    {
        SystemError,
        ClientError,
        NoneErrors
    }

    public class Messages
    {
        public Messages()
        {
            Message = null;
            Error = Errors.NoneErrors;
        }
        public Messages(string message)
        {
            this.Message = message;
            this.Error = Errors.NoneErrors;
        }
        public Messages(string message, Errors error)
        {
            this.Message = message;
            this.Error = error;
        }


        public string Message { get; set; }
        public Errors Error { get; set; }


    }

    public class Instance<T>
    {
        Messages message { get; set; }
        public T obj { get; set; }


        public Instance(Messages message)
        {
            this.message = message;
            this.obj = obj;
        }
        public Instance()
        {
            message = new Messages();
        }

        public void setMessageStr(string message)
        {
            this.message.Message = message;
        }

        public void setMessageError(Errors error)
        {
            this.message.Error = error;
        }
    }
}
