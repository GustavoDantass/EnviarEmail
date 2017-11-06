using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace EnviarEmail
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Para: ");
            string para = Console.ReadLine();
            Console.Write("Assunto: ");
            string assunto = Console.ReadLine();
            Console.Write("Corpo: ");
            string corpo = Console.ReadLine();


            //enviar email via C#
            SmtpClient cliente = new SmtpClient();
            NetworkCredential credenciais = new NetworkCredential();


            // definir as configuraçoes do cliente
            cliente.Host = "smtp.gmail.com";
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.UseDefaultCredentials = false;


            //definir as credenciais de acesso ao email
            credenciais.UserName = "nome";
            credenciais.Password = "senha";

            //define as credenciais no cliente
            cliente.Credentials = credenciais;


            //preparar a mensagem a enviar
            MailMessage mensagem = new MailMessage();

            //quem envio
            mensagem.From = new MailAddress("email");

            //assunto
            mensagem.Subject = assunto;

            //PARA por por codigo html
            mensagem.IsBodyHtml = true;

            //anexo
            // mensagem.Attachments.Add(new Attachment(lbl_anexo.Text));
            //texto //corpo da mensagem
            mensagem.Body = corpo;

            //para quem vai a mensagem
            mensagem.To.Add(para);

            try
            {
                //envio de mensagem de email(finalemnte)
                cliente.Send(mensagem);
                Console.Write("Mensagem enviada com sucesso");
            }
            catch (Exception ex)
            {
                //escrever um ficheiro de texto com o erro.
                Console.Write("Nao foi possivel enviar o email");
                
            }


            Console.ReadKey();




           
            

            

           

            

            
            
           
           
            
            
           
        }
    }
}
