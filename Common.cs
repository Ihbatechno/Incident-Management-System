using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMS
{
    public class Common
    {
        public SqlConnection obCon;
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["websiteConnectionString"].ToString());
        SqlCommand obCom;
        String strCon = System.Configuration.ConfigurationManager.ConnectionStrings["websiteConnectionString"].ConnectionString.ToString();

        SqlDataAdapter obDa;
        DataSet obDs;

        public void connection()
        {

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["websiteConnectionString"].ToString());
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
        public Common()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Execute Non Query
        public Boolean fnExecuteNonQuery(String strSql)
        {
            try
            {
                obCon = new SqlConnection(strCon);
                if (obCon.State == ConnectionState.Closed)
                    obCon.Open();
                obCom = new SqlCommand(strSql, obCon);
                obCom.CommandType = CommandType.Text;
                obCom.CommandTimeout = 90;
                obCom.ExecuteNonQuery();
                obCon.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                obCon = null;
                obCom = null;
            }
        }
        public Boolean fnExecuteNonQueryByPro(String lsProcedureName, ParameterCollection obParam)
        {
            try
            {
                obCon = new SqlConnection(strCon);
                if (obCon.State == ConnectionState.Closed)
                    obCon.Open();
                obCom = new SqlCommand(lsProcedureName, obCon);
                if (obParam.Count > 0)
                {
                    for (Int16 iCount = 0; iCount <= Convert.ToInt32(obParam.Count - 1); iCount++)
                    {
                        obCom.Parameters.AddWithValue(obParam[iCount].Name, obParam[iCount].DefaultValue);
                    }
                }

                obCom.CommandType = CommandType.StoredProcedure;
                //For 10 Minuts Execution Time
                obCom.CommandTimeout = 600;
                obCom.ExecuteNonQuery();
                obCon.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
            finally
            {
                obCon = null;
                obCom = null;
            }
        }
        #endregion

        #region fetch data by parameter collection
        public DataSet fnRetriveByPro(String lsProcedureName, ParameterCollection obParam)
        {
            obDs = new DataSet();
            try
            {
                obCon = new SqlConnection(strCon);
                if (obCon.State == ConnectionState.Closed)
                    obCon.Open();
                obCom = new SqlCommand(lsProcedureName, obCon);
                if (obParam.Count > 0)
                {
                    for (Int16 iCount = 0; iCount <= Convert.ToInt32(obParam.Count - 1); iCount++)
                    {
                        obCom.Parameters.AddWithValue(obParam[iCount].Name, obParam[iCount].DefaultValue);
                    }
                }
                obCom.CommandType = CommandType.StoredProcedure;
                //For 5 Minuts Execution Time for Final Pay 
                obCom.CommandTimeout = 300;
                obDa = new SqlDataAdapter(obCom);
                obDa.Fill(obDs);
                obCon.Close();
                return obDs;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                obCon = null;
                obCom = null;
                obDa = null;
                obDs = null;
            }
        }
        public DataSet fnRetriveByQuery(string Query)
        {
            try
            {
                obCon = new SqlConnection(strCon);
                if (obCon.State == ConnectionState.Closed)
                    obCon.Open();
                obDs = new DataSet();
                obDa = new SqlDataAdapter(Query, strCon);
                obDa.Fill(obDs, "A");
                obCon.Close();
                return obDs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return false;
            }
            finally
            {
                obCon = null;
                obCom = null;
            }

        }
        #endregion

        #region Dataset

        public DataSet ExecuteDataSet(string query)
        {
            DataSet ds = new DataSet();

            try
            {
                connection();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public DataSet ExecuteDataSet(string query, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();

            try
            {
                connection();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }


        #endregion

        #region ExecuteNonQuery by sqlparameter

        public int ExecuteNonQuery(string query)
        {
            int retval;

            try
            {
                connection();
                SqlCommand cmd = new SqlCommand(query, con);
                retval = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return retval;
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            int retval;
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return retval;
        }

        #endregion

        #region send email

        public void fnSendEmail(String EmailId, String sub, String msg)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["senderid"].ToString().Trim());
                mail.To.Add(EmailId);
                mail.Subject = sub;
                mail.Body = msg;

                //  System.Net.Mail.Attachment attachment;
                // attachment = new System.Net.Mail.Attachment(@"C:\Attachment.txt");
                //   mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["senderid"].ToString().Trim(), System.Configuration.ConfigurationManager.AppSettings["senderPass"].ToString().Trim());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                //Response.Write("i thing mail send...");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void fnSendEmail(string toList, string from, string ccList, string subject, string body)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            //  string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                    message.CC.Add(ccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                // We use gmail as our smtp client
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["senderid"].ToString().Trim(), System.Configuration.ConfigurationManager.AppSettings["senderPass"].ToString().Trim());

                smtpClient.Send(message);
                // msg = "Successful<BR>";
            }
            catch (Exception ex)
            {
                // msg = ex.Message;
            }

        }
        #endregion

        #region gamil id check, valid or not
        public int checkgmailId(string p)
        {
            int i;
            TcpClient tClient = new TcpClient("gmail-smtp-in.l.google.com", 550);
            string CRLF = "\r\n";
            byte[] dataBuffer;
            string ResponseString;
            NetworkStream netStream = tClient.GetStream();
            StreamReader reader = new StreamReader(netStream);
            ResponseString = reader.ReadLine();
            /* Perform HELO to SMTP Server and get Response */
            dataBuffer = BytesFromString("HELO" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            dataBuffer = BytesFromString("MAIL FROM:<" + System.Configuration.ConfigurationManager.AppSettings["senderid"].ToString().Trim() + ">" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            /* Read Response of the RCPT TO Message to know from google if it exist or not */
            dataBuffer = BytesFromString("RCPT TO:<" + p.Trim() + ">" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            if (GetResponseCode(ResponseString) == 550)
            {
                i = 0;
                return i;
            }
            /* QUITE CONNECTION */
            dataBuffer = BytesFromString("QUITE" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            tClient.Close();
            i = 1;
            return i;
        }
        private byte[] BytesFromString(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
        private int GetResponseCode(string ResponseString)
        {
            return int.Parse(ResponseString.Substring(0, 3));
        }
        #endregion

        #region clear all control
        public void ClearInput(Control parent)
        {
            try
            {
                foreach (Control c in parent.Controls)
                {
                    if (c.Controls.Count > 0)
                        ClearInput(c);
                    else
                    {
                        if (c is TextBox)
                            (c as TextBox).Text = "";

                        if (c is CheckBox)
                            (c as CheckBox).Checked = false;

                        if (c is DropDownList)
                            (c as DropDownList).SelectedIndex = 0;

                    }
                }
            }
            catch (Exception ex)
            {


            }

        }
        #endregion
    }
}