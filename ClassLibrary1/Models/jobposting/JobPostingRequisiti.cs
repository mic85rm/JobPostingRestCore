﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models.jobposting
{
    public partial class JobPostingRequisiti
    {
        public int Id { get; set; }
        public int? Idrequisito { get; set; }
        public int? IdjobPosting { get; set; }
        public byte? Criterio { get; set; }
        public string Valore { get; set; }
        public DateTime? RequisitoAl { get; set; }
        public string MsgMancatoReq { get; set; }
        public byte? Bloccante { get; set; }
        public double? Punteggio { get; set; }
        public int? Gruppo { get; set; }
        public byte? Operatore { get; set; }
        public int? IdcategoriaPunteggio { get; set; }
        public bool? Visibile { get; set; }
        public int? IdcampoBypass { get; set; }
    }
}