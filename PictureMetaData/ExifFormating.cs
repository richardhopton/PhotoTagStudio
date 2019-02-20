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
using System.Text;

namespace Schroeter.Photo
{
    internal class ExifFormating
    {
        public static string printDefault(string value)
        {
            return value;
        }

        public static string printFloat(string value)
        {
            long first;
            long second;
            toRational(value, out first, out second);
            if (second != 0)
            {
                double d = first;
                d /= second;
                return d.ToString();
            }
            else
                return value;
        }


        public static string printUnit(string value)
        {
            switch (value.Trim())
            {
                case "2": return "inch";
                case "3": return "cm";
                default: return "(" + value + ")";
            }

        }

        public static string print0x0103(string value)
        {
            switch (value.Trim())
            {
                case "1": return "TIFF";
                case "6": return "JPEG";
                default: return "(" + value + ")";
            }

        }

        public static string print0x0106(string value)
        {
            switch (value.Trim())
            {
                case "2": return "RGB";
                case "6": return "YCbCr";
                default: return "(" + value + ")";
            }

        }

        public static string print0x0112(string value)
        {
            switch (value.Trim())
            {
                case "1": return "top, left";
                case "2": return "top, right";
                case "3": return "bottom, right";
                case "4": return "bottom, left";
                case "5": return "left, top";
                case "6": return "right, top";
                case "7": return "right, bottom";
                case "8": return "left, bottom";
                default: return "(" + value + ")";

            }
        }

        public static string print0x0213(string value)
        {
            switch (value.Trim())
            {
                case "1": return "Centered";
                case "2": return "Co-sited";
                default: return "(" + value + ")";
            }

        }

        public static string print0x8822(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Not defined";
                case "1": return "Manual";
                case "2": return "Auto";
                case "3": return "Aperture priority";
                case "4": return "Shutter priority";
                case "5": return "Creative program";
                case "6": return "Action program";
                case "7": return "Portrait mode";
                case "8": return "Landscape mode";
                default: return "(" + value + ")";
            }

        }



        public static string print0x9207(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Unknown";
                case "1": return "Average";
                case "2": return "Center weighted";
                case "3": return "Spot";
                case "4": return "Multispot";
                case "5": return "Matrix";
                case "6": return "Partial";
                default: return "(" + value + ")";
            }

        }

        public static string print0x9208(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Unknown";
                case "1": return "Daylight";
                case "2": return "Fluorescent";
                case "3": return "Tungsten (incandescent light)";
                case "4": return "Flash";
                case "9": return "Fine weather";
                case "10": return "Cloudy weather";
                case "11": return "Shade";
                case "12": return "Daylight fluorescent (D 5700 - 7100K)";
                case "13": return "Day white fluorescent (N 4600 - 5400K)";
                case "14": return "Cool white fluorescent (W 3900 - 4500K)";
                case "15": return "White fluorescent (WW 3200 - 3700K)";
                case "17": return "Standard light A";
                case "18": return "Standard light B";
                case "19": return "Standard light C";
                case "20": return "D55";
                case "21": return "D65";
                case "22": return "D75";
                case "23": return "D50";
                case "24": return "ISO studio tungsten";
                case "255": return "other light source";
                default: return "(" + value + ")";
            }

        }

        public static string print0x9209(string value)
        {
            switch (value.Trim())
            {
                case "0": return "No";
                case "1": return "Yes";
                case "5": return "Strobe return light not detected";
                case "7": return "Strobe return light detected";
                case "9": return "Yes, compulsory";
                case "13": return "Yes, compulsory, return light not detected";
                case "15": return "Yes, compulsory, return light detected";
                case "16": return "No, compulsory";
                case "24": return "No, auto";
                case "25": return "Yes, auto";
                case "29": return "Yes, auto, return light not detected";
                case "31": return "Yes, auto, return light detected";
                case "32": return "No flash function";
                case "65": return "Yes, red-eye reduction";
                case "69": return "Yes, red-eye reduction, return light not detected";
                case "71": return "Yes, red-eye reduction, return light detected";
                case "73": return "Yes, compulsory, red-eye reduction";
                case "77": return "Yes, compulsory, red-eye reduction, return light not detected";
                case "79": return "Yes, compulsory, red-eye reduction, return light detected";
                case "89": return "Yes, auto, red-eye reduction";
                case "93": return "Yes, auto, red-eye reduction, return light not detected";
                case "95": return "Yes, auto, red-eye reduction, return light detected";
                default: return "(" + value + ")";
            }

        }


        public static string print0xa001(string value)
        {
            switch (value.Trim())
            {
                case "1": return "sRGB";
                case "65535": return "Uncalibrated";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa217(string value)
        {
            switch (value.Trim())
            {
                case "1": return "Not defined";
                case "2": return "One-chip color area";
                case "3": return "Two-chip color area";
                case "4": return "Three-chip color area";
                case "5": return "Color sequential area";
                case "7": return "Trilinear sensor";
                case "8": return "Color sequential linear";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa300(string value)
        {
            switch (value.Trim())
            {
                case "3": return "Digital still camera";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa301(string value)
        {
            switch (value.Trim())
            {
                case "1": return "Directly photographed";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa402(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Auto";
                case "1": return "Manual";
                case "2": return "Auto bracket";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa403(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Auto";
                case "1": return "Manual";
                default: return "(" + value + ")";
            }

        }



        public static string print0xa406(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Standard";
                case "1": return "Landscape";
                case "2": return "Portrait";
                case "3": return "Night scene";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa407(string value)
        {
            switch (value.Trim())
            {
                case "0": return "None";
                case "1": return "Low gain up";
                case "2": return "High gain up";
                case "3": return "Low gain down";
                case "4": return "High gain down";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa408(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Normal";
                case "1": return "Soft";
                case "2": return "Hard";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa409(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Normal";
                case "1": return "Low";
                case "2": return "High";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa40a(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Normal";
                case "1": return "Soft";
                case "2": return "Hard";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa40c(string value)
        {
            switch (value.Trim())
            {
                case "0": return "Unknown";
                case "1": return "Macro";
                case "2": return "Close view";
                case "3": return "Distant view";
                default: return "(" + value + ")";
            }

        }

        public static string print0xa405(string value)
        {
            if (value == "0")
                return "Unknown";
            else
                return value + ".0 mm";
        }

        public static string print0xa404(string value)
        {
            string s = printFloat(value);
            if (s == "0")
                return "Digital zoom not used";
            else
                return s;
        }

        public static string print0x9101(string value)
        {
            StringBuilder b = new StringBuilder();
            string[] parts = value.Split(' ');
            foreach (string p in parts)
                switch (p.Trim())
                {
                    case "": break;
                    case "0": break;
                    case "1": b.Append("Y"); break;
                    case "2": b.Append("Cb"); break;
                    case "3": b.Append("Cr"); break;
                    case "4": b.Append("R"); break;
                    case "5": b.Append("G"); break;
                    case "6": b.Append("B"); break;
                    default: b.Append("(");
                        b.Append(p);
                        b.Append(")");
                        break;
                }

            return b.ToString();
        }

        public static string print0x829a(string value)
        {
            long first;
            long second;
            toRational(value, out first, out second);


            if (first > 1 && second > 1 && second >= first)
            {
                double d = second;
                d /= first;
                d += 0.5;
                second = (int)d;
                first = 1;
            }

            if (second > 1 && second < first)
            {
                double d = first;
                d /= second;
                d += 0.5;
                first = (int)d;
                second = 1;
            }

            if (second == 1)
                return first + " s";
            else
                return first + "/" + second + " s";
        }
        public static string print0x829d(string value)
        {
            long first;
            long second;
            toRational(value, out first, out second);

            if (second != 0)
            {
                double d = first;
                d /= second;
                return "f/" + d.ToString();
            }
            else
                return "(" + value + ")";
        }

        public static string print0x9204(string value)
        {
            long first;
            long second;
            toRational(value, out first, out second);

            if (second <= 0)
                return "(" + first + "/" + second + ")";
            else if (first == 0)
                return "0";
            else
            {
                long d = lgcd(Math.Abs(first), second);
                long num = Math.Abs(first) / d;
                long den = second / d;

                string s = first < 0 ? "-" : " + ";
                s += num.ToString();
                if (den != 1)
                    s += "/" + den.ToString();

                return s;
            }
        }
        private static long lgcd(long a, long b)
        {
            long temp;
            if (a < b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            while ((temp = a % b) != 0)
            {
                a = b;
                b = temp;
            }
            return b;
        }

        public static string print0x9206(string value)
        {
            long first;
            long second;
            toRational(value, out first, out second);

            if (first == 0)
                return "Unknown";

            if (first == 4294967295)
                return "Infinity";

            if (second != 0)
            {
                double d = first;
                d /= second;
                return d.ToString("0.00") + " m";
            }

            return "(" + value + ")";
        }

        public static string print0x920a(string value)
        {
            long first;
            long second;
            toRational(value, out first, out second);

            if (second != 0)
            {
                double d = first;
                d /= second;
                return d.ToString("0.0") + " mm";
            }
            else
                return "(" + value + ")";

        }



        private static void toRational(string value, out long first, out long second)
        {
            string[] parts = value.Split('/');
            if (parts.Length >= 2)
            {
                first = long.Parse(parts[0]);
                second = long.Parse(parts[1]);
            }
            else
            {
                first = 0;
                second = 0;
            }
        }
    }
}
