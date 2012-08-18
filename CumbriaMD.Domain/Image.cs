using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CumbriaMD.Domain;


namespace eDetectors.Domain
{
    public class Image : EntityBase
    {
        
        public virtual string FileName { get; set; }
        public virtual long FileSize { get; set; }
        public virtual string FileType { get; set; }
        public virtual string Uri { get; set; }
        public virtual string Caption { get; set; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual DateTime? AddedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        
    }
}
