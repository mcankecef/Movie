using Movie.Business.Manager.Model.Film;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.UI.Model.ViewModel.Directory
{
    public class ListDirectoryVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthOfDate { get; set; }
        public ICollection<FilmForDirectoryDTO> Films { get; set; }
    }
}
