using ClassLibrary1.Models;
using ClassLibrary1.Models.jobposting;

namespace ClassLibrary1.Services
{
    public interface IJobPostingCandidature
    {
        List<JobPostingCandidatureMatricola> Candidature();

        List<JobPostingCandidatureMatricola> Candidature(string matricola);


        bool Insert(ConfermaCandidatura confermaCandidatura);

        //List<JobPosting> Candidature(string matricola);

    }
}
