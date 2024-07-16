#nullable disable
using FluentValidation;
using ClassLibrary1.Models.jobposting;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Models
{

    
    public class ConfermaCandidatura
    {

        public string matricola { get; set; } = "";
        
        public int idjobPosting { get; set; } 
        public string idprovincia { get; set; } = "";
        public string idtitolostudio { get; set; } = "";
        public string idcomune { get; set; } = "";
    }

    public class ConfermaCandidaturaValidator : AbstractValidator<ConfermaCandidatura>
    {
        public ConfermaCandidaturaValidator()
        {
            RuleFor(x => x.matricola).NotEmpty();
    
        }
    }

}
