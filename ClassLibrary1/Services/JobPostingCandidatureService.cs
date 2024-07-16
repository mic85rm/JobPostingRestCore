using ClassLibrary1.Models;
using ClassLibrary1.Models.jobposting;

namespace ClassLibrary1.Services
{
    public class JobPostingCandidatureService : IJobPostingCandidature
    {
        private readonly jobpostingContext Context;
        private readonly PersonaleContext personaleContext;

        public JobPostingCandidatureService(jobpostingContext Context,PersonaleContext personaleContext)
        {
            this.Context = Context;
            this.personaleContext = personaleContext;
        }

       

        public List<JobPostingCandidatureMatricola> Candidature()
        {

            var Allcandidatures= Context.JobPostingCandidatures.Select(x => new JobPostingCandidature
            {
                  Idpersonale= x.Idpersonale,
             IdjobPosting=x.IdjobPosting}).ToList();

            var Allpersonale=personaleContext.Personales.Select(x=> new Personale
            {
                Id=x.Id,
                Matricola= x.Matricola,
                Cognome= x.Cognome,
                Nome= x.Nome
            }).ToList();

                //var jbc=  Context.JobPostingCandidatures.Select(x=>new JobPostingCandidature{
                //      Idpersonale= x.Idpersonale,
                //  IdjobPosting=x.IdjobPosting}).ToList();

            return (from candidature in Allcandidatures
                         join detail in Allpersonale on candidature.Idpersonale equals detail.Id 
                         select new JobPostingCandidatureMatricola
                         {
                            Matricola=detail.Matricola,
                            Nome=detail.Nome,
                            Cognome=detail.Cognome,
                             DescrizioneJobPosting=candidature.IdjobPosting.ToString()
                         }).ToList();

        }

        public List<JobPostingCandidatureMatricola> Candidature(string matricola)
        {
          

            var Allpersonale = personaleContext.Personales.Select(x => new Personale
            {
                Id = x.Id,
                Matricola = x.Matricola,
                Cognome = x.Cognome,
                Nome = x.Nome
            }).Where(x => x.Matricola == matricola).ToList();

            if (Allpersonale.Any())
            {

                var Allcandidatures = Context.JobPostingCandidatures.Select(x => new JobPostingCandidature
                {
                    Idpersonale = x.Idpersonale,
                    IdjobPosting = x.IdjobPosting
                }).Where(x => x.Idpersonale == Allpersonale.First().Id).ToList();



                var job = Context.JobPostings.Select(x => new JobPosting { Id = x.Id, Descrizione = x.Descrizione }).ToList();

                //var jbc=  Context.JobPostingCandidatures.Select(x=>new JobPostingCandidature{
                //      Idpersonale= x.Idpersonale,
                //  IdjobPosting=x.IdjobPosting}).ToList();

                return (from candidature in Allcandidatures
                        join detail in Allpersonale on candidature.Idpersonale equals detail.Id
                        join jobposting in job on candidature.IdjobPosting equals jobposting.Id
                        select new JobPostingCandidatureMatricola
                        {
                            Matricola = detail.Matricola,
                            Nome = detail.Nome,
                            Cognome = detail.Cognome,
                            DescrizioneJobPosting = jobposting.Descrizione
                        }).Where(x => x.Matricola == matricola).ToList();
            }
            return Array.Empty<JobPostingCandidatureMatricola>().ToList(); 
        }

        public bool Insert(ConfermaCandidatura confermaCandidatura)
        {
            var Personale = personaleContext.Personales.Select(x => new Personale
            {
                Id = x.Id,
                Matricola = x.Matricola,
                Cognome = x.Cognome,
                Nome = x.Nome
            }).Where(x => x.Matricola == confermaCandidatura.matricola).ToList();

            if (Personale.Any()&& Personale.Count==1)
            {
                var ExistCandidature=Context.JobPostingCandidatures.Select(x=>new JobPostingCandidature
                {
                    Idpersonale= x.Idpersonale,
                    IdjobPosting=x.IdjobPosting
                }).Where(x=>x.IdjobPosting==confermaCandidatura.idjobPosting && x.Idpersonale == Personale[0].Id).ToList();

                if (!ExistCandidature.Any())
                {
                    JobPostingCandidature jobPostingCandidature = new JobPostingCandidature();
                    jobPostingCandidature.DataCandidatura = DateTime.Now;
                    jobPostingCandidature.Idpersonale = Personale[0].Id;
                    jobPostingCandidature.Idprovincia = confermaCandidatura.idprovincia;
                    jobPostingCandidature.Idcomune = confermaCandidatura.idcomune;
                    jobPostingCandidature.IdjobPosting = confermaCandidatura.idjobPosting;
                    jobPostingCandidature.IdsysUtenteUltimaModifica = "netCoreREST";
                    Context.JobPostingCandidatures.Add(jobPostingCandidature);
                    Context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
