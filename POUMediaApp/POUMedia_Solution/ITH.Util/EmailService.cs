using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.IO;
using System.Web;



namespace ITH.Library
{
    /// <summary>
    /// This service will send emails.
    /// </summary>
    public static class EmailService
    {
        private static bool sendMail;
        private static string smtpServer;
        private static string emailFromAddress;
        private static string regexEmail;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="EmailService"/> class.
        ///// </summary>
        //public EmailService()
        //{
        //    Initialize();
        //}

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private static void Initialize()
        { 

            string sendMailFlag = ConfigurationManager.AppSettings["sendMail"];
            if (String.IsNullOrEmpty(sendMailFlag))
            {
                throw new ApplicationException("sendMail is not present in the configuration");
            }
            
            bool sendMailParsed = bool.TryParse(sendMailFlag, out sendMail);
            {
                if (!sendMailParsed)
                {
                    throw new ApplicationException("smtpServer in the configuration contains an invalid boolean value");
                }
            }

            smtpServer = ConfigurationManager.AppSettings["smtpServer"];
            if (String.IsNullOrEmpty(smtpServer))
            {
                throw new ApplicationException("smtpServer is not present in the configuration");
            }

            emailFromAddress = ConfigurationManager.AppSettings["emailFromAddress"];
            if (String.IsNullOrEmpty(emailFromAddress))
            {
                throw new ApplicationException("emailFromAddress is not present in the configuration");
            }

            regexEmail = ConfigurationManager.AppSettings["regexEmail"];
            if (String.IsNullOrEmpty(regexEmail))
            {
                throw new ApplicationException("regexEmail is not present in the configuration");
            }
           
        }


        /// <summary>
        /// Validates the email address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        private static bool ValidateEmailAddress(string address)
        {
            if (!string.IsNullOrEmpty(address))
            {
                return Regex.IsMatch(address, regexEmail);                                
            }

            return true;
        }

        /// <summary>
        /// Validates the email parameters.
        /// </summary>
        /// <param name="toEmailAddress">To email address.</param>
        /// <param name="toCCEmailAddress">To CC email address.</param>
        /// <param name="toBCCEmailAddress">To BCC email address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        private static bool ValidateEmailParameters(List<string> toEmailAddress, List<string> toCCEmailAddress, List<string> toBCCEmailAddress, string subject, string body, out List<String> errors)
        {
            errors = new List<string>();

            if (toEmailAddress.Count == 0)
            {
                errors.Add("No email address was provided");
            }

            foreach (string s in toEmailAddress)
            {
                bool valid = ValidateEmailAddress(s);
                if (valid == false)
                {
                    errors.Add("Email address " + s + " is invalid");
                }
            }

            if (String.IsNullOrEmpty(subject))
            {
                errors.Add("No subject was provided");
            }

            if (String.IsNullOrEmpty(body))
            {
                errors.Add("No body was provided");
            }

            return (errors.Count == 0);
        }

        /// <summary>
        /// Sends the E mail.
        /// </summary>
        /// <param name="toEmailAddressList">To email address list.</param>
        /// <param name="toCCEmailAddressList">To CC email address list.</param>
        /// <param name="toBCCEmailAddressList">To BCC email address list.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isHTML">if set to <c>true</c> [is HTML].</param>
        /// <returns></returns>
        public static bool SendEMail(List<string> toEmailAddressList, List<string> toCCEmailAddressList, List<string> toBCCEmailAddressList, string subject, string body, bool isHTML)
        {
            //Validate and through exceptions.
            Initialize();

            bool result = false;
            List<String> errors = new List<string>();

            if (sendMail)
            {
                bool IsValidParams = ValidateEmailParameters(toEmailAddressList, toCCEmailAddressList, toBCCEmailAddressList, subject, body, out errors);

                if (IsValidParams)
                {
                    try
                    {
                        using (MailMessage message = new MailMessage(emailFromAddress, emailFromAddress))
                        {
                            //A to address must be provided along with the from address in the constructor.
                            //since we have a seperate list to add, we are now clearing the list.
                            message.To.Clear();

                            foreach (string toAddress in toEmailAddressList)
                            {
                                message.To.Add(toAddress);
                            }

                            foreach (string toCCAddress in toCCEmailAddressList)
                            {
                                message.CC.Add(toCCAddress);
                            }

                            foreach (string toBCCAddress in toBCCEmailAddressList)
                            {
                                message.Bcc.Add(toBCCAddress);
                            }

                            message.Subject = subject;
                            message.Body = body;
                            message.IsBodyHtml = isHTML;

                            SmtpClient client = new SmtpClient(smtpServer);
                            client.Send(message);

                            result = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                errors.Add("Email functionality is turned off");
            }

            return (result);
        }


        
    }
}
