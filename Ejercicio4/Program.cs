// Ejersicio de implementacion 

namespace Ejercicio4
{
    abstract class AbstractSample
    {
        private string message;

        public AbstractSample(string msg)
        {
            message = msg;
        }

        // Metodo abstracto
        public abstract void PrintMessage();

        // Metodo virtual que invierte el mensaje
        public virtual void InvertMessage()
        {
            char[] caracteres = message.ToCharArray();
            Array.Reverse(caracteres);
            message = new string(caracteres);
        }

        // Metodo protegido para acceder al mensaje desde las subclases
        protected string GetMessage()
        {
            return message;
        }

        // Metodo protegido para cambiar el mensaje desde subclases
        protected void SetMessage(string nuevo)
        {
            message = nuevo;
        }
    }

    // Clase que imprime el mensaje tal cual
    class MensajeNormal : AbstractSample
    {
        public MensajeNormal(string msg) : base(msg) { }

        public override void PrintMessage()
        {
            Console.WriteLine("Mensaje normal: " + GetMessage());
        }
    }

    // Clase que invierte mallusculas y minusculas al imprimir, y sobreescribe InvertMessage
    class MensajeAlternado : AbstractSample
    {
        public MensajeAlternado(string msg) : base(msg) { }

        public override void PrintMessage()
        {
            string original = GetMessage();
            string alternado = "";

            foreach (char c in original)
            {
                alternado += char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
            }

            Console.WriteLine("Mensaje alternado: " + alternado);
        }

        public override void InvertMessage()
        {
            base.InvertMessage(); // Invertir normalmente
            string invertido = GetMessage();
            string cambiado = "";

            foreach (char c in invertido)
            {
                cambiado += char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
            }

            SetMessage(cambiado);
        }
    }

    // Clase que prueba las implementaciones
    class MessageManager
    {
        static void Main(string[] args)
        {
            AbstractSample mensaje1 = new MensajeNormal("Hola Mundo");
            AbstractSample mensaje2 = new MensajeAlternado("Hola Mundo");

            mensaje1.PrintMessage();      // Imprime el mensaje tal cual
            mensaje2.PrintMessage();      // Imprime el mensaje con mallusculas y minusculas invertidas

            mensaje1.InvertMessage();     // Invierte el mensaje normal
            mensaje2.InvertMessage();     // Invierte el mensaje y tambien cambia mallusculas

            Console.WriteLine("Después de invertir:");
            mensaje1.PrintMessage();
            mensaje2.PrintMessage();
        }
    }
}

