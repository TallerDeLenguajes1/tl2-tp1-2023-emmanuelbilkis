﻿using _Cadeteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Formats.Asn1;
using NPOI.SS.Formula.Functions;

namespace _Cadeteria
{
    public class AccesoDato
    {
        public List<Cadete> GetCadetes(string path)
        {

            List<Cadete> cadetes = new List<Cadete>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] ArregloCadetes = line.Split(',');
                    Cadete cadete = new Cadete(int.Parse(ArregloCadetes[0]), ArregloCadetes[1], ArregloCadetes[2], int.Parse(ArregloCadetes[3]));
                    cadetes.Add(cadete);
                }

                sr.Close();
                return cadetes;
            }
        }

        public Cadeteria GetCadeteria(string path)
        {
            Cadeteria cadeteria = new Cadeteria();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                if (string.IsNullOrEmpty(path))
                {
                    return null;
                }
                else
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] ArregloCadeteria = line.Split(',');
                        Cadeteria cadeteria1 = new Cadeteria(ArregloCadeteria[0], int.Parse(ArregloCadeteria[1]));
                        cadeteria = cadeteria1;
                    }

                    sr.Close();
                    return cadeteria;
                }
                
            }
        }
    }
}
