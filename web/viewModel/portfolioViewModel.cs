using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.viewModel
{
    public class portfolioViewModel
    {
        public Guid id { get; set; }
        public string ProjectName { get; set; }
        public string Discreption { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }

    }
}
