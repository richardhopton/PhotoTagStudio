#region Copyright (C) 2005-2008 Benjamin Schröter <benjamin@irgendwie.net>
//
// This file is part of PhotoTagStudio
//
// PhotoTagStudio is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// PhotoTagStudio is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with PhotoTagStudio; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, 5th Floor, Boston, MA 02110-1301 USA.
#endregion

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Schroeter.PhotoTagStudio.Features.KmzMaker
{
    public class GpsLogFactory
    {
        private const bool USE_GPGGA = false;

        public static GpsLog FromFile(string filename)
        {
            if (USE_GPGGA)
                return FromNmeaGpggaFile(filename);
            else 
                return FromNmeaGprmcFile(filename);
        }

//        private const string REGEX_NMEA_GPRMC = @"\$GPRMC,(?<time>[0-9.]{6,}),(?<warning>\w),(?<lat>[0-9.]*),(?<latdir>[NS]),(?<lon>[0-9.]*),(?<londir>[EW]),(?<speed>[0-9.]*),(?<direction>[0-9.]*),(?<date>[0-9]{6}),([0-9.]*),(.*),(.*)\*";
        private const string REGEX_NMEA_GPRMC = @"\$GPRMC,(?<time>[0-9.]{6,}),(?<warning>\w),(?<lat>[0-9.]*),(?<latdir>[NS]),(?<lon>[0-9.]*),(?<londir>[EW]),(?<speed>[0-9.]*),(?<direction>[0-9.]*),(?<date>[0-9]{6})";
        private const string REGEX_NMEA_GPWPL = @"\$GPWPL,(?<lat>[0-9.]*),(?<latdir>[NS]),(?<lon>[0-9.]*),(?<londir>[EW]),(?<name>[\w]*)\*";
        public static GpsLog FromNmeaGprmcFile(string filename)
        {
            GpsLog log = new GpsLog();

            FileStream fs = File.OpenRead(filename);            
            TextReader tr = new StreamReader(fs);
            String inputString = tr.ReadToEnd();
            tr.Close();

            Regex regexGprmc = new Regex(REGEX_NMEA_GPRMC);
            Match match = regexGprmc.Match(inputString);
            while (match.Success)
            {
                try
                {
                    GpsLogEntry e = new GpsLogEntry();

                    e.Latitude = Convert(match.Groups["lat"].Value);
                    if (match.Groups["latdir"].Value == "S")
                        e.Latitude *= -1;

                    e.Longitude = Convert(match.Groups["lon"].Value);
                    if (match.Groups["londir"].Value == "W")
                        e.Longitude *= -1;

                    string time = match.Groups["time"].Value;
                    int h = int.Parse(time.Substring(0, 2));
                    int min = int.Parse(time.Substring(2, 2));
                    int s = int.Parse(time.Substring(4, 2));

                    string date = match.Groups["date"].Value;
                    int d = int.Parse(date.Substring(0, 2));
                    int m = int.Parse(date.Substring(2, 2));
                    int y = int.Parse(date.Substring(4, 2));
                    if (y > 80)
                        y += 1900;
                    else
                        y += 2000;
                    
                    e.Time = new DateTime(y,m,d,h,min,s); // TODO  ms?

                    log.AddEntry(e);
                }
                catch { }

                match = match.NextMatch();
            }
            
            Regex regexGpwpl = new Regex(REGEX_NMEA_GPWPL);
            match = regexGpwpl.Match(inputString);
            while (match.Success)
            {
                try
                {
                    NamedGpsLogEntry e = new NamedGpsLogEntry();

                    e.Latitude = Convert(match.Groups["lat"].Value);
                    if (match.Groups["latdir"].Value == "S")
                        e.Latitude *= -1;

                    e.Longitude = Convert(match.Groups["lon"].Value);
                    if (match.Groups["londir"].Value == "W")
                        e.Longitude *= -1;

                    e.Name = match.Groups["name"].Value.Trim();

                    log.Waypoints.Add(e);
                }
                catch {}

                match = match.NextMatch();
            }

            return log;
        }

        public static GpsLog FromNmeaGpggaFile(string filename)
        {
            GpsLog log = new GpsLog();

            FileStream fs = File.OpenRead(filename);
            TextReader tr = new StreamReader(fs);

            string line = tr.ReadLine();
            TimeSpan lastTime = new TimeSpan(0, 0, 0);
            int dayoffset = 0;
            while (line != null)
            {
                // $GPGGA,hhmmss.ss,ddmm.mmmm,n,dddmm.mmmm,e,q,ss,y.y,a.a,z,g.g,z,t.t,iii*CC
                // $GPGGA,183456.000,3424.8054,N,11941.2676,W,1,05,1.4,-2.7,M,-33.3,M,,0000*44
                if (line.StartsWith("$GPGGA"))
                {                    
                    string[] parts = line.Split(',');

                    if (parts.Length >= 7)
                    {
                        string time = parts[1];
                        string lat = parts[2];
                        string latdir = parts[3];
                        string lon = parts[4];
                        string londir = parts[5];
                        string quality = parts[6];
                        
                        if (       time != ""
                                && lat !=  ""
                                && (latdir == "N" || latdir == "S")
                                && lon != ""
                                && (londir == "E" || londir == "W")
                                && quality != "")
                        {
                            try
                            {
                                GpsLogEntry e = new GpsLogEntry();

                                e.Latitude = Convert(lat);
                                if (latdir == "S")
                                    e.Latitude *= -1;

                                e.Longitude = Convert(lon);
                                if (londir == "W")
                                    e.Longitude *= -1;

                                int h = int.Parse(time.Substring(0, 2));
                                int m = int.Parse(time.Substring(2, 2));
                                int s = int.Parse(time.Substring(4, 2));
                                TimeSpan currentTime = new TimeSpan(dayoffset, h, m, s); //TODO ms?
                                if (lastTime.CompareTo(currentTime) > 0)
                                {
                                    dayoffset++;
                                    currentTime = new TimeSpan(dayoffset, h, m, s); //TODO ms?                                    
                                }
                                lastTime = currentTime;
                                
                                // Fixed when starting to use DatetTime Type
                                e.Time = new DateTime(2000,0,currentTime.Days,currentTime.Hours,currentTime.Minutes,currentTime.Seconds);

                                log.AddEntry(e);
                            }
                            catch
                            {
                                
                            }
                        }
                    }
                }
                
                line = tr.ReadLine();
            }

            return log;            
        }
        
        private static decimal Convert(string s)
        {
            decimal x = XmlConvert.ToDecimal(s);
            int deg = ((int)x) / 100;
            decimal min = x - (deg * 100);
            return deg + (min / 60);
        }
    }
}
