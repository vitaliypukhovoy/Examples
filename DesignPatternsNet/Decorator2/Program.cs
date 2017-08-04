using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator2
{
    class Program
    {
        static void Main(string[] args)
        {

            IMessage msg = new Message();
            msg.Msg = "Hello";

            IMessage decorator = new EmailDecorator(
                new FaxDecorator(
                    new ExternalSystemDecorator(msg)));
            decorator.Process();

            Console.WriteLine();
            decorator = new EmailDecorator(msg);
            decorator.Msg = "Bye";
            decorator.Process();

            Console.ReadKey(); 

        }
    }

    public interface IMessage
    {
        string Msg { get; set; }
        void Process();
    }

    public class Message : IMessage
    {
        public string Msg { get; set; }
        public void Process()
        {
            Console.WriteLine(String.Format("Saved '{0}' to database.", Msg));
        }
    }

    public abstract class BaseMessageDecorator : IMessage
    {
        private IMessage innerMessage;

        public BaseMessageDecorator(IMessage decorator)
        {
            innerMessage = decorator;
        }

        public virtual void Process()
        {
            innerMessage.Process();
        }

        public string Msg
        {
            get
            {
                return innerMessage.Msg;
            }

            set
            {
                innerMessage.Msg = value;
            }
        }
    }

    public class EmailDecorator : BaseMessageDecorator
    {
        public EmailDecorator(IMessage decorator)
            : base(decorator)
        { }

        public override void Process()
        {
            base.Process();
            Console.WriteLine(String.Format("Sent '{0}' as email.", Msg));
        }
    }

    public class FaxDecorator : BaseMessageDecorator
    {
        public FaxDecorator(IMessage decorator)
            : base(decorator)
        { }
        public override void Process()
        {
            base.Process();
            Console.WriteLine(String.Format("Sent '{0}' as fax.", Msg));
        }
    }

    public class ExternalSystemDecorator : BaseMessageDecorator
    {
        public ExternalSystemDecorator(IMessage decorator)
            : base(decorator)
        { }

        public override void Process()
        {
            base.Process();
            Console.WriteLine(String.Format("Sent '{0}' to external system.", Msg));
        }
    } 


}
