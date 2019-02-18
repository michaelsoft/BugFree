using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.ViewModels
{
    public class BugViewModel
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public string Description { get; set; }

        public int StateId { get; set; }

        public BugAttachmentViewModel[] Attachments { get; set; }

    }
}
