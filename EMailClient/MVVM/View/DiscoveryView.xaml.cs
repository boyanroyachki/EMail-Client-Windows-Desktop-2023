using System;
using System.Windows;
using System.Windows.Controls;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;


namespace EMailClient.MVVM.View
{
    /// <summary>
    /// Interaction logic for DiscoveryView.xaml
    /// </summary>
    public partial class DiscoveryView : UserControl
    {
        public DiscoveryView()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string userEmail = userEmailInput.Text;
            string userPass = userPassword.Password;
            string emailTo = "elena.peynovska@gmail.com";
            string topic = "Posleden test obeshtavam";
            string message = "pravq oshte testove, lov you<3";

            try
            {
                SendEmail(userEmail, userPass, emailTo, topic, message);
                MessageBox.Show("Message sent");
                //send

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }


        }
        void SendEmail(string fromEmail, string password, string toEmail, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("", fromEmail));
            emailMessage.To.Add(new MailboxAddress("", toEmail));

            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            var client = new SmtpClient();
            
            client.Connect("smtp.gmail.com", 465, true);
            

            //add other types

            client.Authenticate(fromEmail, password);
            client.Send(emailMessage);
            client.Disconnect(true);
        }
    }

}
