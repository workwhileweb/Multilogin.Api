using Multilogin.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

public static class Helper
{
    public static char GetRandomLetter(this Random rnd)
    {
        int num = rnd.Next(0, 26);
        char let = (char)('A' + num);

        return let;
    }

    public static string HoursAndMinutes(this TimeSpan ts)
    {
        return (ts < TimeSpan.Zero ? "-" : "+") + ts.ToString(@"hh\:mm");
    }

    public static object ReturnNull()
    {
        return null;
    }

    public static string GetBrowserRequestName(this Browser browser)
    {
        switch(browser)
        {
            case Browser.Mimic:
            case Browser.MimicMobile:
                return "mimic";

            case Browser.Stealthfox:
                return "stealth_fox";

            default:
                return string.Empty;
        }
    }

   

}