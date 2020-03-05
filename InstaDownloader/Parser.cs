using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InstaDownloader
{
    public class Parser
    {
        public static Tuple<string, string> urlParse(string url)
        {
            string fileType = "";

            //Getting access for json file
            if (url[url.Length - 1] == '/')
            {
                url += "?__a=1";
            }
            else
            {
                url += "/?__a=1";
            }

            var json = new WebClient().DownloadString(url);
            int startIndex;

            //file type definition via json file parsing
            if(json.Contains("video_url"))
                startIndex = json.IndexOf("video_url") + 12;
            else
                startIndex = json.IndexOf("display_url") + 14;

            //json parsing
            string output_url = "";
            while (json[startIndex] != '"')
            {
                output_url += json[startIndex];
                startIndex++;
            }
            int index = output_url.IndexOf('?')-1;
            while(output_url[index] != '.')
            {
                fileType += output_url[index];
                --index;
            }

            char[] charArr = fileType.ToCharArray();
            Array.Reverse(charArr);
            fileType = new string(charArr);

            return new Tuple<string, string>(output_url, fileType);
        }
    }
}
