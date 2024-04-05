using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.VideoUnitModel
{
    public class VideoUnitModel
    {
        public string VideoTitle { get; set; }
        public string VideoDesciption { get; set; }
        public string VideoUrl { get; set; }
        public Guid Id { get; set; }
    }
}
