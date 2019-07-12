using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace uStoreMvcConversion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FAQ()
        {
          

            return View();
        }

        public ActionResult Contact()
        {
         

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//validates token generated from the GET request & protects against cross site scripting
        public ActionResult Contact(Models.ContactViewModel contactInfo)
        {

            //1. Check that the Model information is valid
            //Verify ModelState.IsValid -- we need to ensure that we get correct info that passed our validation. (server side, benefits biz/dev.)
            //We need to add !ModelState.IsValid to return a View(); of the form with the data that the user submitted.
            if (!ModelState.IsValid)
            {
                //If the ModelState is not valid return a View of the contact w/ validation messages. 
                return View(contactInfo);
            }//end if !ModelState.IsValid

            //********************************************
            //If the model was valid, we need to process and send the EMAIL
            //We accept a ContavtViewModel object in order to process the users submitted data via the COntact View (Strongly Typed)
            //Due to the way the @Html methods render, the "name" attr. is created and assigned to the correct ContactViewModel property
            //1. Create the body/content for the email from the ContactViewModel properties
            string body = string.Format(
                $"Name: {contactInfo.Name}<br />"
                + $"Email: {contactInfo.Email}<br />"
                + $"Subject: {contactInfo.Subject}<br />"
                + $"Message:<br/> {contactInfo.Message}");
            //2. Create and configure the MailMessage object. (to/from addresss, subject, email content.)
            //.Addded a using statement System.Net.Mail
            MailMessage msg = new MailMessage("no-reply@jshdevco.com",//from address
                "joshua.s.harrison@outlook.com",//to address
                contactInfo.Subject,//subject of email
                body);//email body
            //3. Set properties of the MailMessage object (cc, bcc, set mail priorty, etc.)
            msg.IsBodyHtml = true; //
            msg.CC.Add("jarshvader@gmail.com");
            /*msg.Priority = MailPriority.High*///optional
            //4. create and configure the SMTP client (simple mail transfer protocol) (this will send the actual email)
            //added using System.Net
            SmtpClient client = new SmtpClient("mail.jshdevco.com");
            client.Credentials = new NetworkCredential("no-reply@jshdevco.com", "COopers21@!");
            client.EnableSsl = false;
            client.Port = 8889;
            //5. use the SMTP client object to try and send an email message. We will need to make sure that we close the SMTP client object 
            //when we are done attempting to send the email.
            using (client)
            {
                //automatically close and clean up resources related to the smtp client object
                //when its done, it is deleted and gone. (garbage collection)
                try
                {
                    //we are going to try to send the email message (with our client)
                    client.Send(msg);
                }
                catch
                {
                    //Failed to send - we will add a message and display it to the user on the layout
                    //create a ViewBag object to return an error to the user and send them back to the ContactView
                    ViewBag.ErrorMessage = "An error occurred!\nPlease try again.";
                    return View();
                }//end catch
            }//end using
            //send successful we will send the user to a ContactConfirmation view and send the ContactInfo object with it. 
            //return View();
            return View("ContactConfirmation", contactInfo);
        }

        public ActionResult Products()
        {

            return View();
        }

    }
}