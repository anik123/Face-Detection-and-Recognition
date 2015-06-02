using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { set; get; }
        public string FullName { set; get; }
        public byte[] Image { set; get; }

        private List<UserImage> _ImageList = new List<UserImage>();

        public List<UserImage> ImageList
        {
            set { _ImageList = value; }
            get { return _ImageList; }
        }

    }
}
