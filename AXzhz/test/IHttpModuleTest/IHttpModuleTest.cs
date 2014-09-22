using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace AXzhz.test.IHttpModuleTest
{
    public class HttpModuleTest : IHttpModule
    {
         public const string AppSettingsKey = "GoogleAnalyticsAccount";

         const string GoogleScript = "<script type=\"text/javascript\">" + "\n"
            + "var gaJsHost = ((\"https:\" == document.location.protocol) ? \"https://ssl.\" : \"http://www.\");" + "\n"
            + "document.write(unescape(\"%3Cscript src='\" + gaJsHost + \"google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E\"));" + "\n"
            + "</script>" + "\n"
            + "<script type=\"text/javascript\">" + "\n"
            + "var pageTracker = _gat._getTracker(\"UA-6266523\");" + "\n"
            + "pageTracker._trackPageview();" + "\n"
            + "</script>" + "\n";

        HttpApplication application;
        string accountNumber;

        public void Dispose()
        {
            //application.BeginRequest -= new EventHandler(OnBeginRequest);
        }

        public void Init(HttpApplication context)
        {
            accountNumber = "UA-6266523";
            if (!String.IsNullOrEmpty(accountNumber))
            {
                context.BeginRequest += new EventHandler(OnBeginRequest);
                application = context;
            }
        }

        void OnBeginRequest(object sender, EventArgs e)
        {
            //application.Response.Filter = new AnalyticsStream(application.Response, accountNumber, GoogleScript);
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
           // context.Response.Write(GoogleScript);
        }    
      
    }

    class AnalyticsStream : Stream
    {
        HttpResponse response;
        Stream innerStream;
        string accountNumber;
        MemoryStream memory = new MemoryStream();
        string GoogleScript;

        public AnalyticsStream(HttpResponse response, string accountNumber, string GoogleScript)
        {
            this.response = response;
            this.innerStream = response.Filter;
            this.accountNumber = accountNumber;
            this.GoogleScript = GoogleScript;
        }

        public override void Close()
        {
            string contentType = response.ContentType.ToLower();
            if (!(contentType.Contains("html")
                    || contentType.Contains("xhtml")
                    || contentType.Contains("asp")
                    || contentType.Contains("axd")
                ))
            {
                response.BinaryWrite(memory.ToArray());
            }
            else
            {
                memory.Position = 0;
                using (StreamWriter writer = new StreamWriter(innerStream, System.Text.Encoding.GetEncoding("gb2312")))
                {
                    using (StreamReader reader = new StreamReader(memory, System.Text.Encoding.GetEncoding("gb2312")))
                    {
                        while (!reader.EndOfStream)
                        {
                            // Find </body>
                            if (MatchesOrWrite(reader, writer, '<', null) &&
                                MatchesOrWrite(reader, writer, '/', "<") &&
                                MatchesOrWrite(reader, writer, 'b', "</") &&
                                MatchesOrWrite(reader, writer, 'o', "</b") &&
                                MatchesOrWrite(reader, writer, 'd', "</bo") &&
                                MatchesOrWrite(reader, writer, 'y', "</bod") &&
                                MatchesOrWrite(reader, writer, '>', "</body"))
                            {

                                string script = String.Format(GoogleScript, accountNumber) + "</body>";
                                writer.Write(script);

                                while (!reader.EndOfStream)
                                    writer.Write((char)reader.Read());
                            }
                        }
                    }
                }
            }

            base.Close();
        }

        private bool MatchesOrWrite(StreamReader reader, StreamWriter writer, char target, string buffered)
        {
            if (!reader.EndOfStream)
            {
                char current = (char)reader.Read();
                if (current == target)
                {
                    return true;
                }
                else
                {
                    writer.Write(buffered);
                    writer.Write(current);
                }
            }
            else
            {
                writer.Write(buffered);
            }

            return false;
        }

        public override bool CanRead
        {
            get { return memory.CanRead; }
        }

        public override bool CanSeek
        {
            get { return memory.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return memory.CanWrite; }
        }

        public override void Flush()
        {
            memory.Flush();
        }

        public override long Length
        {
            get { return memory.Length; }
        }

        public override long Position
        {
            get
            {
                return memory.Position;
            }
            set
            {
                memory.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return memory.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            memory.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            memory.Write(buffer, offset, count);
        }
    }
}
