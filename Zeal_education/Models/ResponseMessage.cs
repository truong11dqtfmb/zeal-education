namespace Zeal_education.Models
{
    public class ResponseMessage
    {
        public Boolean? success { get; set; }
        public string? message { get; set; }
        public Object? data { get; set; }

        public ResponseMessage() { }

        public ResponseMessage(Boolean success, String message, Object data)
        {
            this.success = success;
            this.message = message;
            this.data = data;
        }

        public static ResponseMessage error(String mes)
        {
            ResponseMessage message = new ResponseMessage();
            message.success = false;
            message.message = mes;
            message.data = null;
            return message;
        }

        public static ResponseMessage error(String mes, Object data)
        {
            ResponseMessage message = new ResponseMessage();
            message.success = false;
            message.message = mes;
            message.data = data;
            return message;
        }

        public static ResponseMessage ok(String mes)
        {
            ResponseMessage message = new ResponseMessage();
            message.success = true;
            message.message = mes;
            message.data = null;
            return message;
        }

        public static ResponseMessage ok(String mes, Object data)
        {
            ResponseMessage message = new ResponseMessage();
            message.success = true;
            message.message = mes;
            message.data = data;
            return message;
        }



    }
}
