using HospitalScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HospitalScheduler.WebApp.Code
{
    public class MailSender
    {
        private SmtpClient client;
        public MailSender()
        {
            client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            System.Net.NetworkCredential credential =
                new System.Net.NetworkCredential("hospitalscheduler@outlook.com", "drap5@tadetre");

            client.EnableSsl = true;
            client.Credentials = credential;

        }
        public void SendWelcomeMail(string emailAddress)
        {
            MailMessage message = new MailMessage("hospitalscheduler@outlook.com", emailAddress);

            message.Subject = "Welcome";
            message.Body = "<h1> Welcome to our site! <h1>";
            message.IsBodyHtml = true;
            client.Send(message);
        }

        public void SendAppointmentMail(string emailAddress, Appointment appointment)
        {
            if (emailAddress == "Confidential")
            {
                return;
            }

            MailMessage message = new MailMessage("hospitalscheduler@outlook.com", emailAddress);

            message.Subject = "Appointment Scheduled";
            message.Body = "<p>Medic: " + appointment.Medic.FirstName + ' ' + appointment.Medic.LastName + "</p>" +
            "<p>Patient: " + appointment.Patient.FirstName + ' ' + appointment.Patient.LastName + "</p>" +
            "<p>Duration: " + appointment.Duration + " minutes</p>" + "<p>Details:" + appointment.Details + "</p>";
            message.IsBodyHtml = true;
            client.Send(message);
        }
    }
}
